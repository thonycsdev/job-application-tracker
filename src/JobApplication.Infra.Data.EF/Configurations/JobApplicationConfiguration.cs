using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DomainEntity = JobApplicationTracker.Domain.Entity;
namespace JobApplication.Infra.Data.EF.Configurations
{
    public class JobApplicationConfiguration : IEntityTypeConfiguration<DomainEntity.JobApplication>
    {
        public void Configure(EntityTypeBuilder<DomainEntity.JobApplication> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Company).HasMaxLength(255);
            builder.Property(x => x.Description).HasMaxLength(5_000);
            builder.Property(x => x.Status);
            builder.Property(x => x.DateUpdated);
            builder.Property(x => x.DateApplied);
            builder.Property(x => x.Location);
            builder.Property(x => x.Name);
            builder.Property(x => x.Notes).HasMaxLength(10_000);
        }
    }
}
