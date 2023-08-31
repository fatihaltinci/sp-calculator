using SPCalculator.Entity.Entities;
using SPCalculator.Entity.Models.Sprints;

namespace SPCalculator.Service.Services.Abstractions
{
    public interface ISprintService
    {
        Task<List<SprintModel>> GetAllSprintsAsync(); // Tüm sprintlerin listesini döndürecek
        Task<List<SprintModel>> GetAllDeletedSprintsAsync(); // Silinen sprintlerin listesini döndürecek (IsDeleted = true)
        Task CreateSprintAsync(SprintAddModel sprintAddModel); // SprintAddModel içerisinde gelen sprinti oluşturacak
        Task<SprintModel> GetSprintAsync(Guid id); // SprintModel içerisindeki Id ile sprint bulunacak
        Task<string> UpdateSprintAsync(SprintUpdateModel sprintUpdateModel); // SprintUpdateModel içerisindeki Id ile güncelleme yapılacak sprint bulunacak
        Task<string> SafeDeleteSprintAsync(Guid id); // id ile sprint bulunacak ve silinecek
        Task<string> UndoDeleteSprintAsync(Guid id); // id ile sprint bulunacak ve geri alınacak (IsDeleted = false)
        Task<int> CalculateTotalPointsAsync(Guid[] sprintIds); // Sprintlerin Id'leri ile sprintler ve parametreleri bulunacak ve puanları toplanacak
        Task<List<SprintDetailsModel>> GetSprintDetailsAsync(Guid[] sprintIds); // Sprintlerin Id'leri ile sprintler, fonksiyonlar, parametreleri bulunacak ve SprintDetailsModel listesi döndürülecek
    }
}
