using AutoMapper;
using Messenger.Api.Data;
using Messenger.Api.Entities.Chat;
using Messenger.Api.Interfaces;
using Messenger.Api.Models.Chat;
using Microsoft.EntityFrameworkCore;

namespace Messenger.Api.Services;

public class ChatService(
    AppDbContext context,
    IIdentityService identityService,
    IMapper mapper) : IChatService
{
    public async Task<long> CreateChatAsync(ChatCreateModel model)
    {
        var userId = await identityService.GetUserIdAsync();

        var chat = mapper.Map<ChatEntity>(model, opt =>
        {
            opt.Items["UserId"] = userId;
        });

        context.Chats.Add(chat);
        await context.SaveChangesAsync();

        return chat.Id;
    }

    public Task<List<ChatTypeItemModel>> GetAllTypes()
    {
        return context.ChatTypes
            .AsNoTracking()
            .Select(ct => mapper.Map<ChatTypeItemModel>(ct))
            .ToListAsync();
    }

    public async Task<ChatMessageModel> SendMessageAsync(SendMessageModel model)
    {
        var userId = await identityService.GetUserIdAsync();

        var isMember = await context.ChatUsers
            .AnyAsync(x => x.ChatId == model.ChatId && x.UserId == userId);

        if (!isMember)
            throw new UnauthorizedAccessException("User is not in chat");

        var message = new ChatMessageEntity
        {
            ChatId = model.ChatId,
            UserId = userId,
            Message = model.Message
        };

        context.ChatMessages.Add(message);
        await context.SaveChangesAsync();

        return mapper.Map<ChatMessageModel>(message);
    }
}