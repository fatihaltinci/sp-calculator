using SPCalculator.Entity.Models.Functions;
using SPCalculator.Entity.Models.Parameters;

namespace SPCalculator.Entity.Models.Sprints
{
    public class SprintAddModel // DTO (Data Transfer Object) - Veri aktarım nesnesi
    {
        public string SprintName { get; set; }
        public string VersionInfo { get; set; }
        public string ItemNo { get; set; }
        public string DifficultyLevel { get; set; }
        public double? BasePoint { get; set; } = 0;
        public Guid FunctionId { get; set; }
        public Guid ParameterId { get; set; }
        public IList<FunctionModel> Functions { get; set; } // Function Model sınıfındaki isimlerden oluşan liste
        public IList<ParameterModel> Parameters { get; set;} // Parameter Model sınıfındaki isimlerden oluşan liste
    }
}
