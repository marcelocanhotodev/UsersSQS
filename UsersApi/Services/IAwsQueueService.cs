using Amazon.SQS.Model;

namespace UsersApi.Services
{
    public interface IAwsQueueService
    {
        /// <summary>
        /// Serviço de envio de dados para fila SQS
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message"></param>
        /// <returns></returns>
        Task<SendMessageResponse> SendMessageAsync<T>(T message);
    }
}
