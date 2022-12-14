using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;

namespace Report.API.Helper
{
    public class GoogleSheetsHelper
    {
        public SheetsService Service { get; set; }

        private const string APPLICATION_NAME = "ContactBook";
        private static readonly string[] Scopes = { SheetsService.Scope.Spreadsheets };

        public GoogleSheetsHelper()
        {
            InitializeService();
        }

        private void InitializeService()
        {
            GoogleCredential credential = GetCredentialsFromFile();
            Service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = APPLICATION_NAME
            });
        }

        private static GoogleCredential GetCredentialsFromFile()
        {
            GoogleCredential credential;
            using (FileStream stream = new("client_secrets.json", FileMode.Open, FileAccess.Read))
            {
                credential = GoogleCredential.FromStream(stream).CreateScoped(Scopes);
            }
            return credential;
        }
    }
}
