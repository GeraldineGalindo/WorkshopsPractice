using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workshops.Exceptions;
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
        public Workshop CancelWorkshop(int workshopId)
        {
            var workshopToCancel = workshops.SingleOrDefault(w => w.Id == workshopId);
            if(workshopToCancel == null)
            {
                throw new NotFoundItemException("The workshop was not found");
            }
            workshopToCancel.State = Status.CANCELLED;
            return workshopToCancel;
        }

        public Workshop CreateWorkshop(Workshop workshop)
        {
            var nextId = workshops.Count == 0 ? 1 : workshops.Last().Id + 1;
            workshop.Id = nextId;
            workshop.State = Status.SCHEDULED;
            workshops.Add(workshop);
            return workshop;
        }

        public bool DeleteWorkshop(int workshopId)
        {
            var workshopToDelete = workshops.SingleOrDefault(w => w.Id == workshopId);
            if (workshopToDelete == null)
            {
                throw new NotFoundItemException("The workshop was not found");
            }
            return workshops.Remove(workshopToDelete);
        }

        public IEnumerable<Workshop> GetAllWorkshops()
        {
            if(workshops.Count == 0)
            {
                throw new EmptyCollectionException("There are no workshops to show");
            }
            return workshops;
        }

        public Workshop GetWorkshopById(int workshopId)
        {
            var workshop = workshops.SingleOrDefault(w => w.Id == workshopId);
            if (workshop == null)
            {
                throw new NotFoundItemException("The workshop was not found");
            }
            return workshop;
            
        }

        public Workshop PosponeWorkshop(int workshopId)
        {
            var workshopToPospone = workshops.SingleOrDefault(w => w.Id == workshopId);
            if (workshopToPospone == null)
            {
                throw new NotFoundItemException("The workshop was not found");
            }
            workshopToPospone.State = Status.POSPONED;
            return workshopToPospone;
        }

        public Workshop UpdateWorkshop(int workshopId, Workshop workshop)
        {
            var workshopToUpdate = workshops.SingleOrDefault(w => w.Id == workshopId);
            if(workshopId != workshop.Id)
            {
                throw new DataMismatchException("Id from route and workshop do not match");
            }
            if (workshopToUpdate == null)
            {
                throw new NotFoundItemException("The workshop was not found");
            }
            workshopToUpdate.Name = workshop.Name;
            workshopToUpdate.State = workshop.State;
            return workshopToUpdate;
        }
    }
}
