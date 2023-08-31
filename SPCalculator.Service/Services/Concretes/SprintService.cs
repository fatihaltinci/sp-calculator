using AutoMapper;
using SPCalculator.Data.UnitOfWorks;
using SPCalculator.Entity.Models.Sprints;
using SPCalculator.Entity.Entities;
using SPCalculator.Service.Services.Abstractions;
using Microsoft.VisualBasic;
using Microsoft.EntityFrameworkCore;

namespace SPCalculator.Service.Services.Concretes
{
    public class SprintService : ISprintService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public SprintService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<List<SprintModel>> GetAllSprintsAsync() // Liste al
        {
            var sprints = await unitOfWork.GetRepository<Sprint>().GetAllAsync(x => !x.IsDeleted, x=>x.Function, y => y.Parameter); // Nesne olarak Sprint verince methodlara erişebiliyoruz.
            var map = mapper.Map<List<SprintModel>>(sprints); // Sprint nesnesini SprintModel nesnesine map'ledik

            return map;
            
        }

        public async Task<SprintModel> GetSprintAsync(Guid id) // Bir veri dön
        {
            var sprint = await unitOfWork.GetRepository<Sprint>().GetAsync(x => !x.IsDeleted && x.Id == id, x => x.Function, y => y.Parameter); // Nesne olarak Sprint verince methodlara erişebiliyoruz. GetAsync ile Id'ye göre getiriyoruz.
            var map = mapper.Map<SprintModel>(sprint); // Sprint nesnesini SprintModel nesnesine map'ledik

            return map;

        }

        public async Task<string> UpdateSprintAsync(SprintUpdateModel sprintUpdateModel)
        {
            var sprint = await unitOfWork.GetRepository<Sprint>().GetAsync(x => !x.IsDeleted && x.Id == sprintUpdateModel.Id, x => x.Function, y => y.Parameter); // Nesne olarak Sprint verince methodlara erişebiliyoruz. GetAsync ile Id'ye göre getiriyoruz.
            
            sprint.SprintName = sprintUpdateModel.SprintName;
            sprint.VersionInfo = sprintUpdateModel.VersionInfo;
            sprint.ItemNo = sprintUpdateModel.ItemNo;
            sprint.DifficultyLevel = sprintUpdateModel.DifficultyLevel != null ? sprintUpdateModel.DifficultyLevel : ""; // null ise boş string atayın
            sprint.FunctionId = sprintUpdateModel.FunctionId;
            sprint.ParameterId = sprintUpdateModel.ParameterId;
            sprint.BasePoint = sprintUpdateModel.BasePoint;
            sprint.UpdatedDate = DateTime.Now; // Güncelleme tarihi Update edildiğinde otomatik olarak güncellenecek

            await unitOfWork.GetRepository<Sprint>().UpdateAsync(sprint); // Sprint nesnesini güncelledik
            await unitOfWork.SaveAsync(); // Değişiklikleri kaydettik

            return sprint.SprintName; // Güncellenen sprint'in adını döndürdük
        }

        async Task ISprintService.CreateSprintAsync(SprintAddModel sprintAddModel)
        {
            var newId = Guid.NewGuid();
            var functionId = sprintAddModel.FunctionId;
            var parameterId = sprintAddModel.ParameterId;
            var sprint = new Sprint // Sprint'e parametre olarak da verebiliriz.
            {
                SprintName = sprintAddModel.SprintName,
                VersionInfo = sprintAddModel.VersionInfo,
                ItemNo = sprintAddModel.ItemNo,
                DifficultyLevel = sprintAddModel.DifficultyLevel != null ? sprintAddModel.DifficultyLevel : "", // null ise boş string atayın
                FunctionId = sprintAddModel.FunctionId,
                ParameterId = sprintAddModel.ParameterId,
                BasePoint = sprintAddModel.BasePoint,
                Id = newId
            };

            sprint.SprintFunctions.Add(new SprintFunction { SprintId = newId, FunctionId = functionId });
            sprint.SprintParameters.Add(new SprintParameter { SprintId = newId, ParameterId = parameterId });

            await unitOfWork.GetRepository<Sprint>().AddAsync(sprint);
            await unitOfWork.SaveAsync();
        }

