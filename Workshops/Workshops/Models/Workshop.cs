using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workshops.Models
{
    public class Workshop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Status State { get; set; }
    }

    public enum Status
    {
        SCHEDULED,
        POSPONED,
        CANCELLED
    }

}
