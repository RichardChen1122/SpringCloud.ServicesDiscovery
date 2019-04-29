using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpringCould.Service1.Controllers
{
    public interface IFortuneService
    {
        Task<string> RandomFortuneAsync();
    }
}
