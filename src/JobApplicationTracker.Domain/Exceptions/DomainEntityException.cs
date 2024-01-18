using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplicationTracker.Domain.Exceptions
{
    public class DomainEntityException : Exception
    {
        public DomainEntityException(string message) : base(message) { }
    }
}
