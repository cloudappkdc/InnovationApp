using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Model;
using System.Data.Entity.ModelConfiguration;

namespace Template.Repository
{
    public class SampleMap : EntityTypeConfiguration<Sample>
    {
        public SampleMap()
        {
            //key
            HasKey(t => t.Id);
            //properties
            Property(t => t.Name).IsRequired().HasMaxLength(100).HasColumnType("nvarchar");
            Property(t => t.Address).IsRequired().HasMaxLength(100).HasColumnType("nvarchar");
            Property(t => t.CreatedBy).HasMaxLength(100).HasColumnType("nvarchar");
            Property(t => t.CreatedOn).HasColumnType("datetime");
            //table
            ToTable("Sample");
        }
    }
}
