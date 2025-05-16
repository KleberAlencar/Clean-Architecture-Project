using Microsoft.EntityFrameworkCore;
using CleanArc.Domain.Accounts.Entities;
using CleanArc.Domain.Accounts.ValueObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArc.Infrastructure.Shared.Data.Mappings;

public class StudentMap : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        #region [ Table and Primary Key ]
        
        builder.ToTable("Students");
        
        builder.HasKey(x => x.Id).HasName("PK_Student");
        
        #endregion
        
        #region [ Columns ]
        
        builder.OwnsOne(x => x.Name, name =>
        {
            name.HasIndex(x => new {x.FirstName, x.LastName})
                .HasDatabaseName("IDX_Student_Name")
                .IsUnique();

            name.Property(x => x.FirstName)
                .IsRequired()
                .HasColumnType("VARCHAR")
                .HasMaxLength(Name.MaxLength)
                .HasColumnName("FirstName");
            
            name.Property(x => x.LastName)
                .IsRequired()
                .HasColumnType("VARCHAR")
                .HasMaxLength(Name.MaxLength)
                .HasColumnName("LastName");            
        });

        builder.OwnsOne(x => x.Email, email =>
        {
            email.HasIndex(x => x.Address)
                .HasDatabaseName("IDX_Student_Email")
                .IsUnique();

            email.Property(x => x.Address)
                .IsRequired()
                .HasColumnType("VARCHAR")
                .HasMaxLength(Email.MaxLength)
                .HasColumnName("Email");
            
            email.Property(x => x.Hash)
                .IsRequired()
                .HasColumnType("VARCHAR")
                .HasMaxLength(255)
                .HasColumnName("EmailHash");            
        });

        builder.OwnsOne(x => x.Tracker, tracker =>
        {
            tracker.Property(x => x.CreatedAtUtc)
                .HasColumnType("DATETIME")
                .HasDefaultValue(DateTime.UtcNow)
                .HasColumnName("CreatedAtUtc");
            
            tracker.Property(x => x.UpdatedAtUtc)
                .HasColumnType("DATETIME")
                .HasDefaultValue(DateTime.UtcNow)
                .HasColumnName("UpdatedAtUtc");            
        });

        #endregion
    }
}