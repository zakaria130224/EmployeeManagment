using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using AdventureWork.Core.Entity;
using AdventureWork.Infrastracture;
using AdventureWork.Infrastracture.Services;

namespace AdventureWork.WebService.Controllers
{
    public class EmployeeController : Controller
    {
        private  EmployeeRepositoryService serviceObject;

        public EmployeeController()
        {
            serviceObject = new EmployeeRepositoryService();
        }
        
        // GET: Employee
        public ActionResult Index()
        {
            try
            {
                var emp = serviceObject.GetEmployees();
                return View(emp);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public ActionResult DeleteEmployee(int Id)
        {
            try
            {
                if (serviceObject.DeleteEmployeeById(Id))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return Content("Something Went worng!");
                }
            }
            catch (Exception ex)
            {
                
                throw;
            }
           // return View();
        }

        public ActionResult ShowEmployeeById(int Id)
        {
            return View(serviceObject.GetEmployeeAttendancesByEmployeeId(Id));
            //return Content(serviceObject.GetEmployeeById(Id).FullName.ToString());
        }

        [HttpPost]
        public ActionResult AddNewEmployee(EmployeeInfo emp)
        {
            //var newEmp = new EmployeeInfo() { FullName = "abir", Address = "CTG", Email = "abc@gmail.com", Mobile = "15465454545" };
            if (emp.Id==0)
            {
                try
                {
                    if (serviceObject.AddNewEmployee(emp))
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return Content("Something Went worng!");
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }else
            {
                try
                {
                    if (serviceObject.EditEmployeeById(emp))
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return Content("Something Went worng!");
                    }
                }
                catch (Exception ex)
                {

                    throw;
                }
               
              
            }
            

        }
        public ActionResult EditEmployee(int Id)
        {
            var customer = serviceObject.GetEmployeeById(Id);
            if (customer==null)
            {
                return HttpNotFound();
            }
            return View("BtnAction",customer);
        }
        [HttpPost]
        public ActionResult BtnAction(string AddEmpBtn)
        {
            return View("BtnAction");
        }

    }
}