using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cophana.Import.Services.Interface
{
    public interface ICophanaImporter
    {
        FileInfo GetLatestFile();

        Task ImportOrderConfirmation(FileInfo orderConfirmationFile, CancellationToken cancellationToken);
        Task CreateSalesOrder(CancellationToken cancellationToken);


    }
}
