﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Xml.Linq;
using terra.Common;

namespace terra.Controllers
{
    public class TerraController : ApiController
    {
        private List<string> ErrorList = new List<string>();
        private ErrorContainer errors = new ErrorContainer();

        // GET: api/Terra
        public HttpResponseMessage Get()
        {
            ErrorList.Clear();

            var xResponse = new XDocument(
                new XElement("response",
                new XElement("Message", "Current IIS DataTime"),
                new XElement("CurrentDate", DateTime.Now.ToString())
                )
            );

            errors.Add("Successful");
            xResponse.Root.Add(errors.GetXElement());
            return GetResponse(xResponse); 
        }

        // GET: api/Terra/?test=0
        public HttpResponseMessage Get(int test)
        {
            errors.Clear();

            if (test == 0)
            {
                return BuildIISResponse();
            }
            else if (test == 1)
            {
                return BuildSQLResponse();
            }

            return BuildDummyResponse();

        }

        private HttpResponseMessage BuildSQLResponse()
        {
            var dbConnString = ConfigurationManager.ConnectionStrings["dbConnString"].ConnectionString;
            using (var conn = new SqlConnection(dbConnString))
            {
                conn.Open();
                using (var cmd = new SqlCommand("SELECT SYSDATETIME() as CurrentTime ", conn))
                {
                    try
                    {
                        var res = (DateTime)cmd.ExecuteScalar();
                        var doc = new XDocument(
                            new XElement("response",
                            new XElement("Message", "Current SQL DataTime"),
                            new XElement("CurrentDate", res.ToString())
                            )
                        );
                        return GetResponse(doc);
                    }

                    catch (Exception ex)
                    {
                        errors.Add(ex.Message);
                        var doc = new XDocument();
                        doc.Root.Add(errors.GetXElement());
                        return GetResponse(doc);
                    }

                }

            }

        }

        private HttpResponseMessage GetResponse(XDocument doc)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(doc.ToString(), Encoding.UTF8, "application/xml");
            return response;
        }

        private HttpResponseMessage BuildIISResponse()
        {
            var doc = new XDocument(
                new XElement("response",
                new XElement("Message", "Current IIS DataTime"),
                new XElement("CurrentDate", DateTime.Now.ToString())
                )
            );
            return GetResponse(doc);
        }


        private HttpResponseMessage BuildDummyResponse()
        {
            var doc = new XDocument(
                new XElement("response",
                    new XElement("Msg", "It is work!")
                )
            );
            return GetResponse(doc);
        }

    }

}
