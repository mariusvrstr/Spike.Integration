using System;
using System.Collections.Generic;
using Spike.Contracts.Public;
using Spike.Contracts.Public.V01.Companies;

namespace Spike.Integration.Services.V01.Company
{
    // This will be removed and moved into correct SCH location
    // TODO: Move this out to correct BL in actual project
    public class SchDelegate : ICompanyService
    {
        public const string Version = "V01";

        public string Echo(string echoValue)
        {
            var message = $"Echo response: Date [{DateTime.Now}] Version [{Version}] Echo [{echoValue}]";
            return message;
        }

        public PagedResponse<CompanyBasicProfile, CompanySortColumn> SearchCompanies(CompanySearchParameters searchDetails)
        {
            //TODO:: Stub - Fetch
            var response = new List<CompanyBasicProfile> { };

            return PagedResponse<CompanyBasicProfile, CompanySortColumn>.Create(response, ResultCode.Success);
        }

        public Contracts.Public.V01.Companies.Company GetCompanyDetails(string noxId, string referenceNumber, IEnumerable<Module> moduleSelection)
        {
            return null;
        }
    }
}