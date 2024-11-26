using App.Domain.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace App.Test._4___Infra._4._1_Data.Repository.Mongo
{
    /// <summary>
    /// mock banco usando findasync com o tempo deve se atualizar novos metodos
    /// </summary>
    public static class MongoDbFakeContext
    {
        public static IAsyncCursor<T> CreateCursor<T>(IList<T> items, FilterDefinition<T> filter)
        {
            var documents = items.ToList();
            var asyncCursor = new Mock<IAsyncCursor<T>>();
            var current = 0;
            var total = documents.Count;

            bool MoveNext()
            {
                current++;
                return current == total;
            }

            asyncCursor.Setup(cursor => cursor.Current).Returns(documents);

            asyncCursor.SetupSequence(cursor => cursor.MoveNext(It.IsAny<CancellationToken>()))
              .Returns(MoveNext);

            return asyncCursor.Object;
        }




        public static IMongoDbContext Create<T>(IList<T> documents, bool valid = true)
        {
            var mongoCollection = new Mock<IMongoCollection<T>>();
            var mongoQueryable = new Mock<IMongoQueryable<T>>();
            mongoCollection.Setup(collection => collection.FindAsync<T>(It.IsAny<FilterDefinition<T>>(), null, It.IsAny<CancellationToken>()))
              .ReturnsAsync(
                (FilterDefinition<T> expression, FindOptions options, CancellationToken token)
                => CreateCursor(documents, expression)
                )
                ;

            var database = new Mock<IMongoDatabase>();

            if (valid)
            {
                var resultCommand = new BsonDocument("ok", 1);
                database.Setup(d => d.RunCommandAsync(It.IsAny<Command<BsonDocument>>(), null, It.IsAny<CancellationToken>())).ReturnsAsync(resultCommand);
            }
            else
            {
                database.Setup(d => d.RunCommandAsync(It.IsAny<Command<BsonDocument>>(), null, It.IsAny<CancellationToken>())).ThrowsAsync(new Exception("teste"));
            }


            var mongoDbContext = new Mock<IMongoDbContext>();
            mongoDbContext.Setup(context => context.Collection<T>())
                .Returns(mongoCollection.Object);

            mongoDbContext.Setup(context => context.Collection<T>(It.IsAny<string>()))
               .Returns(mongoCollection.Object);

            mongoDbContext.Setup(context => context.GetDatabase()).Returns(database.Object);



            return mongoDbContext.Object;
        }

    }
}
