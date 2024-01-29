using JobApplicationTracker.Application.UseCases.JobApplications.Common;
using MediatR;

namespace JobApplicationTracker.Application.UseCases.JobApplications.CreateJobApplication
{
    public class CreateJobApplicationInput : IRequest<JobApplicationCommonOutput>
    {
        public CreateJobApplicationInput(string name, string description, string company, string location, string notes)
        {
            Name = name;
            Description = description;
            Company = company;
            Location = location;
            Notes = notes;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Company { get; set; }
        public string Location { get; set; }
        public string Notes { get; set; }
    }
}
