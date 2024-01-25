using Employee_Form_Using_HTML_and_CSS.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee_Form_Using_HTML_and_CSS.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {

        }

        public DbSet<Employee> employees { get; set; }
    }
}
