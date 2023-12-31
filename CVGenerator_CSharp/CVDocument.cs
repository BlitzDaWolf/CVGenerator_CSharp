using Octokit;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Reflection;

namespace CVGenerator_CSharp
{
    public class CVDocument : IDocument
    {
        private List<Repository> repositories;
        private PersonDetail personDetail;

        public CVDocument(string userName, PersonDetail personDetail)
        {
            var gh = new GitHub();
            var v = gh.GetRepositoriesAsync(userName);
            v.Wait();
            repositories = v.Result
                .Where(x => !string.IsNullOrWhiteSpace(x.Description))
                .Take(10)
                .ToList();
            this.personDetail = personDetail;
        }

        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(50);

                page.Header().Element(ComposeHeader);
                page.Content().Element(ComposeContent);

                page.Footer().AlignCenter().Text(text =>
                {
                    text.CurrentPageNumber();
                    text.Span(" / ");
                    text.TotalPages();
                });
            });
        }

        void ComposeHeader(IContainer container)
        {
            container.Row(row =>
            {
                row.RelativeItem().Column(column =>
                {
                    column
                        .Item().Text(personDetail.FullName)
                        .FontSize(15).SemiBold().FontColor(Colors.Blue.Darken4);
                });
            });
        }

        void ComposeContent(IContainer container)
        {
            container.Column(x =>
            {
                x.Item().Element(ComposeDetail);
                x.Item().Element(ComposeEducations);
                x.Item().Element(ComposeExpierences);
                x.Item().Element(ComposeRepositories);
            });
        }

        void ComposeRepositories(IContainer container, Repository repository)
        {
            container
                .BorderTop(1)
                .BorderColor("#777")
                .Column(x =>
                {
                    x.Item()
                        .Hyperlink(repository.HtmlUrl)
                        .Text(repository.Name)
                        .FontSize(15);
                    x.Item()
                        .Text(repository.Description);
                    x.Item()
                        .Text(repository.Language);
                });
        }

        void ComposeDetail(IContainer container)
        {
            container.Column(x =>
            {
            });
        }

        void ComposeEducations(IContainer container)
        {
            container.Column(x =>
            {
                x.Item()
                    .Text("Education")
                    .FontSize(20);
            });
        }

        void ComposeExpierences(IContainer container)
        {
            /*container.Column(x =>
            {
                x.Item()
                    .Text("Expierence")
                    .FontSize(20);
                x.Item().Table(table =>
                {
                    foreach (var item in personDetail.Expierences)
                    {
                        ComposeExpierence(table, item);
                    }
                });
            });*/
        }

        void ComposeExpierence(TableDescriptor table, Expierence expierence)
        {
        }

        void ComposeRepositories(IContainer container)
        {
            container.Column(x =>
            {
                x.Spacing(20);
                x.Item()
                    .Text("My projects")
                    .FontSize(20);
                foreach (var repository in repositories)
                {
                    x.Item().Element(y => ComposeRepositories(y, repository));
                }
            });
        }
    }
}
