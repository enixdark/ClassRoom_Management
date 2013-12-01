using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Model.Models.Mapping
{
    public class tuanhocMap : EntityTypeConfiguration<tuanhoc>
    {
        public tuanhocMap()
        {
            // Primary Key
            this.HasKey(t => t.tuan);

            // Properties
            this.Property(t => t.tuan)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.thoigianbatdau)
                .HasMaxLength(30);

            this.Property(t => t.thoigianketthuc)
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("tuanhoc");
            this.Property(t => t.tuan).HasColumnName("tuan");
            this.Property(t => t.thoigianbatdau).HasColumnName("thoigianbatdau");
            this.Property(t => t.thoigianketthuc).HasColumnName("thoigianketthuc");
        }
    }
}
