using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using Newtonsoft.Json;
using es.eit.application.Views.ComplexViews;
using System.Threading.Tasks;
using System.Collections.Generic;
using es.eit.application;
using es.eit.application.Services;
using es.eit.application.Messages;
using System.Linq;
using es.eit.application.Views;

namespace es.eit.Test.WebApi
{
    [TestClass]
    public class Department_Tests
    {
        public async Task<IEnumerable<Persons_By_Department_View>> Call()
        {
            using ( var client = new HttpClient() )
            {
                string url = "http://localhost:7042/api/department";

                HttpResponseMessage response = await client.GetAsync( url );

                if ( response.IsSuccessStatusCode )
                {
                    string result = await response.Content.ReadAsStringAsync();

                    var rootResult = JsonConvert.DeserializeObject<List<Persons_By_Department_View>>( result );

                    return rootResult;
                }
                else
                {
                    return null;
                }
            }
        }


        [TestMethod]
        public void Get()
        {
            var result = Call().Result;

            Assert.IsNotNull( result );
        }
    }
}
