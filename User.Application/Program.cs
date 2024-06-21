using Grpc.Net.Client;
using GRPCService.Protos;

var channel = GrpcChannel.ForAddress("http://localhost:5062");
var client = new UserOfferService.UserOfferServiceClient(channel);

var serverReply = client.GetUserOfferList(new EmptyRequestArg { });
Console.WriteLine(serverReply);

Console.ReadLine();