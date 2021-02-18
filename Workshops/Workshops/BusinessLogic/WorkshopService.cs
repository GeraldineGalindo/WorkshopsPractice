using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workshops.Models;

namespace Workshops.BusinessLogic
{
    public class WorkshopService : IWorkshopService
    {
        private List<Workshop> workshops;

        public WorkshopService()
        {
            workshops = new List<Workshop>();
            workshops.Add(new Workshop { Id = 1, Name = "Training Internal Apps", State = Status.SCHEDULED });
            workshops.Add(new Workshop { Id = 2, Name = "Object Oriented Programming", State = Status.SCHEDULED });
            workshops.Add(new Workshop { Id = 3, Name = "Branching and Modelling", State = Status.SCHEDULED });
        }
        public bool CancelWorkshop(int workshopId)
        {
            throw new NotImplementedException();
        }

        public Workshop CreateWorkshop(Workshop workshop)
        {
            throw new NotImplementedException();
        }

        public bool DeleteWorkshop(int workshopId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Workshop> GetAllWorkshops()
        {
            return workshops;
        }

        public Workshop GetWorkshopById(int workshopId)
        {
            return workshops.SingleOrDefault(w => w.Id == workshopId);
        }

        public bool PosponeWorkshop(int workshopId)
        {
            throw new NotImplementedException();
        }

        public Workshop UpdateWorkshop(Workshop workshop)
        {
            throw new NotImplementedException();
        }
    }
}
