﻿using Hi_Shop.Application.Interfaces.Contexts;
using Hi_Shop.Domain.Visitors;
using MongoDB.Driver;

namespace Hi_Shop.Application.Visitors.SaveVisitorInfo
{
    public class SaveVisitorInfoService : ISaveVisitorInfoService
    {
        private readonly IMongoDbContext<Visitor> _mongoDbContext;
        private readonly IMongoCollection<Visitor> _visitorMongoCollection;
        public SaveVisitorInfoService(IMongoDbContext<Visitor> mongoDbContext)
        {
            _mongoDbContext= mongoDbContext;
            _visitorMongoCollection= mongoDbContext.GetCollection();
        }
        public void Ececute(RequestSaveVisitorInfoDto request)
        {
            _visitorMongoCollection.InsertOne(new Visitor
            {
                Browser = new VisitorVersion
                {
                    Family = request.Browser.Family,
                    Version = request.Browser.Version
                },
                CurrentLink = request.CurrentLink,
                Device = new Device
                {
                    Brand = request.Device.Brand,
                    Family = request.Device.Family,
                    IsSpider = request.Device.IsSpider,
                    Model = request.Device.Model
                },
                Ip = request.Ip,
                Method = request.Method,
                OperationSystem = new VisitorVersion
                {
                    Family = request.OperationSystem.Family,
                    Version = request.OperationSystem.Version
                },
                PhysicalPath = request.PhysicalPath,
                Protocol = request.Protocol,
                ReferrerLink = request.ReferrerLink
            });
        }
    }
}
