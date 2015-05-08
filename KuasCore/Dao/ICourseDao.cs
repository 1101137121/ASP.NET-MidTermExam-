using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KuasCore.Models;


namespace KuasCore.Dao
{
    class ICourseDao
    {

        Course GetCourseById(string CourseID);


        internal void AddCourse(Course course)
        {
            throw new System.NotImplementedException();
        }

        internal void UpdateCourse(Course course)
        {
            throw new System.NotImplementedException();
        }

        internal Course GetCourseById(string p)
        {
            throw new System.NotImplementedException();
        }

        internal void DeleteCourse(Course course)
        {
            throw new System.NotImplementedException();
        }

        internal System.Collections.Generic.IList<Course> GetAllCourse()
        {
            throw new System.NotImplementedException();
        }
    }
}
