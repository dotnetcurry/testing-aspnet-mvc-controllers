using System.Web.Mvc;

using MVC5_Testing_1.Models;
using MVC5_Testing_1.ModelAccess;

namespace MVC5_Testing_1.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentAccess objds;
        IDepartmentAccess objds1;
        public DepartmentController()
        {
            objds = new DepartmentAccess(); 
        }
        public DepartmentController(IDepartmentAccess obj)
        {
            objds1 = obj; 
        }


        // GET: Department
        public ActionResult Index()
        {
            var Depts = objds.GetDepartments();
            return View("Index",Depts);
        }

         

        // GET: Department/Create
        public ActionResult Create()
        {
            var Dept = new Department();
            return View(Dept);
        }

        // POST: Department/Create
        [HttpPost]
        public ActionResult Create(Department dept)
        {
            try
            {
                objds.CreateDepartment(dept);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }
          
    }
}
