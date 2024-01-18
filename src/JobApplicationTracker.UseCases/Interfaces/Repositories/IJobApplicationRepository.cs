﻿using JobApplicationTracker.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplicationTracker.Application.Interfaces.Repositories
{
    public interface IJobApplicationRepository : IGenericRepository<JobApplication>
    {
    }
}