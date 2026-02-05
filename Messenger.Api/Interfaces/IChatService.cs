using Messenger.Api.Models.Chat;

namespace Messenger.Api.Interfaces;

public interface IChatService
{
    Task<long> CreateChatAsync(ChatCreateModel model);
    Task<ChatMessageModel> SendMessageAsync(SendMessageModel model);
    Task<List<ChatTypeItemModel>> GetAllTypes();
    Task<List<ChatItemModel>> GetUserChatsAsync();
    Task<List<ChatMessageModel>> GetChatMessagesAsync(long chatId);
}