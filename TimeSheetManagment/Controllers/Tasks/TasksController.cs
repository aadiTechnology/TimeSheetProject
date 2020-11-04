using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeSheetManagment.Models;

namespace TimeSheetManagment.Controllers.Tasks
{
    public class TasksController : Controller
    {
        TimeSheetMangementEntities objTMS = new TimeSheetMangementEntities();
        // GET: Tasks
        public ActionResult Tasks()
        {
            List<Company_Master> CompanyList = objTMS.Company_Master.ToList();
            ViewBag.Company = new SelectList(CompanyList, "Id", "CompanyName");
            return View();

            //var lstEmployeeDetails = new SelectList(objTMS.EmployeeDetails.ToList(), "Id", "EmpName");
            //ViewData["Employee"] = lstEmployeeDetails;
           
        }
        [HttpPost]
        public ActionResult Tasks(TasksModel objTasksModel)
        {
            TaskDeatil TskDetails = new TaskDeatil();
            TskDetails.TaskName = objTasksModel.TaskName;
            TskDetails.Description = objTasksModel.Description;
            TskDetails.PlannedStartDate = objTasksModel.PlannedStartDate;
            TskDetails.PlannedEndDate = objTasksModel.PlannedEndDate;
            TskDetails.PlannedEfforts = objTasksModel.PlannedEfforts;
            TskDetails.ModuleId = objTasksModel.ModuleId;
            objTMS.TaskDeatils.Add(TskDetails);
            objTMS.SaveChanges();

            return RedirectToAction("Tasks");
        }

        public ActionResult LoadTasksData()
        {
            try
            {
                var Result = (from tsk in objTMS.TaskDeatils
                              join mod in objTMS.Module_Details
                                    on tsk.ModuleId equals mod.Id
                              join prj in objTMS.Project_Details
                                    on mod.ProjectId equals prj.Id
                              join clnt in objTMS.ClientDetails
                                    on prj.ClientId equals clnt.Id
                              join comp in objTMS.Company_Master
                                    on clnt.CompanyId equals comp.Id
                            select new
                            {
                                Company = comp.CompanyName,
                                Client = clnt.ClientName,
                                Project = prj.ProjectName,
                                Module = mod.Modules,
                                Task = tsk.TaskName,
                                Description = tsk.Description,
                                PlannedStartDate = tsk.PlannedStartDate,
                                PlannedEndDate = tsk.PlannedEndDate,
                                PlannedEfforts = tsk.PlannedEfforts
                            }
                    );

                return Json(new { data = Result }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public JsonResult GetActivity(int ActId)
        {
            objTMS.Configuration.ProxyCreationEnabled = false;
            List<Activity_Type> lstactivity = objTMS.Activity_Type.ToList();
            return Json(lstactivity, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCompanyWiseClients(int CompanyId)
        {
            objTMS.Configuration.ProxyCreationEnabled = false;
            List<ClientDetail> lstclient = objTMS.ClientDetails.Where(x => x.CompanyId == CompanyId).ToList();
            return Json(lstclient, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetClientWiseProjects(int ClientId)
        {
            objTMS.Configuration.ProxyCreationEnabled = false;
            List<Project_Details> lstProjects = objTMS.Project_Details.Where(x => x.ClientId == ClientId).ToList();
            return Json(lstProjects, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetProjectWiseModules(int ProjectId)
        {
            objTMS.Configuration.ProxyCreationEnabled = false;
            List<Module_Details> lstModules = objTMS.Module_Details.Where(x => x.ProjectId == ProjectId).ToList();
            return Json(lstModules, JsonRequestBehavior.AllowGet);
        }


    }
}