using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeSheetManagment.Models
{
    public class TimeSheetModel
    {
        public int Id { get; set; }
        [Display(Name = "Employee Name :")]
        public string EmpName { get; set; }
        public List<EmployeeDetail> lstEmployee { get; set; }
        public List<Company_Master> lstCompany { get; set; }
        [Display(Name = "Company :")]
        public string CompanyName { get; set; }
        [Display(Name = "Client :")]
        public string ClientName { get; set; }

        [Display(Name = "Project :")]
        public string ProjectName { get; set; }
        public int ActId { get; set; }
        [Display(Name = "Module :")]
        public string Modules { get; set; }
        public int EmpId { get; set; }
        [Display(Name = "Task Name :")]
        public string TaskName { get; set; }
        public int TaskId { get; set; }
        public int CompanyId { get; set; }
        public int ClientId { get; set; }
        public int ProjectId { get; set; }
        public int ModuleId { get; set; }
        [Display(Name = "Actual Start Date :")]
        public DateTime ActualStartDate { get; set; }
        [Display(Name = "Actual End Date :")]
        public DateTime ActualEndDate { get; set; }
        [Display(Name = "Actual Efforts :")]
        public int Efforts { get; set; }
        [Display(Name = "Productive Hrs :")]
        public int ProductiveHrs { get; set; }
        [Display(Name = "Activity Discription:")]
        public string ActivityComment { get; set; }

        [Display(Name = "Activity Type :")]
        public string Activity { get; set; }
        public List<Activity_Type> lstActivity { get; set; }
    }
}