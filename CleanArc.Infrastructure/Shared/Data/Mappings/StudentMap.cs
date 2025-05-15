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
            name.HasIndex(x => x.FirstName + x.LastName)
                .HasDatabaseName("IDX_Student_Name")
                .IsUnique();
            
            name.Property(x => x.FirstName).HasColumnName("FirstName").HasMaxLength(Name.MaxLength).IsRequired();
        });

        builder.OwnsOne(x => x.Email, email =>
        {
            email.HasIndex(x => x.Address)
                .HasDatabaseName("IDX_Student_Email")
                .IsUnique();
        });

        #endregion
    }
}