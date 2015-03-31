using System.Collections.Generic;
using System.Linq;

using MVC5_Testing_1.Models;

namespace MVC5_Testing_1.ModelAccess
{
    /// <summary>
    /// Interface for providing functnality for Department Data Access
    /// </summary>
    public interface IDepartmentAccess
    {
       List<Department> GetDepartments();
       Department GetDepartment(int id);
       void CreateDepartment(Department dept);
       bool CheckDeptExist(int id);
    }

    /// <summary>
    /// The Department Data Access
    /// </summary>
    public class DepartmentAccess : IDepartmentAccess
    {
        CompanyEntities ctx;
        public DepartmentAccess()
        {
            ctx = new CompanyEntities(); 
        }
        /// <summary>
        /// Get All Departments
        /// </summary>
        /// <returns></returns>
        public List<Department> GetDepartments()
        {
            var depts = ctx.Departments.ToList();
            return depts;
        }
        /// <summary>
        /// Get Department base on Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Department GetDepartment(int id)
        {
            var dept = ctx.Departments.Find(id);
            return dept;
        }
        /// <summary>
        /// Create Department
        /// </summary>
        /// <param name="dept"></param>
        public void CreateDepartment(Department dept)
        {
            ctx.Departments.Add(dept);
            ctx.SaveChanges();
        }
        /// <summary>
        /// Check whether Department Exist or Not
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool CheckDeptExist(int id)
        {
            var dept = ctx.Departments.Find(id);
            if (dept != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}