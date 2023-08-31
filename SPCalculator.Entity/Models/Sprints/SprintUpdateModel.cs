using SPCalculator.Entity.Models.Functions;
using SPCalculator.Entity.Models.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPCalculator.Entity.Models.Sprints
{
    public class SprintUpdateModel // DTO (Data Transfer Object) - Veri aktarım nesnesi
    {
        public Guid Id { get; set; }
        public string SprintName { get; set; }
        public string VersionInfo { get; set; }
        public string ItemNo { get; set; }
        public string DifficultyLevel { get; set; }
        public double? BasePoint { get; set; } = 0;
        public DateTime UpdatedDate { get; set; } // Güncelleme tarihi Update edildiğinde otomatik olarak güncellenecek
        public Guid FunctionId { get; set; }
        public Guid ParameterId { get; set; }
        public IList<FunctionModel> Functions { get; set; } // Function Model sınıfındaki isimlerden oluşan liste
        public IList<ParameterModel> Parameters { get; set; } // Parameter Model sınıfındaki isimlerden oluşan liste

    }
}
