using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FuntionalService
{
    public interface IFunctionalSvc
    {
        Task CreateDefaultAdminUser();
        Task CreateDefaultUser();
    }
}
