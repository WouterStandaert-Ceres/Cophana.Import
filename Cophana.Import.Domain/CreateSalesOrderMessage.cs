using Cophana.Import.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Exact.Export.Consumers.ConsumerMessages;

public class CreateSalesOrderMessage
{
    public Guid OrderedBy { get; set; }
    public Guid WarehouseID { get; set; }
    public Guid LocationID { get; set; }
    public DateTime OrderDate { get; set; }
    public string Description { get; set; }
    public string Division { get; set; }

    public List<SalesOrderLine> SalesOrderLines { get; set; }

    public CreateSalesOrderMessage(List<SalesOrderLine> SalesOrderLines, Guid OrderedBy, DateTime OrderDate, string Description, Guid WarehouseID, Guid LocationID
        , string Division)
    {
        this.SalesOrderLines = SalesOrderLines;
        this.OrderedBy = OrderedBy;
        this.OrderDate = OrderDate;
        this.Description = Description;
        this.WarehouseID = WarehouseID;
        this.LocationID = LocationID;
        this.Division = Division;
    }
}

