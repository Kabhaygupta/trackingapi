using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using trackingapi.Controllers;
using trackingapi.Data;
using trackingapi.IServices;
using trackingapi.Models;

namespace trackingapi.Services
{
    public class IssueServices : IIssueServices
    {
        private readonly IssueDbContext _issueDbContext;
        
        public IssueServices(IssueDbContext issueDbContext)
        {
            _issueDbContext= issueDbContext;
        }
        public async Task<IEnumerable<Issue>> GetAllIssues()
        {
            var issue = await _issueDbContext.Issue.ToListAsync();
            return issue;
        }

        public IEnumerable<Issue> GetIssueById(int Id)
        {
            var issue= _issueDbContext.Issue.FirstOrDefault(d=>d.Id==Id);
             _issueDbContext.Issue.ToList();
            yield return issue;
        }

        public IEnumerable<Issue> GetByTitle(string title)
        {
            var issue = _issueDbContext.Issue.FirstOrDefault(t=>t.Title==title);
            _issueDbContext.Issue.ToList();
            yield return issue;
        }

        public IEnumerable<Issue> Create(Issue issue)
        {
            if(issue !=null)
            {
                _issueDbContext.Issue.Add(issue);
                _issueDbContext.SaveChanges();
                yield return issue;
            }
            yield return null;
        }

        public IEnumerable<Issue> Update(int id, Issue issue)
        {       
            _issueDbContext.Entry(issue).State=EntityState.Modified;
                _issueDbContext.SaveChanges();
                yield return issue;
            

        }

        public IEnumerable<Issue> Delete(int id)
        {
            var issue = _issueDbContext.Issue.FirstOrDefault(d => d.Id == id);
            _issueDbContext.Entry(issue).State= EntityState.Deleted;
            _issueDbContext.SaveChanges();
            yield return issue;

        }
    }
}
