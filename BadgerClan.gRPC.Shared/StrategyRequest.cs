using ProtoBuf.Grpc;
using System.Runtime.Serialization;
using System.ServiceModel;
namespace BadgerClan.Shared;

[DataContract]
public class StrategyRequest
{
    [DataMember(Order = 1)]
    public string Strategy { get; set; }
}

[DataContract]
public class ConfirmationReply
{
    [DataMember(Order = 1)]
    public string Message { get; set; }
}

[ServiceContract]
public interface IStrategyService
{
    [OperationContract]
    Task<ConfirmationReply> ChangeStrat(StrategyRequest request,
        CallContext context = default);
    
}