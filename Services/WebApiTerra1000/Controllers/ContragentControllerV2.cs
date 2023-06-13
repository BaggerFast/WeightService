// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using WsWebApiCore.Common;

namespace WebApiTerra1000.Controllers;

public sealed class ContragentControllerV2 : WsServiceControllerBase
{
    #region Constructor and destructor

    public ContragentControllerV2(ISessionFactory sessionFactory) : base(sessionFactory)
    {
        //
    }

    #endregion

    #region Public and private methods

    [AllowAnonymous]
    [HttpGet]
    [Route(WsLocaleWebServiceUtils.GetContragentV2)]
    public ContentResult GetContragentFromCodeIdProd([FromQuery] string code, long id,
        [FromQuery(Name = "format")] string format = "") =>
        GetContragentFromCodeIdWork(code != null
            ? WsServiceSqlQueriesContragentsV2.GetContragentFromCodeProd : WsServiceSqlQueriesContragentsV2.GetContragentFromIdProd,
            code, id, format);

    [AllowAnonymous]
    [HttpGet]
    [Route(WsLocaleWebServiceUtils.GetContragentV2Preview)]
    public ContentResult GetContragentFromCodeIdPreview([FromQuery] string code, [FromQuery] long id,
        [FromQuery(Name = "format")] string format = "") =>
        GetContragentFromCodeIdWork(code != null
            ? WsServiceSqlQueriesContragentsV2.GetContragentFromCodePreview : WsServiceSqlQueriesContragentsV2.GetContragentFromIdPreview,
            code, id, format);

    private ContentResult GetContragentFromCodeIdWork([FromQuery] string url, [FromQuery] string code,
        [FromQuery] long id, [FromQuery(Name = "format")] string format = "")
    {
        return GetContentResult(() =>
        {
            string response = WsServiceSqlUtils.GetResponse<string>(SessionFactory, url,
                code != null ? WsServiceSqlUtils.GetParametersV2(code) : WsServiceSqlUtils.GetParametersV2(id));
            XDocument xml = XDocument.Parse(response ?? $"<{WsWebConstants.Contragents} />", LoadOptions.None);
            XDocument doc = new(new XElement(WsWebConstants.Response, xml.Root));
            return SerializeDeprecatedModel<XDocument>.GetContentResult(format, doc, HttpStatusCode.OK);
        }, format);
    }

    [AllowAnonymous]
    [HttpGet]
    [Route(WsLocaleWebServiceUtils.GetContragentsV2)]
    public ContentResult GetContragentsProd([FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate = null,
        [FromQuery] int? offset = null, [FromQuery] int? rowCount = null, [FromQuery(Name = "format")] string format = "")
    {
        if (startDate != null && endDate != null && offset != null && rowCount != null)
            return GetContragentsWork(WsServiceSqlQueriesContragentsV2.GetContragentsFromDatesOffsetProd, startDate, endDate, offset, rowCount, format);
        if (startDate != null && endDate != null)
            return GetContragentsWork(WsServiceSqlQueriesContragentsV2.GetContragentsFromDatesProd, startDate, endDate, offset, rowCount, format);
        if (startDate != null && endDate == null)
            return GetContragentsWork(WsServiceSqlQueriesContragentsV2.GetContragentsFromStartDateProd, startDate, endDate, offset, rowCount, format);

        return GetContragentsEmptyWork(WsServiceSqlQueriesContragentsV2.GetContragentsEmptyProd, format);
    }

    [AllowAnonymous]
    [HttpGet]
    [Route(WsLocaleWebServiceUtils.GetContragentsV2Preview)]
    public ContentResult GetContragentsPreview([FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate = null,
        [FromQuery] int? offset = null, [FromQuery] int? rowCount = null, [FromQuery(Name = "format")] string format = "")
    {
        if (startDate != null && endDate != null && offset != null && rowCount != null)
            return GetContragentsWork(WsServiceSqlQueriesContragentsV2.GetContragentsFromDatesOffsetPreview, startDate, endDate, offset, rowCount, format);
        if (startDate != null && endDate != null)
            return GetContragentsWork(WsServiceSqlQueriesContragentsV2.GetContragentsFromDatesPreview, startDate, endDate, offset, rowCount, format);
        if (startDate != null && endDate == null)
            return GetContragentsWork(WsServiceSqlQueriesContragentsV2.GetContragentsFromStartDatePreview, startDate, endDate, offset, rowCount, format);

        return GetContragentsEmptyWork(WsServiceSqlQueriesContragentsV2.GetContragentsEmptyPreview, format);
    }

    private ContentResult GetContragentsEmptyWork([FromQuery] string url, [FromQuery(Name = "format")] string format = "")
    {
        return GetContentResult(() =>
        {
            string response = WsServiceSqlUtils.GetResponse<string>(SessionFactory, url);
            XDocument xml = XDocument.Parse(response ?? $"<{WsWebConstants.Goods} />", LoadOptions.None);
            XDocument doc = new(new XElement(WsWebConstants.Response, xml.Root));
            return SerializeDeprecatedModel<XDocument>.GetContentResult(format, doc, HttpStatusCode.OK);
        }, format);
    }

    private ContentResult GetContragentsWork([FromQuery] string url, [FromQuery] DateTime? startDate = null,
        [FromQuery] DateTime? endDate = null, [FromQuery] int? offset = null, [FromQuery] int? rowCount = null,
        [FromQuery(Name = "format")] string format = "")
    {
        return GetContentResult(() =>
        {
            List<SqlParameter> parameters = null;
            if (startDate != null && endDate != null && offset != null && rowCount != null)
                parameters = WsServiceSqlUtils.GetParametersV2(startDate, endDate, offset, rowCount);
            else if (startDate != null && endDate != null)
                parameters = WsServiceSqlUtils.GetParametersV2(startDate, endDate);
            else if (startDate != null && endDate == null)
                parameters = WsServiceSqlUtils.GetParametersV2(startDate);
            string response = WsServiceSqlUtils.GetResponse<string>(SessionFactory, url, parameters);
            XDocument xml = XDocument.Parse(response ?? $"<{WsWebConstants.Contragents} />", LoadOptions.None);
            XDocument doc = new(new XElement(WsWebConstants.Response, xml.Root));
            return SerializeDeprecatedModel<XDocument>.GetContentResult(format, doc, HttpStatusCode.OK);
        }, format);
    }

    #endregion
}
