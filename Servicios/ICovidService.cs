using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public interface ICovidService
    {
        public Task<IEnumerable<StateData>> GetStateDataAsync();
        public Task<IEnumerable<CovidCase>> GetCovidCaseAsync();
    }
}
