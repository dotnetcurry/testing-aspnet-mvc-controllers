using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVC5_Testing_1.Controllers;
using System.Web.Mvc;
using MVC5_Testing_1.Models;

namespace ControllerTest
{
    [TestFixture]
    public class ControllerTestClass
    {
        /// <summary>
        /// Test the Action metjod returning Specific Index View
        /// </summary>
        [Test]
        public void TestDepartmentIndex()
        {
            var obj =new DepartmentController();

            var actResult = obj.Index() as ViewResult;

            Assert.That(actResult.ViewName, Is.EqualTo("Index"));
        }

        /// <summary>
        /// Testing the ReditectToRoute to Chekc for the Redirect
        /// to Index Action
        /// </summary>
        [Test]
        public void TestDepartmentCreateRedirect()
        {
            var obj = new DepartmentController();

            RedirectToRouteResult result = obj.Create(new Department()
            {
              DeptNo=190,Dname="D1",Location="L1"
            }) as RedirectToRouteResult;


            Assert.That(result.RouteValues["action"], Is.EqualTo("Index"));
           
        }

        /// <summary>
        /// Test to return Error View is the Model is Invalid
        /// </summary>
        [Test]
        public void TestDepartmentCreateErrorView()
        {
            var obj = new DepartmentController();

            ViewResult result = obj.Create(new Department()
            {
                DeptNo = 2,
                Dname = "D1",
                Location = "L1"
            }) as ViewResult;

            Assert.That(result.ViewName, Is.EqualTo("Error"));
        }

      
    }
}
