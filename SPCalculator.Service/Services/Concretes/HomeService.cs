using SPCalculator.Data.UnitOfWorks;
using SPCalculator.Entity.Entities;
using SPCalculator.Service.Services.Abstractions;


namespace SPCalculator.Service.Services.Concretes
{
    public class HomeService : IHomeService
    {
        private readonly IUnitOfWork unitOfWork;

        public HomeService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<List<int>> GetYearlySprintCounts()
        {
            var sprint = await unitOfWork.GetRepository<Sprint>().GetAllAsync(x => !x.IsDeleted, x => x.Function, y => y.Parameter);

            var startDate = DateTime.Now.Date;
            startDate = new DateTime(startDate.Year, 1, 1);

            List<int> datas = new();

            for (int i = 1; i <= 12; i++)
            {
                var startedDate = new DateTime(startDate.Year, i, 1); // 1. ay 
                var endedDate = startedDate.AddMonths(1); // 1 ekle diğer ayın ilk gününe git
                var data = sprint.Where(x => x.CreatedDate >= startedDate && x.CreatedDate < endedDate).Count(); // 1. ayın sprintlerini say
                datas.Add(data); // sprint sayısını listeye ekle
            }

            return datas;
        }
        public async Task<int> GetTotalSprintCount()
        {
            var sprintCount = await unitOfWork.GetRepository<Sprint>().CountAsync();
            return sprintCount;
        }
        public async Task<int> GetTotalFunctionCount()
        {
            var functionCount = await unitOfWork.GetRepository<Function>().CountAsync();
            return functionCount;
        }

        public async Task<int> GetTotalParameterCount()
        {
            var parameterCount = await unitOfWork.GetRepository<Parameter>().CountAsync();
            return parameterCount;
        }
    }
}
