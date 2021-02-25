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
        private List<Workshop> _workshops;

        public WorkshopService()
        {
            _workshops = new List<Workshop>();
            _workshops.Add(new Workshop { Id = 1, Name = "Training Internal Apps", State = Status.SCHEDULED });
            _workshops.Add(new Workshop { Id = 2, Name = "Object Oriented Programming", State = Status.SCHEDULED });
            _workshops.Add(new Workshop { Id = 3, Name = "Branching and Modelling", State = Status.SCHEDULED });
        }
        private Workshop CancelWorkshop(int workshopId)
        {
            var workshopToCancel = _workshops.SingleOrDefault(w => w.Id == workshopId);
            if(workshopToCancel == null)
            {
                throw new NotFoundItemException("The workshop was not found");
            }
            workshopToCancel.State = Status.CANCELLED;
            return workshopToCancel;
        }

        public Workshop CreateWorkshop(Workshop workshop)
        {
            var nextId = _workshops.Count == 0 ? 1 : _workshops.Last().Id + 1;
            workshop.Id = nextId;
            workshop.State = Status.SCHEDULED;
            _workshops.Add(workshop);
            return workshop;
        }

        public bool DeleteWorkshop(int workshopId)
        {
            var workshopToDelete = _workshops.SingleOrDefault(w => w.Id == workshopId);
            if (workshopToDelete == null)
            {
                throw new NotFoundItemException("The workshop was not found");
            }
            return _workshops.Remove(workshopToDelete);
        }

        public IEnumerable<Workshop> GetAllWorkshops()
        {
            if(_workshops.Count == 0)
            {
                throw new EmptyCollectionException("There are no workshops to show");
            }
            return _workshops;
        }

        public Workshop GetWorkshopById(int workshopId)
        {
            var workshop = _workshops.SingleOrDefault(w => w.Id == workshopId);
            if (workshop == null)
            {
                throw new NotFoundItemException("The workshop was not found");
            }
            return workshop;
            
        }

        private Workshop PosponeWorkshop(int workshopId)
        {
            var workshopToPospone = _workshops.SingleOrDefault(w => w.Id == workshopId);
            if (workshopToPospone == null)
            {
                throw new NotFoundItemException("The workshop was not found");
            }
            workshopToPospone.State = Status.POSPONED;
            return workshopToPospone;
        }

        public Workshop UpdateWorkshop(int workshopId, Workshop workshop, string action)
        {
            Workshop result = null;
            if(action == "update")
            {
                result = EditWorkshop(workshopId, workshop);
            }
            if(action == "pospone")
            {
                result = PosponeWorkshop(workshopId);
            }
            if(action == "cancel")
            {
                result = CancelWorkshop(workshopId);
            }
            if(result == null)
            {
                throw new DataMismatchException("Must specify the action to take");
            }
            return result;
        }

        private Workshop EditWorkshop(int workshopId, Workshop workshop)
        {
            var workshopToUpdate = _workshops.SingleOrDefault(w => w.Id == workshopId);
            if (workshopId != workshop.Id)
            {
                throw new DataMismatchException("Id from route and workshop do not match");
            }
            if (workshopToUpdate == null)
            {
                throw new NotFoundItemException("The workshop was not found");
            }
            workshopToUpdate.Name = workshop.Name;
            return workshopToUpdate;
        }
    }
}
