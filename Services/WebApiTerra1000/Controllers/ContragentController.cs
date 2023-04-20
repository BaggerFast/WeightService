// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using NHibernate;
using System;
using System.Net;
using System.Xml.Linq;
using WebApiTerra1000.Utils;
using WsLocalizationCore.Utils;
using WsStorageCore.Utils;
using WsWebApiCore.Base;
using WsWebApiCore.Utils;

namespace WebApiTerra1000.Controllers;

public sealed class ContragentController : WsControllerBase
{
    #region Constructor and destructor

    public ContragentController(ISessionFactory sessionFactory) : base(sessionFactory)
    {
        //
    }

    #endregion

    #region Public and private methods

    [AllowAnonymous]
    [HttpGet]
    [Route(WsWebServiceUrls.GetContragent)]
    public ContentResult GetContragent([FromQuery] long id, [FromQuery(Name = "format")] string format = "",
        [FromQuery(Name = "is_debug")] bool isDebug = false)
    {
        return GetContentResult(() =>
        {
            string response = WsWebSqlUtils.GetResponse<string>(SessionFactory, WsWebSqlQueries.GetContragent, new SqlParameter("ID", id));
            XDocument xml = XDocument.Parse(response ?? $"<{WsWebConstants.Contragents} />", LoadOptions.None);
            XDocument doc = new(new XElement(WsWebConstants.Response, xml.Root));
            return SerializeDeprecatedModel<XDocument>.GetContentResult(format, doc, HttpStatusCode.OK);
        }, format);
    }

    [AllowAnonymous]
    [HttpGet]
    [Route(WsWebServiceUrls.GetContragents)]
    public ContentResult GetContragents([FromQuery] DateTime startDate, [FromQuery] DateTime endDate, [FromQuery] int offset = 0,
        [FromQuery] int rowCount = 10, [FromQuery(Name = "format")] string format = "",
        [FromQuery(Name = "is_debug")] bool isDebug = false)
    {
        return GetContentResult(() =>
        {
            string response = WsWebSqlUtils.GetResponse<string>(SessionFactory, WsWebSqlQueries.GetContragents,
                WsWebSqlUtils.GetParameters(startDate, endDate, offset, rowCount));
            XDocument xml = XDocument.Parse(response ?? $"<{WsWebConstants.Contragents} />", LoadOptions.None);
            XDocument doc = new(new XElement(WsWebConstants.Response, xml.Root));
            return SerializeDeprecatedModel<XDocument>.GetContentResult(format, doc, HttpStatusCode.OK);
        }, format);
    }

    #endregion
}