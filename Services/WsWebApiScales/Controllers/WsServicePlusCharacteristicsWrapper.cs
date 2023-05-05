// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace WsWebApiScales.Controllers;

/// <summary>
/// Nomenclatures characteristics controller.
/// </summary>
[Tags(WsWebServiceConsts.Ref1CNomenclaturesCharacteristics)]
public sealed class WsServicePlusCharacteristicsWrapper : WsServiceControllerBase
{
    #region Public and private fields, properties, constructor

    private WsServicePlusCharacteristicsController PlusCharacteristicsController { get; }

    public WsServicePlusCharacteristicsWrapper(ISessionFactory sessionFactory) : base(sessionFactory)
    {
        PlusCharacteristicsController = new(sessionFactory);
    }

    #endregion

    #region Public and public methods

    [AllowAnonymous]
    [Produces("application/xml")]
    [HttpPost]
    [Route(WsWebServiceUrls.SendNomenclaturesCharacteristics)]
    public ContentResult SendPluCharacteristics([FromBody] XElement xml, [FromQuery(Name = "format")] string format = "",
        [FromQuery(Name = "debug")] bool isDebug = false,
        [FromHeader(Name = "host")] string host = "", [FromHeader(Name = "accept")] string version = "")
    {
        DateTime requestStampDt = DateTime.Now;
        ContentResult result = GetAcceptVersion(version) switch
        {
            WsSqlAcceptVersion.V2 => GetContentResult(() => // Новый ответ 1С - не найдено.
                NewResponse1CIsNotFound($"Version {version} {LocaleCore.WebService.IsNotFound}!", format, isDebug, SessionFactory), format),
            _ => GetContentResult(() => PlusCharacteristicsController.NewResponsePluCharacteristics(xml, format, isDebug, SessionFactory), format)
        };
        LogWebServiceFk(nameof(WsWebApiScales), WsWebServiceUrls.SendNomenclaturesCharacteristics,
            requestStampDt, xml, result.Content ?? string.Empty, format, host, version).ConfigureAwait(false);
        return result;
    }

    #endregion
}