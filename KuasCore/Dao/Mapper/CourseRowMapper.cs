using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KuasCore.Models;
using Spring.Data.Generic;
using System.Data;

namespace KuasCore.Dao.Mapper
{
    class CourseRowMapper : IRowMapper<Course>
    {
        public Course MapRow(IDataReader dataReader, int rowNum)
        {
            Course target = new Course();

            target.CourseID = dataReader.GetString(dataReader.GetOrdinal("CourseID"));
            target.CourseName = dataReader.GetString(dataReader.GetOrdinal("CourseName"));
            target.CourseDescription = dataReader.GetString(dataReader.GetOrdinal("CourseDescription"));

            return target;
        }

    }
}
