using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace Timu_Vlad_Lab10
{
    public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {
        return Task.FromResult(new HelloReply
        {
            Message = "Hello " + request.Name
        });
    }
    public override Task<SResponse> SendStatus(SRequest request, ServerCallContext
context)
    {
        List<StatusInfo> statusList = StatusRepo();
        SResponse sRes = new SResponse();
        sRes.StatusInfo.AddRange(statusList.Skip(request.No - 1).Take(1));
        return Task.FromResult(sRes);
    }
    public List<StatusInfo> StatusRepo()
    {
        List<StatusInfo> statusList = new List<StatusInfo> {
 new StatusInfo { Author = "Randy", Description = "Task 1 in progess"},
 new StatusInfo { Author = "John", Description = "Task 1 just started"},
 new StatusInfo { Author = "Miriam", Description = "Finished all tasks"},
 new StatusInfo { Author = "Petra", Description = "Task 2 finished"},
 new StatusInfo { Author = "Steve", Description = "Task 2 in progress"}
 };
        return statusList;
    }
}
