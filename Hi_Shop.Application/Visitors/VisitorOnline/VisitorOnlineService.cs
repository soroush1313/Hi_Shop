using Hi_Shop.Application.Interfaces.Contexts;
using Hi_Shop.Domain.Visitors;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hi_Shop.Application.Visitors.VisitorOnline
{
    public class VisitorOnlineService : IVisitorOnlineService
    {
        private readonly IMongoDbContext<OnlineVisitor> mongoDbContext;
        private readonly IMongoCollection<OnlineVisitor> mongoCollection;
        public VisitorOnlineService(IMongoDbContext<OnlineVisitor> mongoDbContext)
        {
            this.mongoDbContext = mongoDbContext;
            mongoCollection = mongoDbContext.GetCollection();
        }
        public void ConnectUser(string ClientId)
        {
            var exist = mongoCollection.AsQueryable().FirstOrDefault(p => p.ClientId == ClientId);
            if (exist == null)
            {
                mongoCollection.InsertOne(new OnlineVisitor
                {
                    ClientId = ClientId,
                    Time = DateTime.Now,
                });
            }

        }

        public void DisconnectUser(string ClientId)
        {
            mongoCollection.FindOneAndDelete(p => p.ClientId == ClientId);
        }

        public int GetCount()
        {
            return mongoCollection.AsQueryable().Count();
        }
    }
}
