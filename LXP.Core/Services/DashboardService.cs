﻿using LXP.Common.ViewModels;
using LXP.Core.IServices;
using LXP.Data.IRepository;

namespace LXP.Core.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IDashboardRepository _dashboardRepository;
        public DashboardService(IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }

        public IEnumerable<DashboardLearnerViewModel> GetDashboardLearnerList()
        {
            return _dashboardRepository.GetTotalLearners();
        }

        IEnumerable<DashboardCourseViewModel> IDashboardService.GetDashboardCoursesList()
        {
            return _dashboardRepository.GetTotalCourses();
        }

        IEnumerable<DashboardEnrollmentViewModel> IDashboardService.GetDashboardEnrollmentList()
        {
            return _dashboardRepository.GetTotalEnrollments();
        }

        public Array GetMonthEnrollmentList(string year)
        {
            string[] month = ["Jan", "Feb", "Mar", "Apr", "May", "June", "July", "Aug", "Sept", "Oct","Nov","Dec"];
            var list = _dashboardRepository.GetMonthWiseEnrollments(year).ToList();
            var query = from c in list
                        orderby c.EnrollmentDate.Month
                        group c by c.EnrollmentDate.Month into g
                        select new { EnrollMonth = month[g.Key-1], EnrollCount = g.Count() };
            var output = query.ToList();
            return output.ToArray();
        }

        public Array GetCourseCreatedList()
        {
            var list = _dashboardRepository.GetCourseCreated().ToList();
            var query = from c in list
                        group c by c.CreatedAt.Year into g
                        select new { CreatedYear = g.Key, CourseCount = g.Count() };
            Console.WriteLine(query);
            var output = query.ToList();
            return output.ToArray();
        }

        public string GetMostEnrolledCourse()
        {
            var course = _dashboardRepository.GetMoreEnrolledCourse();
            return "hi";
        }

        //IEnumerable<DashboardEnrollmentViewModel> IDashboardService.GetEnrollments()
        //{
        //    var result = _dashboardRepository.GetTotalEnrollments();
        //    return result;
        //}


        public AdminDashboardViewModel GetAdminDashboardDetails()
        {
            var AdminDashboard = new AdminDashboardViewModel
            {
                NoOfLearners = _dashboardRepository.GetNoOfLearners().Count(),
                NoOfCourse = _dashboardRepository.GetNoOfCourse().Count(),
                NoOfActiveLearners = _dashboardRepository.GetNoOfActiveLearners().Count(),
                EnrollmentYears = _dashboardRepository.GetEnrolledYears(),
                NoofInactiveLearners = _dashboardRepository.GetNoOfInActiveLearners().Count(),
                //HighestEnrolledCourse = _dashboardRepository.GetHighestEnrolledCourse(),
                //GetTopLearners = _dashboardRepository.GetTopLearners(),
                //GetTopFeedback = _dashboardRepository.GetFeedbackresponses(),
            };
            return AdminDashboard;

        }

        public IEnumerable<TopLearnersViewModel> GetTopLearner()
        {
            return _dashboardRepository.GetTopLearner();
        }

        public IEnumerable<HighestEnrolledCourseViewModel> GetHighestEnrolledCourse()
        {
            return _dashboardRepository.GetHighestEnrolledCourse();
        }

        public IEnumerable<RecentFeedbackViewModel> GetRecentfeedbackResponses()
        {
            return _dashboardRepository.GetRecentfeedbackResponses();
        }

      
    }
}
