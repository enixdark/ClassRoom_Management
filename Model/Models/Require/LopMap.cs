using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Model.Models.Mapping
{
    public class LopMap : EntityTypeConfiguration<Lop>
    {
        public LopMap()
        {
            // Primary Key
            this.HasKey(t => t.malop);

            // Properties
            this.Property(t => t.malop)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.tenlop)
                .HasMaxLength(20);

            this.Property(t => t.manganh)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("Lop");
            this.Property(t => t.malop).HasColumnName("malop");
            this.Property(t => t.tenlop).HasColumnName("tenlop");
            this.Property(t => t.manganh).HasColumnName("manganh");

            // Relationships
            this.HasOptional(t => t.Nganh)
                .WithMany(t => t.Lops)
                .HasForeignKey(d => d.manganh);

        }
    }
}
