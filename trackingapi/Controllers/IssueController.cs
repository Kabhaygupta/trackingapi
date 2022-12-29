using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using trackingapi.Data;
using trackingapi.IServices;
using trackingapi.Models;

namespace trackingapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueController : ControllerBase
    {
        private readonly IIssueServices _issueServices;
        public IssueController(IIssueServices issueServices)
        {
            _issueServices= issueServices;  
        }

        [HttpGet]
        [Route("GetAllIssues")]
        public async Task<ActionResult> GetAllIssues()
        {
            var issue=await _issueServices.GetAllIssues();
            //return (IEnumerable<Issue>)Ok(issue);
            return Ok(issue);
        }

        [HttpGet]
        [Route("GetIssueById/{Id}")]
        [ProducesResponseType(typeof(Issue), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IEnumerable<Issue> GetIssueById(int Id)
        {
            var issue =  _issueServices.GetIssueById(Id);

            return issue;
        }

        [HttpGet("search/{title}")]
        [ProducesResponseType(typeof(Issue), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public  IEnumerable<Issue> GetByTitle(string title)
        {
            var issue = _issueServices.GetByTitle(title);
            return issue;
        }

        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IEnumerable<Issue> Create(Issue issue)
        {
            var issues = _issueServices.Create(issue); 
            return issues;
        }

        [HttpPut("UpdsteById/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public  IEnumerable<Issue> Update(int id, Issue issue)
        {
           return _issueServices.Update(id, issue);
        }

        [HttpDelete("DeleteById/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<IActionResult> Delete(int id)
        public IEnumerable<Issue> Delete(int id)
        {
            return _issueServices.Delete(id);

            //var issueToDelete = await _issueServices.Issue.FindAsync(id);
            //if (issueToDelete == null) return NotFound();

            //_issueServices.Issue.Remove(issueToDelete);
            //await _issueServices.SaveChangesAsync();

            //return NoContent();
        }

    }
}
