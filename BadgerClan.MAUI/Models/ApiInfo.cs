using System.Collections;

namespace BadgerClan.MAUI.Models;

public class ApiInfo
{
    public string ApiName { get; set; }
    public string ApiUrl { get; set; }
    public ApiType ApiType { get; set; }
}
public enum ApiType
{
    REST,
    gRPC
}