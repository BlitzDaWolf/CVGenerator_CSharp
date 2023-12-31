﻿using Octokit;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Reflection;

namespace CVGenerator_CSharp
{
    public class CVDocument : IDocument
    {
        private List<Repository> repositories = new List<Repository>();
        private PersonDetail personDetail;

        int HeaderTextSize = 25;

        public CVDocument(string userName, PersonDetail personDetail)
        {
            Console.WriteLine($"Getting {userName} github data");
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
                page.DefaultTextStyle(x => x.FontSize(15));
                page.Margin(1, Unit.Centimetre);

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
                            .SemiBold().FontColor(Colors.Blue.Darken4);
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
                        .Text(repository.Name);
                    x.Item()
                        .Text(repository.Description);
                    x.Item()
                        .Text(repository.Language);
                });
        }

        void ComposeDetail(IContainer container)
        {
            container.Column(c =>
            {
                c.Item().Row(x =>
                {
                    //x.AutoItem().Hyperlink("mailto:wouters.sameddy@hotmail.com").Text("wouters.sameddy@hotmail.com");
                    x.RelativeItem().AlignLeft().Element(t => ComposeURL(t, "Email: ", "mailto:wouters.sameddy@hotmail.com", "wouters.sameddy@hotmail.com"));
                    x.RelativeItem().AlignRight().Element(t => ComposeURL(t, "Phone: ", "tel:+32487239038", "+32487239038"));
                });
                c.Item().Row(x =>
                {
                    //x.AutoItem().Hyperlink("mailto:wouters.sameddy@hotmail.com").Text("wouters.sameddy@hotmail.com");
                    x.RelativeItem().AlignLeft().Element(t => t.Row(r2 => r2.AutoItem().Text($"Liecence: {personDetail.DriverLicence}")));
                    x.RelativeItem().AlignRight().Element(t => ComposeURL(t, "Github: ", $"https://github.com/{personDetail.GitHub}", personDetail.GitHub));
                });
                c.Item().Row(x =>
                {
                    //x.AutoItem().Hyperlink("mailto:wouters.sameddy@hotmail.com").Text("wouters.sameddy@hotmail.com");
                    x.AutoItem().Element(t => ComposeURL(t, "LinkedIn: ", personDetail.LinkedIn, $"{personDetail.FullName}"));
                });
            });
        }

        void ComposeURL(IContainer contaier, string key, string url, string urlText)
        {
            contaier.Row(r =>
            {
                r.AutoItem().Text(key);
                r.AutoItem().Hyperlink(url).Text(urlText);
            });
        }

        void ComposeEducations(IContainer container)
        {
            container.Column(x =>
            {
                x.Item().BorderTop(1)
                    .Text("Education")
                    .FontSize(HeaderTextSize);
                x.Spacing(20);
                foreach (var education in personDetail.Education)
                {
                    x.Item().Element(e => ComposeEducation(e, education));
                }
            });
        }

        private void ComposeEducation(IContainer container, Education education)
        {
            container.Row(r => {
                r.AutoItem().PaddingTop(2).PaddingRight(5).Text(education.a);
                r.AutoItem().PaddingLeft(5).Element(e =>
                {
                    e.Column(c => {
                        c.Item().Text(education.SchoolName);
                        c.Item().Text(education.type);
                    });
                });
            });
        }

        void ComposeExpierences(IContainer container)
        {
            container.Column(x =>
            {
                x.Item().BorderTop(1)
                    .Text("Expierence")
                    .FontSize(HeaderTextSize);
                x.Spacing(20);
                foreach (var expierence in personDetail.Expierences)
                {
                    x.Item().Element(e => ComposeExpierence(e, expierence));
                }
            });
        }

        void ComposeExpierence(IContainer container, Expierence expierence)
        {
            container.Row(r => {
                r.AutoItem().PaddingTop(2).PaddingRight(5).Text(expierence.a);
                r.AutoItem().PaddingLeft(5).Element(e =>
                {
                    e.Column(c => {
                        c.Item().Text(expierence.SchoolName);
                        c.Item().Text(expierence.function);
                    });
                });
            });
        }

        void ComposeRepositories(IContainer container)
        {
            container.Column(x =>
            {
                x.Spacing(20);
                x.Item().BorderTop(1)
                    .Text("My projects")
                    .FontSize(HeaderTextSize);
                foreach (var repository in repositories)
                {
                    x.Item().Element(y => ComposeRepositories(y, repository));
                }
            });
        }
    }
}
