using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Spike.Contracts.Public
{
    [DataContract]
    public class PagedResponse<T, TB> : IResponseClass
    {
        [DataMember]
        public IEnumerable<T> Data { get; set; }

        [DataMember]
        public ResultCode ResultCode { get; set; }

        [DataMember]
        public string ResultDescription { get; set; }

        [DataMember]
        private PageDetails<TB> PageDetails { get; set; }

        public static PagedResponse<T, TB> Create(IEnumerable<T> data, ResultCode resultCode, string resultDescription = null, PageDetails<TB> pagedDetails = null)
        {
            var response = new PagedResponse<T, TB>();
            response.Data = data;
            response.ResultCode = resultCode;
            response.ResultDescription = resultDescription;
            response.PageDetails = pagedDetails;

            return response;
        }
    }
}
