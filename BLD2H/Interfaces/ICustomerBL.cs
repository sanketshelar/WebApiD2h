using Models.D2H;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLD2H.Interfaces
{
    public interface ICustomerBL
    {
        IEnumerable<Customer> GetCustomerByUsername(string username);
        void AddCustomer(Customer obj);

        IEnumerable<Customer> GetCustomerInfo(string packageids);
    }
}
