using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Model.Models
{
    public class thoikhoabieuMap : EntityTypeConfiguration<thoikhoabieu>
    {
        public thoikhoabieuMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.mahp)
                .HasMaxLength(20);

            this.Property(t => t.malop)
                .HasMaxLength(20);

            this.Property(t => t.magv)
                .HasMaxLength(20);

            this.Property(t => t.manganh)
                .HasMaxLength(20);

            this.Property(t => t.maca)
                .HasMaxLength(5);

            // Table & Column Mappings
            this.ToTable("thoikhoabieu");
            this.Property(t => t.mahp).HasColumnName("mahp");
            this.Property(t => t.malop).HasColumnName("malop");
            this.Property(t => t.magv).HasColumnName("magv");
            this.Property(t => t.manganh).HasColumnName("manganh");
            this.Property(t => t.maca).HasColumnName("maca");
            this.Property(t => t.siso).HasColumnName("siso");
            this.Property(t => t.tuanhocbatdau).HasColumnName("tuanhocbatdau");
            this.Property(t => t.tuanhocketthuc).HasColumnName("tuanhocketthuc");
            this.Property(t => t.ID).HasColumnName("ID");

            // Relationships
            this.HasOptional(t => t.cahoc)
                .WithMany(t => t.thoikhoabieus)
                .HasForeignKey(d => d.maca);
            this.HasOptional(t => t.Giangvien)
                .WithMany(t => t.thoikhoabieus)
                .HasForeignKey(d => d.magv);
            this.HasOptional(t => t.hocphan)
                .WithMany(t => t.thoikhoabieus)
                .HasForeignKey(d => d.mahp);
            this.HasOptional(t => t.Lop)
                .WithMany(t => t.thoikhoabieus)
                .HasForeignKey(d => d.malop);
            this.HasOptional(t => t.Nganh)
                .WithMany(t => t.thoikhoabieus)
                .HasForeignKey(d => d.manganh);

        }
    }
}
