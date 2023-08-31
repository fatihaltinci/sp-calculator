using SPCalculator.Entity.Models.Parameters;

namespace SPCalculator.Service.Services.Abstractions
{
    public interface IParameterService
    {
        Task<List<ParameterModel>> GetParameters(); // Tüm parametrelerin listesini döndürecek
        Task<List<ParameterModel>> GetDeletedParametersAsync(); // Silinen parametrelerin listesini döndürecek (IsDeleted = true)
        Task CreateParameterAsync(ParameterAddModel parameterAddModel); // ParameterAddModel içerisinde gelen parametreyi oluşturacak
        Task<ParameterModel> GetParameterAsync(Guid id); // ParameterModel içerisindeki Id ile parametre bulunacak
        Task<string> UpdateParameterAsync(ParameterUpdateModel parameterUpdateModel); // ParameterUpdateModel içerisindeki Id ile güncelleme yapılacak parametre bulunacak
        Task<string> SafeDeleteParameterAsync(Guid id); // id ile parametre bulunacak ve silinecek
        Task<string> UndoDeleteParameterAsync(Guid id); // id ile parametre bulunacak ve geri alınacak (IsDeleted = false)
    }
}
