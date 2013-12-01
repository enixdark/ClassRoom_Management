using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;


namespace Model.Models
{
    public class trangthaiphongMap : EntityTypeConfiguration<trangthaiphong>
    {
        public trangthaiphongMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.maphong)
                .HasMaxLength(10);

            this.Property(t => t.maca)
                .HasMaxLength(5);

            this.Property(t => t.hientrang)
                .HasMaxLength(50);

            //this.Property(t => t.thu)
            //    .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("trangthaiphong");
            this.Property(t => t.maphong).HasColumnName("maphong");
            //this.Property(t => t.tuan).HasColumnName("tuan");
            this.Property(t => t.maca).HasColumnName("maca");
            this.Property(t => t.hientrang).HasColumnName("hientrang");
            //this.Property(t => t.thu).HasColumnName("thu");
            this.Property(t => t.thoigianbatdau).HasColumnName("thoigianbatdau");
            this.Property(t => t.thoigianketthuc).HasColumnName("thoigianketthuc");
            this.Property(t => t.ID).HasColumnName("ID");

            // Relationships
            this.HasOptional(t => t.cahoc)
                .WithMany(t => t.trangthaiphongs)
                .HasForeignKey(d => d.maca);
            this.HasOptional(t => t.phonghoc)
                .WithMany(t => t.trangthaiphongs)
                .HasForeignKey(d => d.maphong);

        }
    }
}
