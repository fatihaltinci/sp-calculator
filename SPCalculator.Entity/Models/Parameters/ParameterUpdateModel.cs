using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPCalculator.Entity.Models.Parameters
{
    public class ParameterUpdateModel // DTO (Data Transfer Object) - Veri aktarım nesnesi
    {
        public Guid Id { get; set; }
        public string ParameterName { get; set; }
        public string ParameterDesc { get; set; }
        public int ParameterPoint { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
