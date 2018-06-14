using ChunChen_CRM.Model;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChunChen_CRM.Services.Extensions
{
    public static class CustomerExtensions
    {
        public static CustomerDetailModel ToModel(this CustomerInfo info)
        {
            if (info == null) { return null; }
            var model = new CustomerDetailModel
            {
                Id = info.Id,
                CustomerNo = info.CustomerNo,
                Name = info.Name,
                Mobile = info.Mobile,
                Address = info.Address,
                Gender = info.Gender,
                Birthday = info.Birthday,
                WaiterId = info.WaiterId,
                WaiterName = info.WaiterName,
                CreateDate = info.CreateDate,
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
