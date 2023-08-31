using AutoMapper;
using SPCalculator.Data.UnitOfWorks;
using SPCalculator.Entity.Entities;
using SPCalculator.Entity.Models.Functions;
using SPCalculator.Service.Services.Abstractions;

namespace SPCalculator.Service.Services.Concretes
{
    public class FunctionService : IFunctionService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public FunctionService(IUnitOfWork unitOfWork, IMapper mapper) 
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        async Task<List<FunctionModel>> IFunctionService.GetFunctions()
        {
            var functions = await unitOfWork.GetRepository<Function>().GetAllAsync(x => !x.IsDeleted); // x => !x.IsDeleted && x.IsActive (duruma göre silinmemiş veya silinmiş olanları getirmek için)
            var map = mapper.Map<List<FunctionModel>>(functions);

            return map;
        }
        async Task IFunctionService.CreateFunctionAsync(FunctionAddModel functionAddModel)
        {
            var newId = Guid.NewGuid();
            Function function = new Function
            {
                Id = newId,
                FunctionName = functionAddModel.FunctionName,
                CreatedDate = DateTime.Now,
                IsDeleted = false
            };

            await unitOfWork.GetRepository<Function>().AddAsync(function);
            await unitOfWork.SaveAsync();
        }

        public async Task<FunctionModel> GetFunctionAsync(Guid id) // Bir veri dön
        {
            var function = await unitOfWork.GetRepository<Function>().GetAsync(x => !x.IsDeleted && x.Id == id); // Nesne olarak Fonksiyon verince methodlara erişebiliyoruz. GetAsync ile Id'ye göre getiriyoruz.
            var map = mapper.Map<FunctionModel>(function); // Fonksiyon nesnesini FonksiyonModel nesnesine map'ledik

            return map;

        }

        public async Task<List<FunctionModel>> GetDeletedFunctionsAsync() // Silinmiş tüm verileri dön
        {
            var functions = await unitOfWork.GetRepository<Function>().GetAllAsync(x => x.IsDeleted); // Nesne olarak Fonksiyon verince methodlara erişebiliyoruz. GetAllAsync ile tüm verileri getiriyoruz.
            var map = mapper.Map<List<FunctionModel>>(functions); // Fonksiyon nesnesini FonksiyonModel nesnesine map'ledik

            return map;
        }

        public async Task<string> UpdateFunctionAsync(FunctionUpdateModel functionUpdateModel)
        {
            var function = await unitOfWork.GetRepository<Function>().GetAsync(x => !x.IsDeleted && x.Id == functionUpdateModel.Id); // Nesne olarak Fonksiyon verince methodlara erişebiliyoruz. GetAsync ile Id'ye göre getiriyoruz.

            function.FunctionName = functionUpdateModel.FunctionName;
            function.UpdatedDate = DateTime.Now; // Güncelleme tarihi Update edildiğinde otomatik olarak güncellenecek

            await unitOfWork.GetRepository<Function>().UpdateAsync(function); // Fonksiyon nesnesini güncelledik
            await unitOfWork.SaveAsync(); // Değişiklikleri kaydettik

            return function.FunctionName; // Güncellenen fonksiyon'un adını döndürdük
        }

        public async Task<string> SafeDeleteFunctionAsync(Guid id)
        {
            var function = await unitOfWork.GetRepository<Function>().GetByIdAsync(id);
            function.IsDeleted = true;
            function.DeletedDate = DateTime.Now;


            await unitOfWork.GetRepository<Function>().UpdateAsync(function);
            await unitOfWork.SaveAsync();

            return function.FunctionName;
        }

        public async Task<string> UndoDeleteFunctionAsync(Guid id)
        {
            var function = await unitOfWork.GetRepository<Function>().GetByIdAsync(id);
            function.IsDeleted = false;
            function.DeletedDate = null;

            await unitOfWork.GetRepository<Function>().UpdateAsync(function);
            await unitOfWork.SaveAsync();

            return function.FunctionName;
        }
    }
}
