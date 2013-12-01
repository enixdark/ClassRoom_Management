using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Model.Models.Mapping
{
    public class quyenMap : EntityTypeConfiguration<quyen>
    {
        public quyenMap()
        {
            // Primary Key
            this.HasKey(t => t.maquyen);

            // Properties
            this.Property(t => t.maquyen)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.quyenloi)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("quyen");
            this.Property(t => t.maquyen).HasColumnName("maquyen");
            this.Property(t => t.quyenloi).HasColumnName("quyenloi");
        }
    }
}
