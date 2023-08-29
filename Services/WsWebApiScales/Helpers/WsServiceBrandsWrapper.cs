namespace WsWebApiScales.Helpers;

/// <summary>
/// Brands controller.
/// </summary>
[Tags(WsLocaleWebServiceUtils.Tag1CBrands)]
public sealed class WsServiceBrandsWrapper : WsServiceControllerBase
{
    #region Public and private fields, properties, constructor

    private WsServiceBrandsController BrandsController { get; }

    public WsServiceBrandsWrapper(ISessionFactory sessionFactory) : base(sessionFactory)
    {
        BrandsController = new(sessionFactory);
    }

    #endregion

    #region Public and private methods

    [AllowAnonymous]
    [Produces("application/xml")]
    [HttpPost]
    [Route(WsLocaleWebServiceUtils.SendBrands)]
    public ContentResult SendBrands([FromBody] XElement xml, [FromQuery(Name = "format")] string format = "",
        [FromQuery(Name = "debug")] bool isDebug = false, 
        [FromHeader(Name = "host")] string host = "", [FromHeader(Name = "accept")] string version = "")
    {
        DateTime requestStampDt = DateTime.Now;
        ContentResult result = WsServiceUtilsGet.GetAcceptVersion(version) switch
        {
            // Новый ответ 1С - не найдено.
            WsSqlEnumAcceptVersion.V2 => WsServiceUtilsGetXmlContent.GetContentResult(() => WsServiceUtilsResponse.NewResponse1CIsNotFound(
                    $"Version {version} {WsLocaleCore.WebService.IsNotFound}!", format, isDebug, SessionFactory), format),
            _ => WsServiceUtilsGetXmlContent.GetContentResult(() => BrandsController.NewResponseBrands(xml, format, isDebug, SessionFactory), format)
        };
        WsServiceUtilsLog.LogWebServiceFk(nameof(WsWebApiScales), WsLocaleWebServiceUtils.SendBrands,
            requestStampDt, xml, result.Content ?? string.Empty, format, host, version);
        return result;
    }

    #endregion
}