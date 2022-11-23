using Festival_Hue.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Festival_Hue.Interface
{
    public interface ICustomer
    {
        Task<List<CustomerModel>> GetCustomerAll();
        Task<int> CreateCustomer(CustomerModel customerModel);
        Task<int> UpdateCustomer(CustomerModel customerModel);
        Task<int> DeleteCustomer(Guid id);
    }
}
