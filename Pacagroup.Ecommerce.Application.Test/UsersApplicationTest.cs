using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Pacagroup.Ecommerce.Application.Test
{
    [TestClass]
    public class UsersApplicationTest
    {
        private static IConfiguration _configuration;
        private static IServiceScopeFactory _scopeFactory;
        [ClassInitialize]
        //public static void Initialize(TestContext testContext)
        //{
        //    var configBuilder = new ConfigurationBuilder()
        //        .SetBasePath(Directory.GetCurrentDirectory()) // Ruta base
        //        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        //        .AddEnvironmentVariables();
        //}

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
