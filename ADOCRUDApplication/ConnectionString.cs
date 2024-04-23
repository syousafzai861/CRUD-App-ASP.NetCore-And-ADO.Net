using System.Data.Common;

namespace ADOCRUDApplication
{
    public static class ConnectionString
    {
        private static string cs = "Server=DESKTOP-0BKABNV; Database=CrudADOdb; Trusted_Connection=True;";
        public static string dbcs { get => cs; }
    }
}
