using System;
using System.Collections.Generic;
using Spike.Contracts.Public;
using Spike.Contracts.Public.V01.Companies;

namespace Spike.Integration.Services.V01.Company
{
    public class CompanyServiceDelegatorV01 : ICompanyService
    {
        public CompanyServiceDelegatorV01(ICompanyService @delegate)
        {
            Delegate = @delegate;
        }

        private ICompanyService Delegate { get; set; }


        public string Echo(string echoValue)
        {
            return Delegate.Echo(echoValue);
        }

        public PagedResponse<CompanyBasicProfile, CompanySortColumn> SearchCompanies(CompanySearchParameters searchDetails)
        {
            return Delegate.SearchCompanies(searchDetails);
        }

        public Contracts.Public.V01.Companies.Company GetCompanyDetails(string noxId, string referenceNumber, IEnumerable<Module> moduleSelection)
        {
            return Delegate.GetCompanyDetails(noxId, referenceNumber, moduleSelection);
        }
    }
}
