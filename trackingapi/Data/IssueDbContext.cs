using Microsoft.EntityFrameworkCore;
using trackingapi.Models;

namespace trackingapi.Data
{
    public class IssueDbContext:DbContext
    {
        public IssueDbContext(DbContextOptions<IssueDbContext> options):base(options){}
        public virtual DbSet<Issue> Issue { get; set; }

    }
}
