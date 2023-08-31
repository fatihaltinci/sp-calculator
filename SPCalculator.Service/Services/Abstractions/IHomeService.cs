using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPCalculator.Service.Services.Abstractions
{
    public interface IHomeService 
    {
        Task<List<int>> GetYearlySprintCounts();
        Task<int> GetTotalSprintCount();
        Task<int> GetTotalFunctionCount();
        Task<int> GetTotalParameterCount();
    }
}
