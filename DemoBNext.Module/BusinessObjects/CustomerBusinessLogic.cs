using DevExpress.ExpressApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBNext.Module.BusinessObjects
{
    public class CustomerBusinessLogic : ICustomerBusinessLogic
    {
        XafApplication XafApplication { get; set; }


        public CustomerBusinessLogic(XafApplication xafApplication)
        {
            XafApplication = xafApplication;
        }
        public void ActivateCustomer(string CustomerCode)
        {
            var Os = this.XafApplication.CreateObjectSpace(typeof(Customer));
            var CustomerInstance = Os.GetObjectsQuery<Customer>().FirstOrDefault(c => c.Code == CustomerCode);
            if (CustomerInstance != null)
            {
                CustomerInstance.Active = true;
            }
            Os.CommitChanges();
        }
    }
}
