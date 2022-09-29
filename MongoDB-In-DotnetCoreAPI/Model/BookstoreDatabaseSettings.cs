using MongoDB_In_DotnetCoreAPI.Model.interfaces;

namespace MongoDB_In_DotnetCoreAPI.Model
{
    public class BookstoreDatabaseSettings : IBookstoreDatabaseSettings
    {
        public string BooksCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
