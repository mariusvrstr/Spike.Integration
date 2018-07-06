using System.Collections.Generic;

namespace Spike.Contracts.Public.V01.Companies
{
    /// <summary>
    /// An API service for programmatically interacting with Research.
    /// </summary>
    /// <remarks>
    /// <para>The security configuration of this service requires that credentials be supplied for each request. Below is an example of a way to provide credentials with a request.</para>
    /// <code lang="csharp">
    /// // Instantiate the service client:
    /// var client = new ResearchApi.CoreDistributedServiceClient();
    /// 
    /// Configure the client credentials, We will need to provide these to you:
    /// client.ClientCredentials.UserName.UserName = "user@example.com";
    /// client.ClientCredentials.UserName.Password = "password";
    /// </code>
    /// <para>Credentials are supplied by Company.</para>
    /// </remarks>
    public interface ICompanyService : IServiceBase
    {
        /// <summary>
        /// Searches the companies.
        /// </summary>
        /// <param name="searchDetails">The search details.</param>
        /// <returns></returns>
        PagedResponse<CompanyBasicProfile, CompanySortColumn> SearchCompanies(CompanySearchParameters searchDetails);

        /// <summary>
        /// Gets the company details.
        /// </summary>
        /// <param name="noxId">The nox identifier.</param>
        /// <param name="referenceNumber">The reference number.</param>
        /// <param name="moduleSelection">The module selection.</param>
        /// <returns></returns>
        Company GetCompanyDetails(string noxId, string referenceNumber, IEnumerable<Module> moduleSelection);
    }
}
