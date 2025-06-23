namespace Cophana.Import.Domain
{
    public class SalesOrderLine
    {
        public string ItemCode { get; set; }
        public decimal Quantity { get; set; }
        public string BatchNumber { get; set; }
        public string FilePath { get; set; }

        public SalesOrderLine(string itemCode, decimal quantity, string batchNumber, string filePath)
        {
            this.ItemCode = itemCode;
            this.Quantity = quantity;
            this.BatchNumber = batchNumber;
            this.FilePath = filePath;
        }


    }
}
