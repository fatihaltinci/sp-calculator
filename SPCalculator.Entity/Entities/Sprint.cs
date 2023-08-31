using SPCalculator.Core.Entities;

namespace SPCalculator.Entity.Entities
{
    public class Sprint : EntityBase
    {

        public Sprint()
        {
            SprintFunctions = new List<SprintFunction>();
            SprintParameters = new List<SprintParameter>();
        }

        public Sprint(string sprintName, string versionInfo, string itemNo, string difficultyLevel, double basePoint, Guid parameterId, Guid functionId)
        {
            SprintName = sprintName;
            VersionInfo = versionInfo;
            ItemNo = itemNo;
            DifficultyLevel = difficultyLevel;
            BasePoint = basePoint;
            ParameterId = parameterId;
            FunctionId = functionId;
        }

        public string SprintName { get; set; }
        public string VersionInfo { get; set; }
        public string ItemNo { get; set; }
        public string DifficultyLevel { get; set; } 
        public double? BasePoint { get; set; }


        public Guid ParameterId { get; set; } // İlişkili Parametreler ilişkisi için
        public Parameter? Parameter { get; set; } // İlişkili Parametreler ilişkisi için (Nullable)

        public Guid FunctionId { get; set; } // Ana İş Tanımı ilişkisi için
        public Function Function { get; set; } // Ana İş Tanımı ilişkisi için

        // Çoka çok ilişki için ICollection kullanıyoruz
        public ICollection<SprintFunction> SprintFunctions { get; set; }
        public ICollection<SprintParameter> SprintParameters { get; set; }
    }
}
