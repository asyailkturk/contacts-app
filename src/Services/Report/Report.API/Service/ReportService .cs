﻿

using Report.API.Entities;
using Report.API.Repository;
using Report.API.Models;
using Report.API.Service.Interfaces;
using System.Linq;
using System.Runtime.CompilerServices;
using MassTransit;
using EventBus.Messages.Events;
using Report.API.EventBusEvent;

namespace Report.API.Service
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;
        private readonly IContactService _contactService;
        private readonly IGoogleSheetService _googleService;
        private readonly IPublishEndpoint _publishEndpoint;
        const string URL = @"https://docs.google.com/spreadsheets/d/11qqVJ0rZXONJP-QCBxs5S_u5DuxIG8dctRCAPDPsJJE/edit#gid=0";
        public ReportService(IReportRepository reportRepository,
                             IContactService contactService,
                             IGoogleSheetService googleService,
                             IPublishEndpoint publishEndpoint)
        {
            _reportRepository = reportRepository;
            _contactService = contactService;
            _googleService = googleService; 
            _publishEndpoint = publishEndpoint;
        }
        public async Task CreateReportRequest()
        {

           var report = await AddReportResult();

           var contacts = await _contactService.GetData();

            await _publishEndpoint.Publish<ReportCreateEvent>( new ReportCreateEvent
            {
                Contacts = contacts,
                Report= report,
            });
           
        }

        public async Task CreateReport( ReportCreateEvent? context = null)
        {
            
            var report = context.Report ?? await AddReportResult();
            var contacts = context.Contacts ?? await _contactService.GetData();

            var data = await PrepareDatas(contacts);

            var title = await _googleService.AddDatas(data);

            report.ReportUrl = URL;
            report.Title = title;
            report.Status = Status.Done;
            report.CreatedDate = context.CreationDate;
            report.QueueId = context.Id.ToString();

            await UpdateReportResult(report);

        }

        public Task<List<ReportResult>> GetAsync()
        {
            return _reportRepository.GetAsync();
        }

        public Task<ReportResult?> GetAsync(string id)
        {
            return  _reportRepository.GetAsync(id);
        }


       private async Task<List<ReportData>> PrepareDatas (List<GetContactsResponseModel> contactResponseList)
        {
            var responseList = new List<ReportData>();
            foreach (var contact in contactResponseList)
            {
                var item = responseList.FindIndex(x => x.Location == contact.CommunicationInfo.Where(x => x.InfoType == CommunationInfoType.Location).FirstOrDefault().Detail);
                if (item != -1)
                {

                    responseList[item].ContactCount = (Convert.ToInt32(responseList[item].ContactCount) + 1).ToString();
                    responseList[item].PhoneNumberCount = contact.CommunicationInfo.Any(x => x.InfoType == CommunationInfoType.PhoneNumber) ? 
                        (Convert.ToInt32(responseList[item].PhoneNumberCount) +1).ToString() : responseList[item].PhoneNumberCount;

                }
                else
                {
                    responseList.Add(new ReportData
                    {
                        ContactCount = "1",
                        Location = contact.CommunicationInfo.Where(x => x.InfoType == CommunationInfoType.Location).FirstOrDefault().Detail,
                        PhoneNumberCount = contact.CommunicationInfo.Any(x => x.InfoType == CommunationInfoType.PhoneNumber) ? "1" :"0",
                    });

                }
            }
            return responseList;

        }    
     
      private async Task UpdateReportResult(ReportResult result)
        {
            await _reportRepository.UpdateAsync(result);
        }
        private async Task<ReportResult> AddReportResult()
        {
           
           return  await _reportRepository.CreateAsync( new ReportResult
            {
                Status = Status.Prepraring,
            });
        }
    }
}