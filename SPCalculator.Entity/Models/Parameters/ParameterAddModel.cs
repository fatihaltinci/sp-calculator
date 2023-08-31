using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPCalculator.Entity.Models.Parameters
{
    public class ParameterAddModel // DTO (Data Transfer Object) - Veri aktarım nesnesi
    {
        public string ParameterName { get; set; }
        public string ParameterDesc { get; set; }
        public int ParameterPoint { get; set; }

    }
}
