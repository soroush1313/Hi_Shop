﻿using Hi_Shop.Application.Visitors.SaveVisitorInfo;
using Microsoft.AspNetCore.Mvc.Filters;
using UAParser;

namespace Hi_Shop.EndPoint.Utilities.Filters
{
    public class SaveVisitorFilter : IActionFilter
    {

        private readonly ISaveVisitorInfoService _saveVisitorInfoService;

        public SaveVisitorFilter(ISaveVisitorInfoService saveVisitorInfoService)
        {
            _saveVisitorInfoService = saveVisitorInfoService;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string ip = context.HttpContext.Request.HttpContext.Connection.RemoteIpAddress.ToString();
            var actionName = ((Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)context.ActionDescriptor).ActionName;
            var controllerName = ((Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)context.ActionDescriptor).ControllerName;
            var userAgent = context.HttpContext.Request.Headers["User-Agent"];
            var uaParser = Parser.GetDefault();
            ClientInfo clientInfo = uaParser.Parse(userAgent);
            var referer = context.HttpContext.Request.Headers["Referer"].ToString();
            var currentUrl = context.HttpContext.Request.Path;
            var request = context.HttpContext.Request;
            string visitorId = context.HttpContext.Request.Cookies["VisitorId"];
            if (visitorId == null)
            {
                visitorId=Guid.NewGuid().ToString();
                context.HttpContext.Response.Cookies.Append("VisitorId", visitorId , new Microsoft.AspNetCore.Http.CookieOptions
                {
                    Path="/",
                    HttpOnly=true,
                    Expires=DateTime.Now.AddDays(30),
                });

            }

            _saveVisitorInfoService.Ececute(new RequestSaveVisitorInfoDto
            {
                Browser = new VisitorVersionDto
                {
                    Family = clientInfo.UA.Family,
                    Version = $"{clientInfo.UA.Major}.{clientInfo.UA.Minor}.{clientInfo.UA.Patch}"
                },
                CurrentLink = currentUrl,
                Device = new DeviceDto
                {
                    Brand = clientInfo.Device.Brand,
                    Family = clientInfo.Device.Family,
                    IsSpider = clientInfo.Device.IsSpider,
                    Model = clientInfo.Device.Model,
                },
                Ip = ip,
                Method = request.Method,
                OperationSystem = new VisitorVersionDto()
                {
                    Family = clientInfo.OS.Family,
                    Version = $"{clientInfo.OS.Major}.{clientInfo.OS.Minor}.{clientInfo.OS.Patch}"
                },
                PhysicalPath = $"{controllerName}/{actionName}",
                Protocol = request.Protocol,
                ReferrerLink = referer,
                VisitorId=visitorId
            });
        }
    }
}