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
            var model = new EmployeeDetailModel
            {
                Id = info.Id,
                EmployeeNo = info.EmployeeNo,
                Name = info.Name,
                Mobile = info.Mobile,
                Gender = info.Gender,
                Birthday = info.Birthday,
                Authority = info.Authority,
                JoinDate = info.JoinDate,
                Quit = info.Quit,
                QuitDate = info.QuitDate,
                LastUpdatedOn = info.LastUpdatedOn
            };
            if (info.Gender == 0)
            {
                model.GenderString = "女";
            }
            else
            {
                model.GenderString = "男";
            }
            if (info.Quit)
            {
                model.JoinStatus = "离职";
            }
            else
            {
                model.JoinStatus = "在职";
            }

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
