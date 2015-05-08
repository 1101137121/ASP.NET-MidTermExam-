using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KuasCore.Dao;
using KuasCore.Dao.Impl;
using KuasCore.Models;


namespace KuasCore.Services.Impl
{
    class CourseService : ICourseService
    {

        public ICourseDao CourseDao { get; set; }

        public void AddEmployee(Course course)
        {
            CourseDao.AddCourse(course);
        }

        public void UpdateCourse(Course course)
        {
            CourseDao.UpdateCourse(course);
        }

        public void DeleteCourse(Course course)
        {
            course = CourseDao.GetCourseById(course.CourseID);

            if (course != null)
            {
                CourseDao.DeleteCourse(course);
            }
        }

        public IList<Course> GetAllCourse()
        {
            return CourseDao.GetAllCourse();
        }

        public Course GetCourseById(string CourseID)
        {
            return CourseDao.GetCourseById(CourseID);
        }

    }
}
