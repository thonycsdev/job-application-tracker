﻿using JobApplicationTracker.Application.UseCases.JobApplications.Common;
using JobApplicationTracker.Domain.Enums;

namespace JobApplicationTracker.Application.Builders.JobApplicationDTOBuilders
{
    public interface IJobApplicationOutputBuilder
    {
        public JobApplicationCommonOutput JobApplicationOutput { get; }
        public IJobApplicationOutputBuilder WithId(Guid id);
        public IJobApplicationOutputBuilder WithName(string name);
        public IJobApplicationOutputBuilder WithDescription(string description);
        public IJobApplicationOutputBuilder WithCompany(string company);
        public IJobApplicationOutputBuilder WithLocation(string location);
        public IJobApplicationOutputBuilder WithStatus(JobApplicationStatusEnum status);
        public IJobApplicationOutputBuilder WithNotes(string notes);
        public IJobApplicationOutputBuilder WithDateApplied(DateTime dateApplied);
        public IJobApplicationOutputBuilder WithDateUpdated(DateTime dateUpdated);

    }
}
