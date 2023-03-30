// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NHibernate;
using System;
using System.Net;
using System.Xml.Linq;
using WebApiTerra1000.Utils;
using WsLocalization.Utils;
using WsStorage.Utils;
using WsWebApi.Base;
using WsWebApi.Utils;

namespace WebApiTerra1000.Controllers;

public sealed class SummaryControllerV2 : WsWebControllerBase
{
    #region Constructor and destructor

    public SummaryControllerV2(ISessionFactory sessionFactory) : base(sessionFactory)
    {
        //
    }

    #endregion

    #region Public and private methods

    [AllowAnonymous]
    [HttpGet]
    [Route(UrlWebService.GetSummaryV2)]
    public ContentResult GetSummary([FromQuery] DateTime startDate, [FromQuery] DateTime endDate,
        [FromQuery(Name = "format")] string format = "") =>
        GetSummaryCore(SqlQueriesV2.GetSummary, startDate, endDate, format);

    [AllowAnonymous]
    [HttpGet]
    [Route(UrlWebService.GetSummaryV2Preview)]
    public ContentResult GetSummaryPreview([FromQuery] DateTime startDate, [FromQuery] DateTime endDate,
        [FromQuery(Name = "format")] string format = "") =>
        GetSummaryCore(SqlQueriesV2.GetSummaryPreview, startDate, endDate, format);

    private ContentResult GetSummaryCore(string url, DateTime startDate, DateTime endDate, string format) => 
        GetContentResult(() =>
        {
            string response = WsWebSqlUtils.GetResponse<string>(SessionFactory, url,
                WsWebSqlUtils.GetParameters(startDate, endDate));
            XDocument xml = XDocument.Parse(response ?? $"<{WebConstants.Summary} />", LoadOptions.None);
            XDocument doc = new(new XElement(WebConstants.Response, xml.Root));
            return SerializeDeprecatedModel<XDocument>.GetContentResult(format, doc, HttpStatusCode.OK);
        }, format);

    #endregion
}
