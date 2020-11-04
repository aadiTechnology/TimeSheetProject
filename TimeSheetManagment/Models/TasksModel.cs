using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TimeSheetManagment.Models
{
    public class TasksModel
    {
        public TasksModel()
        {
            this.lstCompany = new List<Company_Master>();
            this.lstClient = new List<ClientDetail>();
            this.lstProject = new List<Project_Details>();
            this.lstModule = new List<Module_Details>();
        }
        public List<Company_Master> lstCompany { get; set; }
        public List<ClientDetail> lstClient { get; set; }
        public List<Project_Details> lstProject { get; set; }
        public List<Module_Details> lstModule { get; set; }
        public int Id { get; set; }
        [Display(Name ="Task Name :")]
        public string TaskName { get; set; }
        [Display(Name = "Task Description :")]
        public string Description { get; set; }
        [Display(Name = "Planned Start Date :")]
        public DateTime PlannedStartDate { get; set; }
        [Display(Name = "Planned End Date :")]
        public DateTime PlannedEndDate { get; set; }
        [Display(Name = "Planned Efforts  :")]
        public int PlannedEfforts { get; set; }

        public int CompanyId { get; set; }
        public int ClientId { get; set; }
        public int ProjectId { get; set; }
        public int ModuleId { get; set; }

        [Display(Name ="Company :")]
        public string CompanyName { get; set; }

        [Display(Name = "Client :")]
        public string ClientName { get; set; }

        [Display(Name = "Project :")]
        public string ProjectName { get; set; }

        [Display(Name = "Module :")]
        public string Modules { get; set; }
    }
}