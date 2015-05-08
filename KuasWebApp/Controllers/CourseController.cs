using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KuasCore.Models;
using KuasCore.Services;
using KuasCore.Services.Impl;
using System.Net;
using System.Web.Http;

namespace KuasWebApp.Controllers
{
    public class CourseController : ApiController
    {
        public ICourseService CourseService { get; set; }

        [HttpPost]
        public Course AddCourse(Course course)
        {
            CheckCourseIsNotNullThrowException(course);

            try
            {
                CourseService.AddCourse(course);
                return CourseService.GetCourseById(course.CourseID);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut]
        public Course UpdateCourse(Course course)
        {
            CheckCourseIsNullThrowException(course);

            try
            {
                CourseService.UpdateCourse(course);
                return CourseService.GetCourseById(course.CourseID);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete]
        public void DeleteCourse(Course course)
        {
            try
            {
                CourseService.DeleteCourse(course);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        public IList<Course> GetAllCourse()
        {
            return CourseService.GetAllCourse();
        }

        [HttpGet]
        [ActionName("byId")]
        public Course GetCourseById(string CourseID)
        {
            var course = CourseService.GetCourseById(CourseID);

            if (course == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return course;
        }

        



        private void CheckCourseIsNullThrowException(Course course)
        {
            Course dbCourse = CourseService.GetCourseById(course.CourseID);

            if (dbCourse == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

       



        private void CheckCourseIsNotNullThrowException(Course course)
        {
            Course dbCourse = CourseService.GetCourseById(course.CourseID);

            if (dbCourse != null)
            {
                throw new HttpResponseException(HttpStatusCode.Conflict);
            }
        }
    }
}