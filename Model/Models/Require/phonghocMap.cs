using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Model.Models.Mapping
{
    public class phonghocMap : EntityTypeConfiguration<phonghoc>
    {
        public phonghocMap()
        {
            // Primary Key
            this.HasKey(t => t.maphong);

            // Properties
            this.Property(t => t.maphong)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.tenphong)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("phonghoc");
            //this.Property(t => t._id).HasColumnName("_id");
            this.Property(t => t.maphong).HasColumnName("maphong");
            this.Property(t => t.tenphong).HasColumnName("tenphong");
            this.Property(t => t.dien_tich).HasColumnName("dien_tich");
            this.Property(t => t.siso).HasColumnName("siso");
            this.Property(t => t.images).HasColumnName("images");
        }
    }
}
