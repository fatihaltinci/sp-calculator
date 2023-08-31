using SPCalculator.Core.Entities;

namespace SPCalculator.Entity.Entities
{
    public class Parameter : EntityBase
    {
        public Parameter()
        {
            
        }

        public Parameter(string parameterName, string parameterDesc, int parameterPoint)
        {
            ParameterName = parameterName;
            ParameterDesc = parameterDesc;
            ParameterPoint = parameterPoint;
        }

        public string ParameterName { get; set; }
        public string ParameterDesc { get; set; }
        public int ParameterPoint { get; set; } // Parametre Puanı

        public ICollection<Sprint> Sprints { get; set; } // Sprint ilişkisi için
        public ICollection<SprintParameter> SprintParameters { get; set; } // Sprint Parametre ilişkisi için
        // public ICollection<Function> Functions { get; set; } // Fonksiyon ilişkisi için
    }
}
