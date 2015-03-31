using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVC5_Testing_1.ModelAccess;
using System.Web.Mvc;
using MVC5_Testing_1.Controllers;
using MVC5_Testing_1.Models;

namespace ControllerTest
{

    [TestFixture]
    public class DepartmentControllerTestmock
    {
        [Test]
        public void TestDepartmentIndex()
        {
            var fakeObj = new Mock<IDepartmentAccess>();

            var controller = new DepartmentController(fakeObj.Object);

            var actResult = controller.Index() as ViewResult;

            Assert.That(actResult.ViewName, Is.EqualTo("Index"));
        }


        /// <summary>
        /// Testing the ReditectToRoute to Chekc for the Redirect
        /// to Index Action
        /// </summary>
        [Test]
        public void TestDepartmentCreateRedirect()
        {

            var fakeObj = new Mock<IDepartmentAccess>();

            var controller = new DepartmentController(fakeObj.Object);



            RedirectToRouteResult result = controller.Create(new Department()
            {
                DeptNo = 3,
                Dname = "D1",
                Location = "L1"
            }) as RedirectToRouteResult;


            Assert.That(result.RouteValues["action"], Is.EqualTo("Index"));

        }

        /// <summary>
        /// Test to return Error View is the Model is Invalid
        /// </summary>
        [Test]
        public void TestDepartmentCreateErrorView()
        {
            var fakeObj = new Mock<IDepartmentAccess>();

            var controller = new DepartmentController(fakeObj.Object);

            ViewResult result = controller.Create(new Department()
            {
                DeptNo = 2,
                Dname = "D1",
                Location = "L1"
            }) as ViewResult;


            Assert.That(result.ViewName, Is.EqualTo("Error"));

        }
    }
}
