using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstract.Organization
{
    public interface IAnnouncement
    {
        string Subject { get; set; }
        string Type { get; set; }
        DateTime StartDate { get; set; }
        DateTime DateDate { get; set; }
        DateTime LastDate { get; set; }
    }
}
