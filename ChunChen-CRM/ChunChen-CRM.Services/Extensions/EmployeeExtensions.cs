using ChunChen_CRM.Model;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChunChen_CRM.Services.Extensions
{
    public static class EmployeeExtensions
    {
        public static EmployeeDetailModel ToModel(this EmployeeInfo info)
        {
            if (info == null) { return null; }
            var model = new EmployeeDetailModel();
            model.Id = info.Id;
            model.EmployeeNo = info.EmployeeNo;
            model.Name = info.Name;
            model.Mobile = info.Mobile;
            model.Gender = info.Gender;
            model.Birthday = info.Birthday;
            model.Authority = info.Authority;
            model.JoinDate = info.JoinDate;
            model.Quit = info.Quit;
            model.QuitDate = info.QuitDate;
            model.LastUpdatedOn = info.LastUpdatedOn;

            return model;
        }

        //public static MonthKaoqinInfo SetEntity(this MonthKaoqinInfo info, MonthKaoqinModel model)
        //{
        //    if (info == null) { info = new MonthKaoqinInfo(); }
        //    info.AnnualLeave = model.AnnualLeave;
        //    info.Dept = model.Dept;
        //    info.Description = model.Description;
        //    info.EmployeeNo = model.EmployeeNo;
        //    info.InDays = model.InDays;
        //    info.Late = model.Late;
        //    info.Leave = model.Leave;
        //    info.Leaves = SerializeDictionaryToJsonString(model.Leaves);
        //    info.Month = model.Month;
        //    info.Name = model.Name;
        //    info.SickLeave = model.SickLeave;
        //    info.Status = model.Status;
        //    info.WorkDays = model.WorkDays;
        //    info.Year = model.Year;
        //    return info;
        //}
    }
}
