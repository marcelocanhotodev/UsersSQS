using Amazon.SQS;
using Amazon.SQS.Model;
using System.Text.Json;

namespace UsersApi.Services;

public class AwsQueueService : IAwsQueueService
{
    public readonly IAmazonSQS _amazonSQS;
    public AwsQueueService(IAmazonSQS amazonSQS)
    {
        _amazonSQS = amazonSQS;
    }
    /// <inheritdoc/>
    public async Task<SendMessageResponse> SendMessageAsync<T>(T message)
    {
        try
        {
            var queueUrl = @"http://sqs.us-east-1.localhost.localstack.cloud:4566/000000000000/Users";
            var jsonMessage = JsonSerializer.Serialize(message);
            var messageRequest = new SendMessageRequest(queueUrl, jsonMessage);
            return await _amazonSQS.SendMessageAsync(messageRequest);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao enviar a mensagem para a fila: {ex.Message}");
            throw;
        }
    }
}
