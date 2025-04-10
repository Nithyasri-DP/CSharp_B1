using System;
using CarConnect.dao;
using CarConnect.entity;
using CarConnect.exception;

namespace CarConnect.service
{
    public class AuthenticationService
    {
        private readonly ICustomerService _customerService;
        private readonly IAdminService _adminService;

        public AuthenticationService()
        {
            _customerService = new CustomerService();
            _adminService = new AdminService();
        }

        public bool AuthenticateCustomer(string username, string password)
        {
            Customer customer = _customerService.GetCustomerByUsername(username);
            if (customer == null || customer.cPassword != password)
            {
                throw new AuthenticationException("Invalid customer credentials.");
            }
            return true;
        }

        public bool AuthenticateAdmin(string username, string password)
        {
            Admin admin = _adminService.GetAdminByUsername(username);
            if (admin == null || admin.AdminPassword != password)
            {
                throw new AuthenticationException("Invalid admin credentials.");
            }
            return true;
        }
    }
}
