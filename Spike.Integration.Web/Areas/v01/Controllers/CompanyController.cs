using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using Spike.Contracts.Public;
using Spike.Contracts.Public.V01.Companies;
using Spike.Integration.Services.V01.Company;
using Spike.Integration.Web.AuthenticationHandlers;

namespace Spike.Integration.Web.Areas.V01.Controllers
{
    [RoutePrefix("api/v01/company")]
    [BasicAuthentication]
    public class CompanyController : ApiController, ICompanyService
    {
        // Can initialize with DI
        private ICompanyService _delegator;
        private ICompanyService Delegator
        {
            get
            {
                if (_delegator != null)
                {
                    return _delegator;
                }

                return _delegator = new SchDelegate();
            }
        }

        /// <summary>
        /// This is a heath test operation.
        /// </summary>
        /// <param name="echoValue"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("echo/{echoValue}")]
        [ResponseType(typeof(string))]
        public string Echo([FromUri] string echoValue)
        {
            try
            {
                return Delegator.Echo(echoValue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        
        /// <summary>
        /// This method helps you find companies based on search criteria
        /// </summary>
        /// <param name="searchDetails"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("searchcompanies")]
        [ResponseType(typeof(PagedResponse<CompanyBasicProfile, CompanySortColumn>))]
        public PagedResponse<CompanyBasicProfile, CompanySortColumn> SearchCompanies([FromBody] CompanySearchParameters searchDetails)
        {
            return Delegator.SearchCompanies(searchDetails);
        }

        /// <summary>
        /// This will retrieve the available details for a specific company
        /// </summary>
        /// <param name="noxId">The nox identifier.</param>
        /// <param name="referenceNumber">The reference number.</param>
        /// <param name="moduleSelection">The module selection, if not provided it will return all</param>
        /// <returns></returns>
        [HttpGet]
        [Route("get")]
        [ResponseType(typeof(Company))]
        public Company GetCompanyDetails([FromBody] string noxId, [FromBody] string referenceNumber, IEnumerable<Module> moduleSelection)
        {
            return Delegator.GetCompanyDetails(noxId, referenceNumber, moduleSelection);
        }
    }
}
