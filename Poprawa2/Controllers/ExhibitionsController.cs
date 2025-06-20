using Microsoft.AspNetCore.Mvc;
using Poprawa2.DTOs;
using Poprawa2.Service;

namespace Poprawa2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExhibitionsController:ControllerBase
{
    private readonly IAddExhibition _addExhibition;

    public ExhibitionsController(IAddExhibition addExhibition)
    {
        _addExhibition = addExhibition;
    }

    [HttpPost]
    public async Task<IActionResult> AddExhibitionAsync(AddExhibitionDto addExhibition)
    {
        try
        {
            await _addExhibition.AddNewExhibitionAsync(addExhibition);
            return Created();
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}