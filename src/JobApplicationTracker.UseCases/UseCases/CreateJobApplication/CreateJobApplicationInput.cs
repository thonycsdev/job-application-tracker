using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplicationTracker.Application.UseCases.CreateJobApplication
{
    public class CreateJobApplicationInput
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
