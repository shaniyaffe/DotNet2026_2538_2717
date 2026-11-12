using DalFacade.Do;

namespace Dal;

internal static class DataSource
{
    internal static List<Customer?> Customers =new List<Customer?>();
    internal static List<Product?> Products = new List<Product?>();
    internal static List<Sale?> Sales = new List<Sale?>();

    internal static class Config
    {
        internal const int StartProductId = 100000;
        private static int nextProductId = StartProductId;

        internal static int NextProductId
        {
            get
            {
                return nextProductId++;
            }
        }

        internal const int StartSaleId = 1;
        private static int nextSaleId = StartSaleId;

        internal static int NextSaleId
        {
            get
            {
                return nextSaleId++;
            }
        }
    }
}