using FastEndpoints;
using UsersApi.Services;

namespace UsersApi._Endpoints_.Users.Create;

public class Endpoint : Endpoint<Request, Response, Mapper>
{
    public IAwsQueueService QueueService { get; set; } = null!;

    public override void Configure()
    {
        AllowAnonymous();
        Post("/user");
    }

    public override async Task HandleAsync(Request r, CancellationToken ct)
    {
        try
        {
            await QueueService.SendMessageAsync<Request>(r);
            await SendOkAsync();
        }
        catch (Exception ex)
        {
            ThrowError(ex.Message);
        }
    }
}