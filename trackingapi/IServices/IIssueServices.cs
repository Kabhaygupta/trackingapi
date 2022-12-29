using trackingapi.Models;

namespace trackingapi.IServices
{
    public interface IIssueServices
    {
        Task<IEnumerable<Issue>> GetAllIssues();
        IEnumerable<Issue> GetIssueById(int Id);
        IEnumerable<Issue> GetByTitle(string title );
        IEnumerable<Issue> Create(Issue issue );
        IEnumerable<Issue> Update(int id, Issue issue );
        IEnumerable<Issue> Delete(int id);

    }
}
