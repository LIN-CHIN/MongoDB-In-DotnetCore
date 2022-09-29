namespace MongoDB_In_DotnetCoreAPI.Model
{
    public class BookstoreDatabaseSettings 
    {
        public string BooksCollectionName { get; private set; }
        public string ConnectionString { get; private set; }
        public string DatabaseName { get; private set; }
    }
}
