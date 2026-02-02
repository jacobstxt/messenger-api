using Messenger.Api.Models.Zadachi;

namespace Messenger.Api.Interfaces;

public interface IZadachiService
{
    Task<IEnumerable<ZadachaItemModel>> GetAllAsync();
    Task<ZadachaItemModel> CreateZadachyAsync(ZadachaCreateModel model);
    Task<bool> DeleteZadachyAsync(long id);
    Task<bool> DeleteRangeZadachiAsync(List<long> ids);
    Task<bool> UpdateZadachyAsync(ZadachaUpdateModel model);
}
