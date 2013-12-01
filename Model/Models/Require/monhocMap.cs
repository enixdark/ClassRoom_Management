using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Model.Models.Mapping
{
    public class monhocMap : EntityTypeConfiguration<monhoc>
    {
        public monhocMap()
        {
            // Primary Key
            this.HasKey(t => t.mamh);

            // Properties
            this.Property(t => t.mamh)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.tenmh)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("monhoc");
            this.Property(t => t.mamh).HasColumnName("mamh");
            this.Property(t => t.tenmh).HasColumnName("tenmh");
            this.Property(t => t.sotinchi).HasColumnName("sotinchi");
        }
    }
}
