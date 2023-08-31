using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPCalculator.Core.Entities
{
    public abstract class EntityBase : IEntityBase
    {
        public virtual Guid Id { get; set; } = Guid.NewGuid(); // Id
        public virtual DateTime CreatedDate { get; set; } = DateTime.Now; // Oluşturulma Tarihi
        public virtual DateTime? UpdatedDate { get; set; } // Güncellenme Tarihi
        public virtual DateTime? DeletedDate { get; set; } // Silinme Tarihi
        public virtual bool IsDeleted { get; set; } = false; // Silindi mi?

        // public string createdBy { get; set; } // Oluşturan Kullanıcı
        // public string? updatedBy { get; set; } // Güncelleyen Kullanıcı
        // public string deletedBy { get; set; } // Silen Kullanıcı
    }
}
