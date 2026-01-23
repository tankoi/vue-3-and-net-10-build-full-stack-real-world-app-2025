using MangoFusion_API.Data;
using MangoFusion_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using MangoFusion_API.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace MangoFusion_API.Controllers
{
    [ApiController]
    [Route("api/MenuItem")]
    public class MenuItemController : Controller
    {

        private readonly ApplicationDbContext _db;
        private readonly ApiResponse _response;
        private readonly IWebHostEnvironment _env;

        public MenuItemController(ApplicationDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _response = new ApiResponse();
            _env = env;
        }

        [HttpGet]
        public IActionResult GetMenuItems()
        {
            _response.Result = _db.MenuItems.ToList();
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }

        [HttpGet("{id:int}", Name = "GetMenuItem")]
        public IActionResult GetMenuItem(int id)
        {
            if (id == 0)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                return BadRequest(_response);
            }
            MenuItem? menuItem = _db.MenuItems.FirstOrDefault(u => u.Id == id);
            _response.Result = menuItem;
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse>> CreateMenuItem([FromForm] MenuItemCreateDTO menuItemCreateDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (menuItemCreateDTO.File == null || menuItemCreateDTO.File.Length == 0)
                    {
                        _response.IsSuccess = false;
                        _response.StatusCode = HttpStatusCode.BadRequest;
                        _response.ErrorMessages = ["File is required."];
                        return BadRequest(_response);
                    }
                    var imagePath = Path.Combine(_env.WebRootPath, "images");
                    
                    if (!Directory.Exists(imagePath))
                    {
                        Directory.CreateDirectory(imagePath);
                    }

                    var filePath = Path.Combine(imagePath, menuItemCreateDTO.File.FileName);

                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                    // uploading the image
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await menuItemCreateDTO.File.CopyToAsync(stream);
                    }

                    MenuItem menuItem = new()
                    {
                        Name = menuItemCreateDTO.Name,
                        Description = menuItemCreateDTO.Description,
                        Category = menuItemCreateDTO.Category,
                        SpecialTag = menuItemCreateDTO.SpecialTag,
                        Price = menuItemCreateDTO.Price,
                        Image = @"images/" + menuItemCreateDTO.File.FileName
                    };

                    _db.MenuItems.Add(menuItem);
                    await _db.SaveChangesAsync();

                    _response.Result = menuItemCreateDTO;
                    _response.StatusCode = HttpStatusCode.Created;
                    return CreatedAtRoute("GetMenuItem", new { id = menuItem.Id }, _response);
                }
                else
                {
                    _response.IsSuccess = false;
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = [ex.ToString()];
                return _response;
            }

            return BadRequest(_response);
        }
        
        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<ApiResponse>> UpdateMenuItem(int id, [FromForm] MenuItemUpdateDTO menuItemUpdateDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (menuItemUpdateDTO == null || menuItemUpdateDTO.Id != id)
                    {
                        _response.IsSuccess = false;
                        _response.StatusCode = HttpStatusCode.BadRequest;
                        return BadRequest(_response);
                    }
                    
                    MenuItem? menuItemFromDb = await _db.MenuItems.FirstOrDefaultAsync(u => u.Id == id);
                    
                    if (menuItemFromDb == null)
					{
						_response.IsSuccess = false;
						_response.StatusCode = HttpStatusCode.NotFound;
						return NotFound(_response);
					}
                    
                    menuItemFromDb.Name = menuItemUpdateDTO.Name;
					menuItemFromDb.Description = menuItemUpdateDTO.Description;
					menuItemFromDb.Category = menuItemUpdateDTO.Category;
					menuItemFromDb.SpecialTag = menuItemUpdateDTO.SpecialTag;
					menuItemFromDb.Price = menuItemUpdateDTO.Price;

					if (menuItemUpdateDTO.File != null && menuItemUpdateDTO.File.Length > 0)
					{
						var imagePath = Path.Combine(_env.WebRootPath, "images");
						if (!Directory.Exists(imagePath))
						{
							Directory.CreateDirectory(imagePath);
						}
						var filePath = Path.Combine(imagePath, menuItemUpdateDTO.File.FileName);
						if (System.IO.File.Exists(filePath))
						{
							System.IO.File.Delete(filePath);
						}
						var filePathOldFile = Path.Combine(_env.WebRootPath, menuItemFromDb.Image);
						if (System.IO.File.Exists(filePathOldFile))
						{
							System.IO.File.Delete(filePathOldFile);
						}
						// uploading the image
						using (var stream = new FileStream(filePath, FileMode.Create))
						{
							await menuItemUpdateDTO.File.CopyToAsync(stream);
						}
						menuItemFromDb.Image = @"images/" + menuItemUpdateDTO.File.FileName;
					}

                    _db.MenuItems.Update(menuItemFromDb);
                    await _db.SaveChangesAsync();

                    _response.StatusCode = HttpStatusCode.NoContent;
                    return Ok(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = [ex.ToString()];
                return _response;
            }

            return BadRequest(_response);
        }
    }
}