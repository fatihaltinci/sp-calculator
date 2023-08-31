using SPCalculator.Entity.Models.Functions;

namespace SPCalculator.Service.Services.Abstractions
{
    public interface IFunctionService
    {
        Task<List<FunctionModel>> GetFunctions(); // Tüm fonksiyonların listesini döndürecek
        Task<List<FunctionModel>> GetDeletedFunctionsAsync(); // Silinen fonksiyonların listesini döndürecek (IsDeleted = true)
        Task CreateFunctionAsync(FunctionAddModel functionAddModel); // FunctionAddModel içerisinde gelen fonksiyonu oluşturacak
        Task<FunctionModel> GetFunctionAsync(Guid id); // FunctionModel içerisindeki Id ile fonksiyon bulunacak
        Task<string> UpdateFunctionAsync(FunctionUpdateModel functionUpdateModel); // FunctionUpdateModel içerisindeki Id ile güncelleme yapılacak fonksiyon bulunacak
        Task<string> SafeDeleteFunctionAsync(Guid id); // id ile fonksiyon bulunacak ve silinecek
        Task<string> UndoDeleteFunctionAsync(Guid id); // id ile fonksiyon bulunacak ve geri alınacak (IsDeleted = false)
    }
}
