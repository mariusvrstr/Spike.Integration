
namespace Spike.Contracts.Public
{
    public interface IResponseClass
    {
        ResultCode ResultCode { get; set; }

        string ResultDescription { get; set; }
    }
}
