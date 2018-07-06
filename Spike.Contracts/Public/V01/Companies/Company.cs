
using System;

namespace Spike.Contracts.Public.V01.Companies
{
    /// <summary>
    /// Basic Company Profile
    /// </summary>
    public class CompanyBasicProfile
    {
        /// <summary>
        /// Gets or sets the nox identifier.
        /// </summary>
        /// <value>
        /// The nox identifier.
        /// </value>
        public string NoxId { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the reference number.
        /// </summary>
        /// <value>
        /// The reference number.
        /// </value>
        public string ReferenceNumber { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class JudgementModule
    {
        /// <summary>
        /// Gets or sets the nox identifier.
        /// </summary>
        /// <value>
        /// The nox identifier.
        /// </value>
        public string NoxId { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the issued date.
        /// </summary>
        /// <value>
        /// The issued date.
        /// </value>
        public DateTime IssuedDate { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class AccountsModule
    {
        /// <summary>
        /// Gets or sets the nox identifier.
        /// </summary>
        /// <value>
        /// The nox identifier.
        /// </value>
        public string NoxId { get; set; }

        /// <summary>
        /// Gets or sets the account number.
        /// </summary>
        /// <value>
        /// The account number.
        /// </value>
        public string AccountNumber { get; set; }

        /// <summary>
        /// Gets or sets the branch.
        /// </summary>
        /// <value>
        /// The branch.
        /// </value>
        public string Branch { get; set; }
    }


    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Spike.Contracts.Public.V01.Companies.CompanyBasicProfile" />
    public class Company : CompanyBasicProfile
    {
        /// <summary>
        /// Gets or sets the judgement module.
        /// </summary>
        /// <value>
        /// The judgement module.
        /// </value>
        public JudgementModule JudgementModule { get; set; }

        /// <summary>
        /// Gets or sets the accounts module.
        /// </summary>
        /// <value>
        /// The accounts module.
        /// </value>
        public AccountsModule AccountsModule { get; set; }
    }
}
