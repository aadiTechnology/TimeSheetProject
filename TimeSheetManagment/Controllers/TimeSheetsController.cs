using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeSheetManagment.Models;

namespace TimeSheetManagment.Controllers
{
    public class TimeSheetsController : Controller
    {
        TimeSheetMangementEntities objTMS = new TimeSheetMangementEntities();
        // GET: TimeSheet
        public ActionResult TimeSheets()
        {
            List<Company_Master> CompanyList = objTMS.Company_Master.ToList();
            ViewBag.Company = new SelectList(CompanyList, "Id", "CompanyName");

            List<EmployeeDetail> EmployeeList = objTMS.EmployeeDetails.ToList();
            ViewBag.Employee = new SelectList(EmployeeList, "Id", "EmpName");

            List<Activity_Type> ActivityList = objTMS.Activity_Type.ToList();
            ViewBag.Activity = new SelectList(ActivityList, "Id", "Activity");
            return View();

        }

        [HttpPost]
        public ActionResult TimeSheets(TimeSheetModel objTimeSheetModel)
        {
            TimeSheetsDetail tmDetails = new TimeSheetsDetail();
            tmDetails.EmpId = objTimeSheetModel.EmpId;
            tmDetails.TaskId = objTimeSheetModel.TaskId;
            tmDetails.ActualStartDate = objTimeSheetModel.ActualStartDate;
            tmDetails.ActualEndDate = objTimeSheetModel.ActualEndDate;
            tmDetails.Efforts = objTimeSheetModel.Efforts;
            tmDetails.ProductiveHrs = objTimeSheetModel.ProductiveHrs;
            tmDetails.ActivityComment = objTimeSheetModel.ActivityComment;
            tmDetails.ActId = objTimeSheetModel.ActId;
            objTMS.TimeSheetsDetails.Add(tmDetails);
            objTMS.SaveChanges();

            return RedirectToAction("TimeSheets");
            
        }

        public ActionResult LoadTimeSheetData()
        {
            try
            {
                var Result = (from tm in objTMS.TimeSheetsDetails
                              join tsk in objTMS.TaskDeatils
                                    on tm.TaskId equals tsk.Id
                              join mod in objTMS.Module_Details
                                    on tsk.ModuleId equals mod.Id
                              join act in objTMS.Activity_Type
                                   on tm.ActId equals act.Id
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
                                  ActivityDiscription= tm.ActivityComment,
                                  Module = mod.Modules,
                                  Task = tsk.TaskName,
                                  ActivityType = act.Activity,
                                  ActualStartDate = tm.ActualStartDate,
                                  ActualEndDate = tm.ActualEndDate,
                                  Efforts = tm.Efforts,
                                  ProductiveHrs = tm.ProductiveHrs
                              }
                    );

                return Json(new { data = Result }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public JsonResult GetModuleWiseTasks(int ModuleId)
        {
            objTMS.Configuration.ProxyCreationEnabled = false;
            List<TaskDeatil> lstTasks = objTMS.TaskDeatils.Where(x => x.ModuleId == ModuleId).ToList();
            return Json(lstTasks, JsonRequestBehavior.AllowGet);
        }
    }
}