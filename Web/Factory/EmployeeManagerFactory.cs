using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Manager;

namespace Web.Factory
{
    public class EmployeeManagerFactory
    {
        public IEmployeeManager GetEmployeeManager(int employeeId)
        {
            IEmployeeManager returnValue = null;
            if (employeeId == 1)
            {
                returnValue = new ParmanentEmployeeManager();
            }
            else if (employeeId == 2)
            {
                returnValue = new ContractEmployeeManager();
            }
            return returnValue;
        }
    }
}