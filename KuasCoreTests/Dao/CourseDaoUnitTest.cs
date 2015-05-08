using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KuasCore.Dao;
using KuasCore.Dao.Impl;
using KuasCore.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spring.Testing.Microsoft;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace KuasCoreTests.Dao
{
  
    [TestClass]
    public class CourseDaoUnitTest : AbstractDependencyInjectionSpringContextTests
    {
         override protected string[] ConfigLocations
        {
            get
            {
                return new String[] { 
                    // assembly://MyAssembly/MyNamespace/ApplicationContext.xml
                    "~/Config/KuasCoreDatabase.xml",
                    "~/Config/KuasCoreTests.xml" 
                };
            }
        }



         public ICourseDao CourseDao { get; set; }


        [TestMethod]
         public void TestCourseDao_AddCourse()
        {
            Course course = new Course();
            course.CourseID = "UnitTests";
            course.CourseName = "單元測試";
            course.CourseDescription = "單元測試";
            CourseDao.AddCourse(course);

            Course dbCourse = CourseDao.GetCourseById(course.CourseID);
            Assert.IsNotNull(dbCourse);
            Assert.AreEqual(course.CourseID, dbCourse.CourseID);

            Console.WriteLine("課稱編號 = " + dbCourse.CourseID);
            Console.WriteLine("課程名稱 = " + dbCourse.CourseName);
            Console.WriteLine("課程描述 = " + dbCourse.CourseDescription);

            CourseDao.DeleteCourse(dbCourse);
            dbCourse = CourseDao.GetCourseById(course.CourseID);
            Assert.IsNull(dbCourse);
        }

        [TestMethod]
        public void TestCourseDao_UpdateCourse()
        {
            // 取得資料
            Course course = CourseDao.GetCourseById("1");
            Assert.IsNotNull(course);

            // 更新資料
            course.CourseName = "單元測試";
            CourseDao.UpdateCourse(course);

            // 再次取得資料
            Course dbCourse = CourseDao.GetCourseById(course.CourseID);
            Assert.IsNotNull(dbCourse);
            Assert.AreEqual(course.CourseName, dbCourse.CourseName);

            Console.WriteLine("課稱編號 = " + dbCourse.CourseID);
            Console.WriteLine("課程名稱 = " + dbCourse.CourseName);
            Console.WriteLine("課程描述 = " + dbCourse.CourseDescription);

            Console.WriteLine("================================");

            // 將資料改回來
            course.CourseName = "微積分";
            CourseDao.UpdateCourse(course);

            // 再次取得資料
            dbCourse = CourseDao.GetCourseById(course.CourseID);
            Assert.IsNotNull(dbCourse);
            Assert.AreEqual(course.CourseName, dbCourse.CourseName);

            Console.WriteLine("課稱編號 = " + dbCourse.CourseID);
            Console.WriteLine("課程名稱 = " + dbCourse.CourseName);
            Console.WriteLine("課程描述 = " + dbCourse.CourseDescription);
        }


        [TestMethod]
        public void TestCourseDao_DeleteCourse()
        {
            Course newCourse = new Course();
            newCourse.CourseID = "UnitTests";
            newCourse.CourseName = "單元測試";
            newCourse.CourseDescription = "單元測試";
            CourseDao.AddCourse(newCourse);

            Course dbCourse = CourseDao.GetCourseById(newCourse.CourseID);
            Assert.IsNotNull(dbCourse);

            CourseDao.DeleteCourse(dbCourse);
            dbCourse = CourseDao.GetCourseById(newCourse.CourseID);
            Assert.IsNull(dbCourse);
        }

        [TestMethod]
        public void TestCourseDao_GetCourseById()
        {
            Course course = CourseDao.GetCourseById("1");
            Assert.IsNotNull(course);
            Console.WriteLine("課稱編號 = " + course.CourseID);
            Console.WriteLine("課程名稱 = " + course.CourseName);
            Console.WriteLine("課程描述 = " + course.CourseDescription);
        }


        public object dbCourse { get; set; }
    }
}
