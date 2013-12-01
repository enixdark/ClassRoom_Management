using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Model.Models.Mapping
{
    public class hocphanMap : EntityTypeConfiguration<hocphan>
    {
        public hocphanMap()
        {
            // Primary Key
            this.HasKey(t => t.mahp);

            // Properties
            this.Property(t => t.mahp)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.mamh)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("hocphan");
            this.Property(t => t.mahp).HasColumnName("mahp");
            this.Property(t => t.mamh).HasColumnName("mamh");

            // Relationships
            //this.HasOptional(t => t.monhoc)
            //    .WithMany(t => t.hocphans)
            //    .HasForeignKey(d => d.mamh);

        }
    }
}
