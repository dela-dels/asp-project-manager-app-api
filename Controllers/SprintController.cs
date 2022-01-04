using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManagerApp.Data;
using ProjectManagerApp.Models;

namespace ProjectManagerApp.Controllers
{
    [ApiController]
    public class SprintController : ControllerBase
    {
        private readonly ProjectManagerAppContext _context;

        public SprintController(ProjectManagerAppContext context)
        {
            _context = context;
        }

        // GET: api/Sprint
        [HttpGet("api/sprints")]
        public async Task<ActionResult<IEnumerable<Sprint>>> Index()
        {
            return await _context.Sprints.Include("Project").ToListAsync();
        }

        // GET: api/Sprint/5
        [HttpGet("api/sprints/{id}")]
        public async Task<ActionResult<Sprint>> Show(long id)
        {
            var sprint = await _context.Sprints.FindAsync(id);

            if (sprint == null)
            {
                return NotFound();
            }

            return sprint;
        }

        // PUT: api/Sprint/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("api/sprints/{id}")]
        public async Task<IActionResult> Update(long id, Sprint sprint)
        {
            if (id != sprint.Id)
            {
                return BadRequest();
            }

            _context.Entry(sprint).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SprintExists(id))
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

        // POST: api/Sprint
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("api/sprints")]
        public async Task<ActionResult<Sprint>> Store(Sprint sprint)
        {
            _context.Sprints.Add(sprint);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Index", new { id = sprint.Id }, sprint);
        }

        // DELETE: api/Sprint/5
        [HttpDelete("api/sprints/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var sprint = await _context.Sprints.FindAsync(id);
            if (sprint == null)
            {
                return NotFound();
            }

            _context.Sprints.Remove(sprint);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SprintExists(long id)
        {
            return _context.Sprints.Any(e => e.Id == id);
        }
    }
}
