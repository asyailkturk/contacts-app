using EventBus.Messages.Events;
using Report.API.Entities;
using Report.API.Models;

namespace Report.API.EventBusEvent
{
    //TODO
    //If project gets more complex, move this class to Event Messages class library
    //and map classes with Automapper
    public class ReportCreateEvent : IntegrationBaseEvent
    {
        public ReportResult Report { get; set; }

        public List<GetContactsResponseModel> Contacts { get; set; }
    }
}
