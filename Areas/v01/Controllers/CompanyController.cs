using System;
using System.Web.Http;
using Spike.Contracts.Public;
using Spike.Contracts.Public.V01.Companies;

namespace Spike.Integration.Web.Areas.V01.Controllers
{
    [RoutePrefix("api/v01/company")]
    public class CompanyController : ApiController, ICompanyService
    {
        public const string Version = "v01";

        [HttpGet]
        [Route("echo/{echoValue}")]
        public string Echo([FromUri] string echoValue)
        {
            return $"Echo response: Date [{DateTime.Now}] Version [{Version}] Echo [{echoValue}]";
        }
        
        // JsonResult
        [HttpPost]
        [Route("searchcompanies")]
        public ResultList<CompanyBasicProfile> SearchCompanies([FromBody] CompanySearchParameters searchDetails)
        {
            throw new NotImplementedException();
        }

        // JsonResult
        [AcceptVerbs("GET")]
        [HttpGet]
        [Route("get")]
        public ResultItem<Company> GetCompanyDetails([FromBody] string noxId, [FromBody] string referenceNumber)
        {
            
            throw new NotImplementedException();
        }
    }
}
