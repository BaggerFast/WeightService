﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NHibernate;
using WebApiCore.Utils;

namespace WebApiTerra1000.Controllers
{
    [Authorize]
    [ApiController]
    public class BaseController : Controller
    {
        #region Public and private fields and properties

        public ControllerHelper Controller { get; set; } = ControllerHelper.Instance;
        public readonly ILogger<BaseController> Logger = null;
        public readonly ISessionFactory SessionFactory = null;

        #endregion

        #region Constructor and destructor

        public BaseController(ILogger<BaseController> logger, ISessionFactory sessionFactory)
        {
            Logger = logger;
            SessionFactory = sessionFactory;
        }

        public BaseController(ISessionFactory sessionFactory)
        {
            SessionFactory = sessionFactory;
        }

        #endregion
    }
}
