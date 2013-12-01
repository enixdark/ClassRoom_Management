using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Model.Models.Mapping
{
    public class NganhMap : EntityTypeConfiguration<Nganh>
    {
        public NganhMap()
        {
            // Primary Key
            this.HasKey(t => t.manganh);

            // Properties
            this.Property(t => t.manganh)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.tennganh)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Nganh");
            this.Property(t => t.manganh).HasColumnName("manganh");
            this.Property(t => t.tennganh).HasColumnName("tennganh");
        }
    }
}
