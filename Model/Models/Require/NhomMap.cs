using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Model.Models.Mapping
{
    public class NhomMap : EntityTypeConfiguration<Nhom>
    {
        public NhomMap()
        {
            // Primary Key
            this.HasKey(t => t.manhom);

            // Properties
            this.Property(t => t.manhom)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.tennhom)
                .HasMaxLength(50);
            this.Property(t => t.phanloai)
                .HasMaxLength(20);
            
            

            // Table & Column Mappings
            this.ToTable("Nhom");
            this.Property(t => t.manhom).HasColumnName("manhom");
            this.Property(t => t.tennhom).HasColumnName("tennhom");
            this.Property(t => t.phanloai).HasColumnName("phanloai");
            this.Property(t => t.thongtin).HasColumnName("thongtin");
            this.Property(t => t.image).HasColumnName("image");
        
        }
    }
}
