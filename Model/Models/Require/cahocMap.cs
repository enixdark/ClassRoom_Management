using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Model.Models.Mapping
{
    public class cahocMap : EntityTypeConfiguration<cahoc>
    {
        public cahocMap()
        {
            // Primary Key
            this.HasKey(t => t.maca);

            // Properties
            this.Property(t => t.maca)
                .IsRequired()
                .HasMaxLength(5);

            this.Property(t => t.thoiluong)
                .HasMaxLength(20);
            
            // Table & Column Mappings
            this.ToTable("cahoc");
            this.Property(t => t.maca).HasColumnName("maca");
            this.Property(t => t.thoiluong).HasColumnName("thoiluong");
            this.Property(t => t.thoigianbatdau).HasColumnName("thoigianbatdau");
            this.Property(t => t.thoigianketthuc).HasColumnName("thoigianketthuc");
        }
    }


}
