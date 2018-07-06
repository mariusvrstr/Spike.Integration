using System;
using System.Collections.Generic;
using System.ServiceModel;
using Spike.Contracts.Public;
using Spike.Contracts.Public.V01.Companies;

namespace Spike.Integration.Services.V01.Company
{


    [ServiceContract(Namespace="www.mysite.com")]
    public class CompanyService : ICompanyService
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

        [OperationContract]
        public string Echo(string echoValue)
        {
            try
            {
                return Delegator.Echo(echoValue);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [OperationContract]
        PagedResponse<CompanyBasicProfile, CompanySortColumn> ICompanyService.SearchCompanies(CompanySearchParameters searchDetails)
        {
            try
            {
                return Delegator.SearchCompanies(searchDetails);
            }
            catch (Exception ex)
            {
                return PagedResponse<CompanyBasicProfile, CompanySortColumn>.Create(null, ResultCode.GeneralFailure, ex.Message);
            }
        }

        [OperationContract]
        Contracts.Public.V01.Companies.Company ICompanyService.GetCompanyDetails(string noxId, string referenceNumber, IEnumerable<Module> moduleSelection)
        {
            return Delegator.GetCompanyDetails(noxId, referenceNumber, moduleSelection);
        }
    }
}
