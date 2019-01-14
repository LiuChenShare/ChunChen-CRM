using ChunChen_CRM.IServices;
using ChunChen_CRM.Model;
using ChunChen_CRM.Services.Extensions;
using Data.Entity;
using Data.Repository;
using Storage;

namespace ChunChen_CRM.Services
{
    /// <summary>
    /// 账户相关业务服务
    /// </summary>
    public class EmployeeService : IEmployeeService
    {
        private AccountInfoRepository _accountInfoRepository = new AccountInfoRepository();
        private EmployeeInfoRepository _employeeInfoRepository = new EmployeeInfoRepository();

        /// <summary>
        /// 获取当前用户信息
        /// </summary>
        /// <returns></returns>
        public UserViewModel GetPersonalData()
        {
            UserViewModel userViewModel = new UserViewModel();
            EmployeeInfo employeeInfo = _employeeInfoRepository.GetEmployeeInfo(UserStorage.Instance.EmployeeId);
            userViewModel = employeeInfo.ToUserViewModel();
            if (userViewModel != null)
            {
                userViewModel.Account = UserStorage.Instance.AccountId;
                return userViewModel;
            }
            return null;
        }
    }
}
