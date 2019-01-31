using ChunChen_CRM.Model;
using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChunChen_CRM.Services.Extensions
{
    public static class EmployeeExtensions
    {
        public static UserViewModel ToUserViewModel(this EmployeeInfo info)
        {
            if (info == null) { return null; }
            var model = new UserViewModel
            {
                Id = info.Id,
                EmployeeNo = info.EmployeeNo,
                Name = info.Name,
                Mobile = info.Mobile,
                Gender = info.Gender,
                Birthday = info.Birthday,
                Authority = info.Authority,
                Spend = info.Spend,
                JoinDate = info.JoinDate,
                Quit = info.Quit,
                QuitDate = info.QuitDate,
                CreateDate = info.CreateDate,
                LastUpdatedOn = info.LastUpdatedOn
            };
            model.GenderString = info.Gender == 0 ? "女" : "男";
            return model;
        }


        public static EmployeeInfo SetEntity(this EmployeeInfo info, UserViewModel model)
        {
            if (info == null)
            {
                info = new EmployeeInfo();
                info.CreateDate = DateTime.Now;
                info.Id = Guid.NewGuid();
            }
            //info.EmployeeNo = model.EmployeeNo;
            info.Name = model.Name;
            info.Mobile = model.Mobile;
            info.Gender = model.Gender;
            info.Birthday = model.Birthday;
            info.Authority = model.Authority;
            info.Spend = model.Spend;
            info.JoinDate = model.JoinDate;
            info.Quit = model.Quit;
            info.QuitDate = model.QuitDate;
            info.LastUpdatedOn = DateTime.Now;
            return info;
        }
        //public static EmployeeSelectItem ToSelectItem(this EmployeeInfo info)
        //{
        //    if (info == null) { return null; }
        //    var model = new EmployeeSelectItem
        //    {
        //        Id = info.Id,
        //        EmployeeNo = info.EmployeeNo,
        //        Name = info.Name,
        //    };

        //    return model;
        //}

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
