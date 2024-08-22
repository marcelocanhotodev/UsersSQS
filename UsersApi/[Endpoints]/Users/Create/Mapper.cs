using FastEndpoints;
using UsersApi.Domain;

namespace UsersApi._Endpoints_.Users.Create;

public class Mapper : Mapper<Request, Response, object>
{
    public User ToRequest(Request r) => new
    (
        r.Name,
        r.Document,
        r.Email
    );
}