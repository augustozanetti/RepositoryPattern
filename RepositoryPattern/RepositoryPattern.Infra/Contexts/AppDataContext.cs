using RepositoryPattern.domain.Entities;
using RepositoryPattern.Infra.Mappings;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace RepositoryPattern.Infra.Contexts
{
    public class AppDataContext : DbContext
    {
        public AppDataContext()
            : base("AppCnnStr")
        {

        }

        public DbSet<Customer> Customers{ get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new CustomerMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
