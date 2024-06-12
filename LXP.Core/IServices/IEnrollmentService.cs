﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LXP.Common.ViewModels;
using LXP.Common.Entities;

namespace LXP.Core.IServices
{
    public interface IEnrollmentService
    {
        Task<bool> Addenroll(EnrollmentViewModel enrollment);

        object GetCourseandTopicsByLearnerId(Guid learnerId);

        public IEnumerable<EnrollmentReportViewModel> GetEnrollmentsReport();
        public IEnumerable<EnrolledUserViewModel> GetEnrolledUsers(Guid courseId);
        public IEnumerable<EnrollmentReportViewModel> GetEnrolledInprogressLearnerbyCourseId(Guid courseId);
        public IEnumerable<EnrollmentReportViewModel> GetEnrolledCompletedLearnerbyCourseId(Guid courseId);

        Task<bool> DeleteEnrollment(Guid enrollmentId);

    }
}