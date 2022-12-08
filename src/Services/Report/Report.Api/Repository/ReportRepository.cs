using Report.API.Data;
using Report.API.Entities;
using MongoDB.Driver;

namespace Report.API.Repository
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

        public async Task<ReportResult> CreateAsync(ReportResult reportResult)
        {
            await _context.ReportResults.InsertOneAsync(reportResult);
            return reportResult;

        }

        public async Task<bool> UpdateAsync(ReportResult reportResult)
        {
            var updateResult = await _context.ReportResults.ReplaceOneAsync(filter: g => g.Id == reportResult.Id, replacement: reportResult);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }
    }
}



