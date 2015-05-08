using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KuasCore.Dao.Base;
using KuasCore.Dao.Mapper;
using KuasCore.Models;
using Spring.Data.Common;
using Spring.Data.Generic;
using System.Data;

namespace KuasCore.Dao.Impl
{
    class CourseDao : GenericDao<Course>, ICourseDao
    {
        override protected IRowMapper<Course> GetRowMapper()
        {
            return new CourseRowMapper();
        }

        public void AddCourse(Course course)
        {
            string command = @"INSERT INTO Course (CourseID, CourseName, CourseDescription) VALUES (@CourseID, @CourseName, @CourseDescription);";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("CourseID", DbType.String).Value = course.CourseID;
            parameters.Add("CourseName", DbType.String).Value = course.CourseName;
            parameters.Add("CourseDescription", DbType.String).Value = course.CourseDescription;

            ExecuteNonQuery(command, parameters);
        }

        public void UpdateCourse(Course course)
        {
            string command = @"UPDATE Course SET CourseName = @CourseName, CourseDescription = @CourseDescription WHERE CourseID = @CourseID;";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("CourseID", DbType.String).Value = course.CourseID;
            parameters.Add("CourseName", DbType.String).Value = course.CourseName;
            parameters.Add("CourseDescription", DbType.String).Value = course.CourseDescription;

            ExecuteNonQuery(command, parameters);
        }

        public void DeleteCourse(Course course)
        {
            string command = @"DELETE FROM Course WHERE CourseID = @CourseID";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("CourseID", DbType.String).Value = course.CourseID;

            ExecuteNonQuery(command, parameters);
        }

        public IList<Course> GetAllCourse()
        {
            string command = @"SELECT * FROM Course ORDER BY CourseID ASC";
            IList<Course> course = ExecuteQueryWithRowMapper(command);
            return course;
        }

        public Course GetCourseById(string CourseID)
        {
            string command = @"SELECT * FROM Course WHERE CourseID = @CourseID";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("CourseID", DbType.String).Value = CourseID;

            IList<Course> course = ExecuteQueryWithRowMapper(command, parameters);
            if (course.Count > 0)
            {
                return course[0];
            }

            return null;
        }

    }
}
