using Coffee.Api.Models;
using Coffee.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Coffee.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CoffeeController : ControllerBase
{
    private readonly ICoffeeRepository _coffeeRepository;

    public CoffeeController(ICoffeeRepository coffeeRepository)
    {
        _coffeeRepository = coffeeRepository;
    }

    [HttpGet]
    public List<CoffeeRecord> Get()
    {
        var records = _coffeeRepository.Get().OrderByDescending(x => x.DateCreated).ToList();

        return records;
    }

    [HttpGet("{id}")]
    public CoffeeRecord GetById(int id)
    {
        var record = _coffeeRepository.GetById(id);

        return record;
    }

    [HttpPost]
    public IActionResult InsertCategory(CoffeeRecord record)
    {
        try
        {
            _coffeeRepository.Add(record);
        }
        catch
        {
            return Ok(new { Success = false });
        }

        return Ok(new { Success = true });
    }
}

