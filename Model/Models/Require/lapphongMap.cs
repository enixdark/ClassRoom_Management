using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Model.Models.Mapping
{
    public class lapphongMap : EntityTypeConfiguration<lapphong>
    {
        public lapphongMap()
        {
            // Primary Key
            this.HasKey(t => new { t.mahp, t.maphong, t.malop });

            // Properties
            this.Property(t => t.mahp)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.maphong)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.malop)
                .IsRequired()
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("lapphong");
            this.Property(t => t.mahp).HasColumnName("mahp");
            this.Property(t => t.maphong).HasColumnName("maphong");
            this.Property(t => t.malop).HasColumnName("malop");

            // Relationships
            this.HasRequired(t => t.Lop)
                .WithMany(t => t.lapphongs)
                .HasForeignKey(d => d.malop);
            this.HasRequired(t => t.phonghoc)
                .WithMany(t => t.lapphongs)
                .HasForeignKey(d => d.maphong);

        }
    }
}
