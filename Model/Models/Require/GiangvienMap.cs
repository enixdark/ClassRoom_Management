using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Model.Models.Mapping
{
    public class GiangvienMap : EntityTypeConfiguration<Giangvien>
    {
        public GiangvienMap()
        {
            // Primary Key
            this.HasKey(t => t.magv);

            // Properties
            this.Property(t => t.magv)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.tengv)
                .HasMaxLength(40);

            this.Property(t => t.manganh)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("Giangvien");
            this.Property(t => t.magv).HasColumnName("magv");
            this.Property(t => t.tengv).HasColumnName("tengv");
            this.Property(t => t.manganh).HasColumnName("manganh");

            // Relationships
            this.HasRequired(t => t.Account)
                .WithOptional(t => t.Giangvien);
            this.HasOptional(t => t.Nganh)
                .WithMany(t => t.Giangviens)
                .HasForeignKey(d => d.manganh);

        }
    }
}
