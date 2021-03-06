﻿using EventCalendar.Core.Models;
using EventCalendar.Core.Services;
using System.Collections.Generic;
using System.Web.Http;
using Umbraco.Web.Editors;
using Umbraco.Web.Mvc;

namespace EventCalendarBelle.Controller
{
    [PluginController("EventCalendar")]
    public class EventApiController : UmbracoAuthorizedJsonController
    {
        [HttpPost]
        public Event PostSave(Event nevent)
        {
            if (nevent.Id > 0)
            {
                //Update the event
                return EventService.UpdateEvent(nevent);
            }
            else
            {
                //Insert the event
                return EventService.CreateEvent(nevent);
            }
        }

        public int DeleteById(int id)
        {
            return EventService.DeleteEvent(id);
        }

        public Event GetById(int id)
        {
            return EventService.GetEvent(id);
        }

        public IEnumerable<Event> GetAll()
        {
            return EventService.GetAllEvents();
        }

        public IEnumerable<Event> GetForCalendar(int id)
        {
            return EventService.GetEventsForCalendar(id);
        }

        public PagedEventsResult GetPaged(int calendar, int itemsPerPage, int pageNumber, string sortColumn,
            string sortOrder, string searchTerm)
        {
            return EventService.GetPagedEvents(calendar, itemsPerPage, pageNumber, sortColumn, sortOrder, searchTerm);
        }
    }
}
