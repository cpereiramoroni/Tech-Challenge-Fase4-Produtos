using App.Domain.Interfaces;
using Mongo2Go;
using MongoDB.Driver;
using System.Collections.Generic;

namespace App.Test.Fixtures
{
    public class Mongo2GoFixture<T> : IMongoDbContext
    {
        public MongoClient Client { get; }

        public IMongoDatabase Database { get; }

        public string ConnectionString { get; }

        private readonly MongoDbRunner _mongoRunner;

        private readonly string _databaseName = "my-database";

        public IMongoCollection<T> Collection { get; }
        public Mongo2GoFixture(List<T> documents)
        {
            // initializes the instance
            _mongoRunner = MongoDbRunner.Start();

            // store the connection string with the chosen port number
            ConnectionString = _mongoRunner.ConnectionString;


            // create a client and database for use outside the class
            Client = new MongoClient(ConnectionString);

            Database = Client.GetDatabase(_databaseName);

            // initialize your collection
            Collection = Database.GetCollection<T>("collection");

            Collection.InsertMany(documents);
        }


        public void Dispose()
        {
            _mongoRunner.Dispose();
        }

        IMongoCollection<T> IMongoDbContext.Collection<T>()
        {
            return (IMongoCollection<T>)this.Collection;
        }

        IMongoCollection<T> IMongoDbContext.Collection<T>(string nameCollection)
        {
            return (IMongoCollection<T>)this.Collection;
        }

        public IMongoDatabase GetDatabase()
        {
            return this.Database;
        }
    }
}
