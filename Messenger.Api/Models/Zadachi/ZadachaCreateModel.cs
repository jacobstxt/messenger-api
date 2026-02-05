using Microsoft.AspNetCore.Mvc;

namespace Messenger.Api.Models.Zadachi;

public class ZadachaCreateModel
{
    public string Name { get; set; } = String.Empty;

    public IFormFile? Image { get; set; }
}
