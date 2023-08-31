using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPCalculator.Entity.Models.Functions
{
    public class FunctionModel // DTO (Data Transfer Object) - Veri aktarım nesnesi
    {
        public Guid Id { get; set; }
        public string FunctionName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