        public async Task<string> SafeDeleteSprintAsync(Guid id)
        {
            var sprint = await unitOfWork.GetRepository<Sprint>().GetByIdAsync(id);
            sprint.IsDeleted = true;
            sprint.DeletedDate = DateTime.Now;


            await unitOfWork.GetRepository<Sprint>().UpdateAsync(sprint);
            await unitOfWork.SaveAsync();

            return sprint.SprintName;
        }

        public async Task<List<SprintModel>> GetAllDeletedSprintsAsync()
        {
            var sprints = await unitOfWork.GetRepository<Sprint>().GetAllAsync(x => x.IsDeleted, x => x.Function, y => y.Parameter); // Nesne olarak Sprint verince methodlara erişebiliyoruz.
            var map = mapper.Map<List<SprintModel>>(sprints); // Sprint nesnesini SprintModel nesnesine map'ledik

            return map;
        }

        public async Task<string> UndoDeleteSprintAsync(Guid id)
        {
            var sprint = await unitOfWork.GetRepository<Sprint>().GetByIdAsync(id);
            sprint.IsDeleted = false;
            sprint.DeletedDate = null;


            await unitOfWork.GetRepository<Sprint>().UpdateAsync(sprint);
            await unitOfWork.SaveAsync();

            return sprint.SprintName;
        }

        public async Task<int> CalculateTotalPointsAsync(Guid[] sprintIds)
        {
            // SprintId değerlerine sahip Sprintlerin ParameterId'lerini aldık
            var sprintParameters = await unitOfWork.GetRepository<SprintParameter>()
                                                  .GetAllAsync(sp => sprintIds.Contains(sp.SprintId));

            var parameterIds = sprintParameters.Select(sp => sp.ParameterId).ToArray();

            // ParameterId'lerine sahip Parameterlerin ParameterPoint değerlerini aldık
            var parameters = await unitOfWork.GetRepository<Parameter>()
                                              .GetAllAsync(p => parameterIds.Contains(p.Id));

            // Parametrelerin ParameterPoint değerlerini toplayıp toplam puanı hesapladık
            int totalPoints = parameters.Sum(p => p.ParameterPoint);

            return totalPoints;
        }

        public async Task<List<SprintDetailsModel>> GetSprintDetailsAsync(Guid[] sprintIds)
        {
            List<SprintDetailsModel> sprintDetailsList = new List<SprintDetailsModel>();

            var sprints = await unitOfWork.GetRepository<Sprint>().GetAllAsync(sp => sprintIds.Contains(sp.Id));

            foreach (var sprint in sprints)
            {
                var sprintFunctions = await unitOfWork.GetRepository<SprintFunction>().GetAllAsync(sf => sf.SprintId == sprint.Id);
                var sprintParameters = await unitOfWork.GetRepository<SprintParameter>().GetAllAsync(sp => sp.SprintId == sprint.Id);

                var functionIds = sprintFunctions.Select(sf => sf.FunctionId).ToArray();
                var parameterIds = sprintParameters.Select(sp => sp.ParameterId).ToArray();

                var functions = await unitOfWork.GetRepository<Function>().GetAllAsync(f => functionIds.Contains(f.Id));
                var parameters = await unitOfWork.GetRepository<Parameter>().GetAllAsync(p => parameterIds.Contains(p.Id));

                var sprintDetails = new SprintDetailsModel
                {
                    SprintName = sprint.SprintName,
                    VersionInfo = sprint.VersionInfo,
                    ItemNo = sprint.ItemNo,
                    DifficultyLevel = sprint.DifficultyLevel,
                    FunctionName = functions.Select(f => f.FunctionName).FirstOrDefault(),
                    ParameterName = parameters.Select(p => p.ParameterName).FirstOrDefault(),
                    ParameterDesc = parameters.Select(p => p.ParameterDesc).FirstOrDefault()
                };

                sprintDetailsList.Add(sprintDetails);
            }

            return sprintDetailsList;
        }


    }
}
