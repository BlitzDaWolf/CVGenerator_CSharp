using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVGenerator_CSharp
{
    public class GitHub
    {
        public GitHubClient GetHTTPClient()
        {
            var github = new GitHubClient(new ProductHeaderValue("MyAmazingApp"));
            return github;
        }

        public async Task<List<Repository>> GetRepositoriesAsync(string name)
        {
            var res = await GetHTTPClient().Repository.GetAllForUser(name);
            return res.OrderByDescending(x => x.UpdatedAt).ToList();
        }

        public async Task<User> GetUser(string name)
        {
            User user = await GetHTTPClient().User.Get(name);
            return user;
        }
    }
}
