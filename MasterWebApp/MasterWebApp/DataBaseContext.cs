using System.Data.Entity;
using Template.Repository.Common;

namespace MasterWebApp
{
    [DbConfigurationType(typeof(CodeConfig))]
    public class DataBaseContext : DbContext
    {
        //public DbSet<Sample> Sample { get; set; }

        public DataBaseContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           base.OnModelCreating(DBContextUtil.ModelCreate(modelBuilder));
        }
    }

    public class CodeConfig : DbConfiguration
    {
        public CodeConfig()
        {
            SetProviderServices("System.Data.SqlClient", System.Data.Entity.SqlServer.SqlProviderServices.Instance);
        }
    }
}

