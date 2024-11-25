using BookStoreApi.Models;
using BookStoreApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GenresController : ControllerBase
{
    private readonly GenresService _genresService;

    public GenresController(GenresService genresService) =>
        _genresService = genresService;

    [HttpGet]
    public async Task<List<Genre>> Get() =>
        await _genresService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Genre>> Get(string id)
    {
        var genre = await _genresService.GetAsync(id);

        if (genre is null)
        {
            return NotFound();
        }

        return genre;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Genre newGenre)
    {
        await _genresService.CreateAsync(newGenre);

        return CreatedAtAction(nameof(Get), new { id = newGenre.Id }, newGenre);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Genre updatedGenre)
    {
        var genre = await _genresService.GetAsync(id);

        if (genre is null)
        {
            return NotFound();
        }

        updatedGenre.Id = genre.Id;

        await _genresService.UpdateAsync(id, updatedGenre);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var genre = await _genresService.GetAsync(id);

        if (genre is null)
        {
            return NotFound();
        }

        await _genresService.RemoveAsync(id);

        return NoContent();
    }
}