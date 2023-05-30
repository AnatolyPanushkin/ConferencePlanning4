using ConferencePlanning.DTO;
using ConferencePlanning.Services.PhotosServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConferencePlanning.Controllers;

[Route("api/photos")]
[ApiController]
[AllowAnonymous]
public class PhotoController:ControllerBase
{
    private readonly IConfiguration _configuration;

    private readonly IPhotosService _service;
    
    public PhotoController(IConfiguration configuration, IPhotosService service)
    {
        _configuration = configuration;
        _service = service;
    }
    
    [HttpPost("addNewConferencePhotoById{conferenceId}")]
    public async Task<ActionResult> AddNewConferencePhoto(Guid conferenceId, IFormFile formFile)
    {
        var fullPath = $"{_configuration["PathConferencePhoto"]}\\{formFile.FileName}";
        
        var photo = await _service.AddNewConferencePhoto(conferenceId,formFile.FileName);
        
        var fileStream = new FileStream(fullPath, FileMode.Create);
        
        await formFile.CopyToAsync(fileStream);

        fileStream.Close();
        
        return Ok(photo);
    }

    /*[HttpGet("getConferencePhotoById{confId}")]
    public async Task<ActionResult> GetConferencePhotoById(Guid confId)
    {
        var photo =await _service.GetPhotoName(confId);
        
        var fullPath = $"{_configuration["PathConferencePhoto"]}\\{photo}";
        var t = HttpContext.Response.SendFileAsync(fullPath);
        
        return Ok(HttpContext.Response.SendFileAsync(fullPath));
    }*/
    
    [HttpGet("getConferencePhotoById{confId}")]
    public async Task<IActionResult> GetConferencePhotoById(Guid confId)
    {
        var photo =await _service.GetPhotoName(confId);
        
        var fullPath = $"{_configuration["PathConferencePhoto"]}\\{photo}";
        
        return PhysicalFile(fullPath,"image/png");
    }
    
    
    [HttpPost("addNewUserPhotoById")]
    public async Task<ActionResult> AddNewUserPhotoById(string userId, IFormFile formFile)
    {
        var fullPath = $"{_configuration["PathConferencePhoto"]}\\{formFile.FileName}";
        
        var photo = await _service.AddNewUserPhoto(userId,formFile.FileName);
        
        var fileStream = new FileStream(fullPath, FileMode.Create);
        
        await formFile.CopyToAsync(fileStream);
        
        fileStream.Close();
        
        return Ok(photo);
    }

    [HttpGet("getUserPhotoById")]
    public async Task<ActionResult> GetUserPhotoById(string userId)
    {
        var photoName= await _service.GetUserPhotoName(userId);
        
        var fullPath = $"{_configuration["PathConferencePhoto"]}\\{photoName}";
        
        return PhysicalFile(fullPath,"image/png");
    }
    
    [HttpDelete("deleteUserPhotoById")]
    public async Task<ActionResult> DeleteUserPhotoById(string userId)
    {
        var result = await _service.DeleteUserPhoto(userId);

        if (result!=null)
        {
            return Ok();
        }

        return BadRequest("error photo deleting");
    }
}