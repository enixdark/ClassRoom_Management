using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Model.Models.Mapping
{
    public class AccountMap : EntityTypeConfiguration<Account>
    {
        public AccountMap()
        {
            // Primary Key
            this.HasKey(t => t.maid);

            // Properties
            this.Property(t => t.maid)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.pass)
                .HasMaxLength(30);

            this.Property(t => t.manhom)
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("Account");
            this.Property(t => t.maid).HasColumnName("maid");
            this.Property(t => t.pass).HasColumnName("pass");
            this.Property(t => t.manhom).HasColumnName("manhom");

            // Relationships
            this.HasOptional(t => t.Nhom)
                .WithMany(t => t.Accounts)
                .HasForeignKey(d => d.manhom);

        }
    }
}
