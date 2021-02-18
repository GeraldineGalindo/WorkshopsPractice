﻿using System;
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
        public Workshop UpdateWorkshop(Workshop workshop);
        public bool DeleteWorkshop(int workshopId);
        public bool PosponeWorkshop(int workshopId);
        public bool CancelWorkshop(int workshopId);
    }
}