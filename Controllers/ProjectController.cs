using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManagerApp.Data;
using ProjectManagerApp.Models;

namespace ProjectManagerApp.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProjectController : ControllerBase
    {
        private readonly ProjectManagerAppContext _context;

        public ProjectController(ProjectManagerAppContext context)
        {
            _context = context;
        }


        [HttpGet("api/projects")]
        public async Task<ActionResult<IEnumerable<Project>>> Index()
        {
            return  await _context.Projects.Include(project => project.Sprint).ToListAsync();

           // return await projects.ToListAsync();
        }

        // GET: api/Project/5
        [HttpGet("api/projects/{id}")]
        public async Task<ActionResult<Project>> Show(long id)
        {
            var project = await _context.Projects.FindAsync(id);

            if (project == null)
            {
                return NotFound();
            }

            return project;
        }

        // PUT: api/Project/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("api/projects/{id}")]
        public async Task<IActionResult> Update(long id, Project project)
        {
            if (id != project.Id)
            {
                return BadRequest();
            }

            _context.Entry(project).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(id))
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

        // POST: api/Project
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("api/projects")]
        [Consumes("application/json")]
        public async Task<ActionResult<Project>> Store(Project project)
        {
            _context.Projects.Add(project);

            await _context.SaveChangesAsync();

            return CreatedAtAction("Index", new { id = project.Id }, project);
        }

        // DELETE: api/Project/5
        [HttpDelete("api/projects/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var project = await _context.Projects.FindAsync(id);

            if (project == null)
            {
                return NotFound();
            }

            _context.Projects.Remove(project);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjectExists(long id)
        {
            return _context.Projects.Any(e => e.Id == id);
        }
    }
}
