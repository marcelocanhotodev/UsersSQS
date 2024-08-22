using Amazon.SQS;
using LocalStack.Client.Extensions;

namespace UsersApi;

public static class AwsServiceCollectionExtensions
{
    public static IServiceCollection AddAwsServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddLocalStack(configuration);
        services.AddAWSServiceLocalStack<IAmazonSQS>();

        return services;
    }
}
