using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Model.Models.Mapping
{
    public class quyentruycapMap : EntityTypeConfiguration<quyentruycap>
    {
        public quyentruycapMap()
        {
            // Primary Key
            this.HasKey(t => new { t.manhom, t.maquyen });

            // Properties
            this.Property(t => t.manhom)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.maquyen)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.trangthai)
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("quyentruycap");
            this.Property(t => t.manhom).HasColumnName("manhom");
            this.Property(t => t.maquyen).HasColumnName("maquyen");
            this.Property(t => t.trangthai).HasColumnName("trangthai");

            // Relationships
            this.HasRequired(t => t.Nhom)
                .WithMany(t => t.quyentruycaps)
                .HasForeignKey(d => d.maquyen);
            this.HasRequired(t => t.quyen)
                .WithMany(t => t.quyentruycaps)
                .HasForeignKey(d => d.maquyen);

        }
    }
}
