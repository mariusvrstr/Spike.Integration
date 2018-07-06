
namespace Spike.Contracts.Public.V01.Companies
{
    /// <summary>
    /// The Company Search Parameters
    /// </summary>
    /// <seealso cref="Spike.Contracts.Public.V01.Companies.CompanyBasicProfile" />
    public class CompanySearchParameters : CompanyBasicProfile
    {
        /// <summary>
        /// The Page Details contains all the page related information
        /// </summary>
        /// <value>
        /// The page details.
        /// </value>
        public PageDetails<CompanySortColumn> PageDetails { get; set; }
    }
}
