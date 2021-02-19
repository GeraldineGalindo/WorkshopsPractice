﻿using System;
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
        public Workshop CancelWorkshop(int workshopId)
        {
            var workshopToCancel = workshops.SingleOrDefault(w => w.Id == workshopId);
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
            return workshops.Remove(workshopToDelete);
        }

        public IEnumerable<Workshop> GetAllWorkshops()
        {
            return workshops;
        }

        public Workshop GetWorkshopById(int workshopId)
        {
            return workshops.SingleOrDefault(w => w.Id == workshopId);
        }

        public Workshop PosponeWorkshop(int workshopId)
        {
            var workshopToPospone = workshops.SingleOrDefault(w => w.Id == workshopId);
            workshopToPospone.State = Status.POSPONED;
            return workshopToPospone;
        }

        public Workshop UpdateWorkshop(int workshopId, Workshop workshop)
        {
            var workshopToUpdate = workshops.SingleOrDefault(w => w.Id == workshopId);
            workshopToUpdate.Name = workshop.Name;
            workshopToUpdate.State = workshop.State;
            return workshopToUpdate;
        }
    }
}
