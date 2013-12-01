using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Model.Models.Mapping
{
    public class SinhVienMap : EntityTypeConfiguration<SinhVien>
    {
        public SinhVienMap()
        {
            // Primary Key
            this.HasKey(t => t.masv);

            // Properties
            this.Property(t => t.masv)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.hoten)
                .HasMaxLength(40);

            this.Property(t => t.malop)
                .HasMaxLength(20);

            this.Property(t => t.manganh)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("SinhVien");
            this.Property(t => t.masv).HasColumnName("masv");
            this.Property(t => t.hoten).HasColumnName("hoten");
            this.Property(t => t.malop).HasColumnName("malop");
            this.Property(t => t.manganh).HasColumnName("manganh");
            this.Property(t => t.gioitinh).HasColumnName("gioitinh");

            // Relationships
            this.HasRequired(t => t.Account)
                .WithOptional(t => t.SinhVien);
            this.HasOptional(t => t.Lop)
                .WithMany(t => t.SinhViens)
                .HasForeignKey(d => d.malop);
            this.HasOptional(t => t.Nganh)
                .WithMany(t => t.SinhViens)
                .HasForeignKey(d => d.manganh);

        }
    }
}
