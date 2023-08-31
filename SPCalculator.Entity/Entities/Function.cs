using SPCalculator.Core.Entities;
using System.Collections;

namespace SPCalculator.Entity.Entities
{
    public class Function : EntityBase
    {
        public Function()
        {
            
        }

        public Function(string functionName)
        {
            FunctionName = functionName;
        }

        public string FunctionName { get; set; } // Fonksiyon Adı

        public ICollection<Sprint> Sprints { get; set; } // Sprint ilişkisi için
        public ICollection<SprintFunction> SprintFunctions { get; set; } // Sprint Fonksiyon ilişkisi için
        // public ICollection<Parameter> Parameters { get; set; } // Parametre ilişkisi için
    }
}