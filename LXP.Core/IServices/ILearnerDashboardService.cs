﻿using LXP.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LXP.Core.IServices
{
    public interface ILearnerDashboardService
    {
       public  LearnerDashboardCourseCountViewModel GetLearnerDashboardDetails(Guid learnerId);
    }
}