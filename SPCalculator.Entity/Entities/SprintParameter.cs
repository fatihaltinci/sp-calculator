using SPCalculator.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace SPCalculator.Entity.Entities
{
    public class SprintParameter : IEntityBase
    {
        [Key]
        public Guid SprintId { get; set; }
        public Sprint Sprint { get; set; }
        public Guid ParameterId { get; set; }
        public Parameter Parameter { get; set; }
    }
}
