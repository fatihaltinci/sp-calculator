using SPCalculator.Entity.Models.Functions;
using SPCalculator.Entity.Models.Parameters;

namespace SPCalculator.Entity.Models.Sprints
{
    public class SprintModel // Entity sınıfında oluşturulmasının nedeni katmanlar arasındaki referansların tek yönlü olması, DTO (Data Transfer Object) - Veri aktarım nesnesi
    {
        public Guid Id { get; set; }
        public string SprintName { get; set; }
        public string VersionInfo { get; set; }
        public string ItemNo { get; set; }
        public string DifficultyLevel { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public FunctionModel FunctionName { get; set; }
        public ParameterModel ParameterName { get; set; }
        public bool IsDeleted { get; set; }
        public double? BasePoint { get; set; } = 0;
    }
}
