using Eindwerk_TintelijnWorkerHelperAlpha.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eindwerk_TintelijnWorkerHelperAlpha.Models
{
    public class WorkInput
    {
        public int WorkInputId { get; set; }

        public DateTime DateWorked { get; set; }

        public int ConstructionSiteId { get; set; }
        public ConstructionSite ConstructionSite { get; set; }


        
        public double HoursWorked { get; set; }
        public double OvertimeHours { get; set; }


        public TransportationToWork TransportationToWork { get; set; }  // ddl
        public double DistanceToWork { get; set; }
        public TransportationToSite TransportationToSite { get; set; }  // ddl
        public double DistanceToSite { get; set; }
    }
}
