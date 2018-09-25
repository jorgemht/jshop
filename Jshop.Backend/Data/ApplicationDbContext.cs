using Microsoft.EntityFrameworkCore;
using Jshop.Domain;
namespace Jshop.Backend.Data
{
    using Jshop.Domain;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : MainDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { } 
   }
}
