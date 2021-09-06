﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NHibernate;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Terra.Controllers
{
    public class ShipmentController : BaseController
    {
        #region Constructor and destructor

        public ShipmentController(ILogger<BaseController> logger, ISessionFactory sessionFactory) : base(logger, sessionFactory)
        {
        }

        #endregion

        #region Public and private methods - API

        [AllowAnonymous]
        [HttpGet()]
        [Route("api/shipment/")]
        public ContentResult GetShipment(long id)
        {
            return Task.RunTask(new Task<ContentResult>(() => {
                XDocument doc;
                using ISession session = SessionFactory.OpenSession();
                using ITransaction transaction = session.BeginTransaction();
                const string sql = "SELECT [IIS].[GetRefShipmentsById] (:ID)";
                string response = session.CreateSQLQuery(sql)
                    .SetParameter("ID", id)
                    .UniqueResult<string>();
                if (response != null)
                {
                    IDbCommand command = new SqlCommand();
                    command.Connection = session.Connection;
                    transaction.Enlist((System.Data.Common.DbCommand)command);

                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "[IIS].[GetShipments]";

                    // Set input parameter
                    SqlParameter IdInput = new("@jsonListId", SqlDbType.NVarChar);
                    IdInput.Direction = ParameterDirection.Input;
                    IdInput.Value = response;
                    command.Parameters.Add(IdInput);

                    // Set output parameter
                    SqlParameter XmlOutput = new("@xml", SqlDbType.Xml);
                    XmlOutput.Direction = ParameterDirection.Output;
                    command.Parameters.Add(XmlOutput);

                    SqlParameter returnParameter = new("@RETURN_VALUE", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;
                    command.Parameters.Add(returnParameter);

                    // Execute the stored procedure
                    command.ExecuteNonQuery();

                    transaction.Commit();

                    XDocument xml;
                    if (XmlOutput.Value != DBNull.Value)
                    {
                        xml = XDocument.Parse(XmlOutput.Value.ToString() ?? "<Shipment />", LoadOptions.None);
                    }
                    else
                    {
                        xml = XDocument.Parse("<Shipment />", LoadOptions.None);
                    }
                    doc = new XDocument(new XElement("response", xml.Root));

                }
                else
                {
                    XDocument xml = XDocument.Parse("<Shipment />", LoadOptions.None);
                    doc = new XDocument(new XElement("response", xml.Root));
                }
                return new ContentResult
                {
                    ContentType = "application/xml",
                    StatusCode = (int)HttpStatusCode.OK,
                    Content = doc.ToString()
                };
            }));
        }

        [AllowAnonymous]
        [HttpGet()]
        [Route("api/shipmentsbydocdate/")]
        [Route("api/shipments/")]
        public ContentResult GetShipments(DateTime startDate, DateTime endDate, int offset = 0, int rowCount = 10)
        {
            return Task.RunTask(new Task<ContentResult>(() => {
                XDocument doc;
                using ISession session = SessionFactory.OpenSession();
                using ITransaction transaction = session.BeginTransaction();
                const string sql = "SELECT [IIS].[GetRefShipmentsByDocDate] (:StartDate,:EndDate,:Offset,:RowCount)";
                string response = session.CreateSQLQuery(sql)
                    .SetParameter("StartDate", startDate)
                    .SetParameter("EndDate", endDate)
                    .SetParameter("Offset", offset)
                    .SetParameter("RowCount", rowCount)
                    .UniqueResult<string>();
                if (response != null)
                {
                    IDbCommand command = new SqlCommand();
                    command.Connection = session.Connection;
                    transaction.Enlist((System.Data.Common.DbCommand) command);

                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "[IIS].[GetShipments]";

                    // Set input parameter
                    SqlParameter IdInput = new("@jsonListId", SqlDbType.NVarChar);
                    IdInput.Direction = ParameterDirection.Input;
                    IdInput.Value = response;
                    command.Parameters.Add(IdInput);

                    // Set output parameter
                    SqlParameter XmlOutput = new("@xml", SqlDbType.Xml);
                    XmlOutput.Direction = ParameterDirection.Output;
                    command.Parameters.Add(XmlOutput);

                    SqlParameter returnParameter = new("@RETURN_VALUE", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;
                    command.Parameters.Add(returnParameter);

                    // Execute the stored procedure
                    command.ExecuteNonQuery();

                    XDocument xml;
                    if (XmlOutput.Value != DBNull.Value)
                    {
                        xml = XDocument.Parse(XmlOutput.Value.ToString() ?? "<Shipments />", LoadOptions.None);
                    }
                    else
                    {
                        xml = XDocument.Parse("<Shipments />", LoadOptions.None);
                    }

                    doc = new XDocument(new XElement("response", xml.Root));

                }
                else
                {
                    XDocument xml = XDocument.Parse("<Shipments />", LoadOptions.None);
                    doc = new XDocument(new XElement("response", xml.Root));
                }
                transaction.Commit();
                return new ContentResult
                {
                    ContentType = "application/xml",
                    StatusCode = (int) HttpStatusCode.OK,
                    Content = doc.ToString()
                };
            }));
        }

        #endregion
    }
}