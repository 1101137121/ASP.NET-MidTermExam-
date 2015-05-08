using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KuasCore.Dao;
using KuasCore.Models;
using KuasCore.Services;
using KuasCore.Services.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spring.Testing.Microsoft;
using System;

namespace KuasCoreTests.Services.Impl
{

    [TestClass]
    public class CourseServiceUnitTest : AbstractDependencyInjectionSpringContextTests
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



        public ICourseService CourseService { get; set; }


        [TestMethod]
        public void TestCourseService_AddCourse()
        {
            Course course = new Course();
            course.CourseID = "UnitTests";
            course.CourseName = "單元測試";
            course.CourseDescription = "單元測試";
            CourseService.AddCourse(course);

            Course dbCourse = CourseService.GetCourseById(course.CourseID);
            Assert.IsNotNull(dbCourse);
            Assert.AreEqual(course.CourseID, dbCourse.CourseID);

            Console.WriteLine("課稱編號 = " + dbCourse.CourseID);
            Console.WriteLine("課程名稱 = " + dbCourse.CourseName);
            Console.WriteLine("課程描述 = " + dbCourse.CourseDescription);

            CourseService.DeleteCourse(dbCourse);
            dbCourse = CourseService.GetCourseById(course.CourseID);
            Assert.IsNull(dbCourse);
        }

        [TestMethod]
        public void TestCourseService_UpdateCourse()
        {
            // 取得資料
            Course course = CourseService.GetCourseById("1");
            Assert.IsNotNull(course);

            // 更新資料
            course.CourseName = "單元測試";
            CourseService.UpdateCourse(course);

            // 再次取得資料
            Course dbCourse = CourseService.GetCourseById(course.CourseID);
            Assert.IsNotNull(dbCourse);
            Assert.AreEqual(course.CourseName, dbCourse.CourseName);

            Console.WriteLine("課稱編號 = " + dbCourse.CourseID);
            Console.WriteLine("課程名稱 = " + dbCourse.CourseName);
            Console.WriteLine("課程描述 = " + dbCourse.CourseDescription);

            Console.WriteLine("================================");

            // 將資料改回來
            course.CourseName = "微積分";
            CourseService.UpdateCourse(course);

            // 再次取得資料
            dbCourse = CourseService.GetCourseById(course.CourseID);
            Assert.IsNotNull(dbCourse);
            Assert.AreEqual(course.CourseName, dbCourse.CourseName);

            Console.WriteLine("課稱編號 = " + dbCourse.CourseID);
            Console.WriteLine("課程名稱 = " + dbCourse.CourseName);
            Console.WriteLine("課程描述 = " + dbCourse.CourseDescription);
        }


        [TestMethod]
        public void TestCourseService_DeleteCourse()
        {
            Course newCourse = new Course();
            newCourse.CourseID = "UnitTests";
            newCourse.CourseName = "單元測試";
            newCourse.CourseDescription = "單元測試";
            CourseService.AddCourse(newCourse);

            Course dbCourse = CourseService.GetCourseById(newCourse.CourseID);
            Assert.IsNotNull(dbCourse);

            CourseService.DeleteCourse(dbCourse);
            dbCourse = CourseService.GetCourseById(newCourse.CourseID);
            Assert.IsNull(dbCourse);
        }

        [TestMethod]
        public void TestCourseService_GetCourseById()
        {
            Course course = CourseService.GetCourseById("1");
            Assert.IsNotNull(course);
            Console.WriteLine("課稱編號 = " + course.CourseID);
            Console.WriteLine("課程名稱 = " + course.CourseName);
            Console.WriteLine("課程描述 = " + course.CourseDescription);
        }


        public object dbCourse { get; set; }
    }

}
