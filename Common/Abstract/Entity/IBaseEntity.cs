using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Abstract.Entity
{
    public interface IBaseEntity
    {
        Guid Id { get; set; }
        string? CreatedAt { get; set; }
        DateTime? CreatedDate { get; set; }
        string? UpdateAt { get; set; }
        DateTime? UpdateDate { get; set; }
    }
}
