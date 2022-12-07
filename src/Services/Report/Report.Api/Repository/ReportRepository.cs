using Report.Api.Data;
using Report.API.Entities;
using MongoDB.Driver;

namespace Report.Api.Repository
{
    public class ReportRepository : IReportRepository
    {
        private readonly IReportContext _context;


        public ReportRepository(IReportContext context)
        {

            _context = context;
        }

        public async Task<List<ReportResult>> GetAsync() =>
               await _context.ReportResults.Find(_ => true).ToListAsync();

       public async Task<ReportResult?> GetAsync(string id) =>
              await _context.ReportResults.Find(x => x.Id == id).FirstOrDefaultAsync();



    }
}



