using JobApplicationTracker.Domain.Enums;


namespace JobApplicationTracker.Application.UseCases.CreateJobApplication
{
    public class CreateJobApplicationOutput
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Company { get; set; }
        public string Location { get;set; }
        public JobApplicationStatusEnum Status { get; set; }
        public string Notes { get; set; }
        public DateTime DateApplied { get; set; }
        public DateTime DateUpdated { get; set; }

    }
}
