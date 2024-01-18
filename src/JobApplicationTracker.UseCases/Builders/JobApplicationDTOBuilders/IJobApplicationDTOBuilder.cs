using JobApplicationTracker.Application.UseCases.CreateJobApplication;
using JobApplicationTracker.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplicationTracker.Application.Builders.JobApplicationDTOBuilders
{
    public interface IJobApplicationDTOBuilder
    {
        public CreateJobApplicationOutput JobApplicationOutput { get; }
        public IJobApplicationDTOBuilder WithId(Guid id);
        public IJobApplicationDTOBuilder WithName(string name);
        public IJobApplicationDTOBuilder WithDescription(string description);
        public IJobApplicationDTOBuilder WithCompany(string company);
        public IJobApplicationDTOBuilder WithLocation(string location);
        public IJobApplicationDTOBuilder WithStatus(JobApplicationStatusEnum status);
        public IJobApplicationDTOBuilder WithNotes(string notes);
        public IJobApplicationDTOBuilder WithDateApplied(DateTime dateApplied);
        public IJobApplicationDTOBuilder WithDateUpdated(DateTime dateUpdated);

    }
}
