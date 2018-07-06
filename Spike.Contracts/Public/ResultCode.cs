using System.Runtime.Serialization;

namespace Spike.Contracts.Public
{
    [DataContract]
    public enum ResultCode
    {
        Undefined = 0,

        Success = 1,

        GeneralFailure = 2,

        NotAuthorized = 3
    }
}
