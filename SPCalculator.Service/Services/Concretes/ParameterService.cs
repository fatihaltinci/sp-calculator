using AutoMapper;
using SPCalculator.Data.UnitOfWorks;
using SPCalculator.Entity.Entities;
using SPCalculator.Entity.Models.Parameters;
using SPCalculator.Service.Services.Abstractions;

namespace SPCalculator.Service.Services.Concretes
{
    public class ParameterService : IParameterService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ParameterService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        async Task<List<ParameterModel>> IParameterService.GetParameters()
        {
            var parameters = await unitOfWork.GetRepository<Parameter>().GetAllAsync(x => !x.IsDeleted); // x => !x.IsDeleted && x.IsActive (duruma göre silinmemiş veya silinmiş olanları getirmek için)
            var map = mapper.Map<List<ParameterModel>>(parameters);

            return map;
        }
        async Task IParameterService.CreateParameterAsync(ParameterAddModel parameterAddModel)
        {
            var newId = Guid.NewGuid();
            Parameter parameter = new Parameter
            {
                Id = newId,
                ParameterName = parameterAddModel.ParameterName,
                ParameterDesc = parameterAddModel.ParameterDesc,
                ParameterPoint = parameterAddModel.ParameterPoint,
                CreatedDate = DateTime.Now,
                IsDeleted = false
            };

            await unitOfWork.GetRepository<Parameter>().AddAsync(parameter);
            await unitOfWork.SaveAsync();
        }

        public async Task<ParameterModel> GetParameterAsync(Guid id) // Bir veri dön
        {
            var parameter = await unitOfWork.GetRepository<Parameter>().GetAsync(x => !x.IsDeleted && x.Id == id); // Nesne olarak Parametre verince methodlara erişebiliyoruz. GetAsync ile Id'ye göre getiriyoruz.
            var map = mapper.Map<ParameterModel>(parameter); // Parametre nesnesini ParametreModel nesnesine map'ledik

            return map;

        }

        public async Task<List<ParameterModel>> GetDeletedParametersAsync() // Tüm verileri dön
        {
            var parameters = await unitOfWork.GetRepository<Parameter>().GetAllAsync(x => x.IsDeleted); // Nesne olarak Parametre verince methodlara erişebiliyoruz. GetAllAsync ile tüm verileri getiriyoruz.
            var map = mapper.Map<List<ParameterModel>>(parameters); // Parametre nesnesini ParametreModel nesnesine map'ledik

            return map;
        }

        public async Task<string> UpdateParameterAsync(ParameterUpdateModel ParameterUpdateModel)
        {
            var parameter = await unitOfWork.GetRepository<Parameter>().GetAsync(x => !x.IsDeleted && x.Id == ParameterUpdateModel.Id); // Nesne olarak Parametre verince methodlara erişebiliyoruz. GetAsync ile Id'ye göre getiriyoruz.

            parameter.ParameterName = ParameterUpdateModel.ParameterName;
            parameter.ParameterDesc = ParameterUpdateModel.ParameterDesc;
            parameter.ParameterPoint = ParameterUpdateModel.ParameterPoint;
            parameter.UpdatedDate = DateTime.Now; // Güncelleme tarihi Update edildiğinde otomatik olarak güncellenecek

            await unitOfWork.GetRepository<Parameter>().UpdateAsync(parameter); // Parametre nesnesini güncelledik
            await unitOfWork.SaveAsync(); // Değişiklikleri kaydettik

            return parameter.ParameterName; // Güncellenen parametre'nin adını döndürdük
        }

        public async Task<string> SafeDeleteParameterAsync(Guid id)
        {
            var parameter = await unitOfWork.GetRepository<Parameter>().GetByIdAsync(id);
            parameter.IsDeleted = true;
            parameter.DeletedDate = DateTime.Now;


            await unitOfWork.GetRepository<Parameter>().UpdateAsync(parameter);
            await unitOfWork.SaveAsync();

            return parameter.ParameterName;
        }

        public async Task<string> UndoDeleteParameterAsync(Guid id)
        {
            var parameter = await unitOfWork.GetRepository<Parameter>().GetByIdAsync(id);
            parameter.IsDeleted = false;
            parameter.DeletedDate = null;

            await unitOfWork.GetRepository<Parameter>().UpdateAsync(parameter);
            await unitOfWork.SaveAsync();

            return parameter.ParameterName;
        }
    }
}
