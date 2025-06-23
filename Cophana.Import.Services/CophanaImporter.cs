using Cophana.Import.Services.Interface;
using MassTransit;
using MassTransit.Transports;
using Microsoft.Extensions.Configuration;
using Cophana.Import.Domain;
using Microsoft.Extensions.Logging;

namespace Cophana.Import.Services
{
    public class CophanaImporter: ICophanaImporter
    {

        private readonly DateTime _lastRunTime;
        private readonly string _folderPath;
        private readonly ILogger<ICophanaImporter> _logger;
        private readonly IPublishEndpoint _publishEndpoint;
        private List<SalesOrderLine> _salesOrderLines = new List<SalesOrderLine>();


        private readonly Guid _orderedBy;
        private readonly Guid _warehouse;
        private readonly Guid _locationId;
        private readonly string _division;
        public CophanaImporter(IConfiguration configuration, ILogger<ICophanaImporter> logger, IPublishEndpoint publishEndpoint)
        {
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));
            _folderPath = configuration["CophanaImport:FolderPath"] ?? throw new ArgumentException("Folder path not configured.");
            _orderedBy = new Guid(configuration["CophanaImport:OrderedBy"]);
            _warehouse = new Guid(configuration["CophanaImport:Warehouse"]);
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
            _locationId = new Guid(configuration["CophanaImport:LocationId"]);
            _division = configuration["CophanaImport:Division"];
            _logger.LogInformation("CophanaImporter constructed. Folder path: {FolderPath}", _folderPath);
        }

        public FileInfo GetLatestFile()
        {
            return new DirectoryInfo(_folderPath)
                .GetFiles("*.txt")
                .OrderByDescending(f => f.LastWriteTime)
                .FirstOrDefault() ?? throw new FileNotFoundException("No files found in the specified directory.");
        }

        public Task ImportOrderConfirmation(FileInfo orderConfirmationFile, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task CreateSalesOrder(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
