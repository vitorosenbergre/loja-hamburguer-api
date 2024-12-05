using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyEFProject.Data;

[Route("api/[controller]")]
[ApiController]
public class StatusController : ControllerBase
{
    private readonly AppDbContext _contextStatus;

    public StatusController(AppDbContext context)
    {
        _contextStatus = context;
    }

    // GET: api/Status
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Status>>> GetStatus()
    {
        return await _contextStatus.Status.ToListAsync();
    }

    // GET: api/Status/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Status>> GetStatus(int id)
    {
        var status = await _contextStatus.Status.FindAsync(id);

        if (status == null)
        {
            return NotFound();
        }

        return status;
    }

    // POST: api/Status
    [HttpPost]
    public async Task<ActionResult<Status>> PostStatus(Status status)
    {
        _contextStatus.Status.Add(status);
        await _contextStatus.SaveChangesAsync();

        return CreatedAtAction("GetStatus", new { id = status.Id }, status);
    }

    // PUT: api/Status/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutStatus(int id, Status status)
    {
        if (id != status.Id)
        {
            return BadRequest();
        }

        _contextStatus.Entry(status).State = EntityState.Modified;

        try
        {
            await _contextStatus.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!StatusExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // DELETE: api/Status/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStatus(int id)
    {
        var status = await _contextStatus.Status.FindAsync(id);
        if (status == null)
        {
            return NotFound();
        }

        _contextStatus.Status.Remove(status);
        await _contextStatus.SaveChangesAsync();

        return NoContent();
    }

    private bool StatusExists(int id)
    {
        return _contextStatus.Status.Any(e => e.Id == id);
    }
}
