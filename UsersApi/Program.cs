using Amazon.SQS.Model;
using Amazon.SQS;
using FastEndpoints;
using FastEndpoints.Swagger;
using UsersApi;
using UsersApi.Services; 

var bld = WebApplication.CreateBuilder();
bld.Services.AddFastEndpoints().SwaggerDocument();
bld.Services.AddAwsServices(bld.Configuration);
bld.Services.AddScoped<IAwsQueueService, AwsQueueService>();
var app = bld.Build();
app.UseFastEndpoints().UseSwaggerGen(); 

if (bld.Configuration.GetSection("LocalStack").GetValue<bool>("UseLocalStack"))
{
    var sqsClient = app.Services.GetRequiredService<IAmazonSQS>();

    var createQueueRequest = new CreateQueueRequest
    {
        QueueName = "Users"
    };

    var createQueueResponse = await sqsClient.CreateQueueAsync(createQueueRequest);
    Console.WriteLine($"Queue Users created with URL: {createQueueResponse.QueueUrl}");
}

app.Run();
