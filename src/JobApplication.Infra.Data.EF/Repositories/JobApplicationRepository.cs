using JobApplicationTracker.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using DomainEntity = JobApplicationTracker.Domain.Entity;

namespace JobApplication.Infra.Data.EF.Repositories
{
    public class JobApplicationRepository : IJobApplicationRepository
    {
        private readonly DbSet<DomainEntity.JobApplication> _jobApplications;
        private readonly JobApplicationDbContext _dbContext;
        public JobApplicationRepository(JobApplicationDbContext applicationDbContext)
        {
            _jobApplications = applicationDbContext.Set<DomainEntity.JobApplication>();
            _dbContext = applicationDbContext;
            
        }
        public async Task DeleteAsync(Guid aggregateId)
        {
            var result = await GetByIdAsync(aggregateId);
            _jobApplications.Remove(result);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<DomainEntity.JobApplication>> GetAllAsync()
        {
            var results = await _jobApplications.ToListAsync();
            return results;
        }

        public async Task<DomainEntity.JobApplication> GetByIdAsync(Guid id)
        {
            var result = await _jobApplications.FindAsync(id) ?? throw new AggregateException($"Job Application not found with this id: {id}");
            return result;
        }

        public async Task InsertAsync(DomainEntity.JobApplication aggregate)
        {
            await _jobApplications.AddAsync(aggregate);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(DomainEntity.JobApplication aggregate)
        {
            _jobApplications.Update(aggregate);
            await _dbContext.SaveChangesAsync();
        }
    }
}
