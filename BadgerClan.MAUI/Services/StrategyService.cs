using BadgerClan.Shared;
using Grpc.Net.Client;
using ProtoBuf.Grpc.Client;
using System.Runtime.InteropServices;

namespace BadgerClan.MAUI.Services;

internal class StrategyService : IDisposable
{
    private GrpcChannel channel;
    public IStrategyService service { get; set; }
    
    public StrategyService (string apiUrl)
    {
        GrpcClientFactory.AllowUnencryptedHttp2 = true;
        channel = GrpcChannel.ForAddress(apiUrl);
        service = channel.CreateGrpcService<IStrategyService>();
    }
    public void Dispose()
    {
        channel.Dispose();
    }
}
