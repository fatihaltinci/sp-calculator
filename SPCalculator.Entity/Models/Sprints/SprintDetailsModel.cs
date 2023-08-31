using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPCalculator.Entity.Models.Sprints
{
    public class SprintDetailsModel
    {
        public string SprintName { get; set; }
        public string VersionInfo { get; set; }
        public string ItemNo { get; set; }
        public string DifficultyLevel { get; set; }
        public string FunctionName { get; set; }
        public string ParameterName { get; set; }
        public string ParameterDesc { get; set; }
        // public double ParameterPoint { get; set; }
    }
}
