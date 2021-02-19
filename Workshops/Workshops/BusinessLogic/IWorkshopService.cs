using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workshops.Models;

namespace Workshops.BusinessLogic
{
    public interface IWorkshopService
    {
        public IEnumerable<Workshop> GetAllWorkshops();
        public Workshop GetWorkshopById(int workshopId);
        public Workshop CreateWorkshop(Workshop workshop);
        public Workshop UpdateWorkshop(int workshopId, Workshop workshop);
        public bool DeleteWorkshop(int workshopId);
        public Workshop PosponeWorkshop(int workshopId);
        public Workshop CancelWorkshop(int workshopId);
    }
}
