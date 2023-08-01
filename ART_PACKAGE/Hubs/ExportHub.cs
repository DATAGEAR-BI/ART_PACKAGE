using ART_PACKAGE.Areas.Identity.Data;
using CsvHelper;
using CsvHelper.Configuration;
using Data.Data;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;
using System.Globalization;

namespace ART_PACKAGE.Hubs
{
    public class ExportHub : Hub
    {
        public static ConcurrentDictionary<string, string> Connections = new();
        private readonly AuthContext dbfcfkc;

        public ExportHub(AuthContext dbfcfkc)
        {
            this.dbfcfkc = dbfcfkc;
        }
        public IEnumerable<ArtAmlAlertDetailView> GetLargeDataSetInBatches(int batchSize)
        {
            Microsoft.EntityFrameworkCore.DbSet<ArtAmlAlertDetailView> data = dbfcfkc.ArtAmlAlertDetailViews;
            int totalRecords = data.Count();
            // Implement your data retrieval logic here, fetching data in chunks of 'batchSize'
            // For example, you could use database queries with pagination.
            // Ensure that each batch is efficiently streamed and not loading all data at once.
            // Return each batch of data as an IEnumerable<YourDataClass>.
            // You may need to adjust the logic based on your specific data source.
            // This is just a basic example:
            for (int i = 0; i < totalRecords; i += batchSize)
            {
                IQueryable<ArtAmlAlertDetailView> batch = data.Skip(i * batchSize).Take(batchSize);
                foreach (ArtAmlAlertDetailView? item in batch)
                {
                    yield return item;
                }
            }
        }

        public async Task ExportAlertDetails()
        {
            Microsoft.EntityFrameworkCore.DbSet<ArtAmlAlertDetailView> data = dbfcfkc.ArtAmlAlertDetailViews;
            int totalRecords = data.Count();
            CsvConfiguration csvConfig = new(CultureInfo.InvariantCulture)
            {
                Delimiter = ",",
                HasHeaderRecord = true, // Set this to false if you don't want a header row
            };
            try
            {

                while (totalRecords > 0)
                {
                    MemoryStream stream = new();
                    using StreamWriter writer = new(stream);
                    using (CsvWriter csv = new(writer, csvConfig))
                    {
                        csv.WriteRecords(GetLargeDataSetInBatches(1000));
                        byte[] bytes = stream.ToArray();
                        await Clients.Client(Connections[Context.User.Identity.Name])
                            .SendAsync("csvRecevied", bytes);
                        writer.AutoFlush = true;
                        stream.Position = 0;

                    }
                    totalRecords -= 1000;
                }
            }
            catch (Exception)
            {

                throw;
            }


        }

        public override Task OnConnectedAsync()
        {

            string? user = Context.User.Identity.Name;

            _ = Connections.AddOrUpdate(user, Context.ConnectionId, (key, oldValue) => Context.ConnectionId);

            return base.OnConnectedAsync();
        }
    }
}
