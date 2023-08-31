using SPCalculator.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace SPCalculator.Entity.Entities
{
    public class SprintFunction : IEntityBase
    {
        [Key]
        public Guid SprintId { get; set; }
        public Guid FunctionId { get; set; }
        public Sprint Sprint { get; set; }
        public Function Function { get; set; }
    }
}
