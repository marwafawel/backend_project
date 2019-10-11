using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectPFE.Models;
using ProjectPFE.Models.DBContext;

namespace ProjectPFE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DocumentsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public DocumentsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Documents
        [HttpGet]
        public IEnumerable<Document> GetDocuments()
        {
            return _context.Documents;
        }

        // GET: api/Documents/5
       /* [HttpGet("{id}")]
        public async Task<IActionResult> GetDocument([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var document = await _context.Documents.FindAsync(id,id);

            if (document == null)
            {
                return NotFound();
            }

            return Ok(document);
        }*/
        [HttpGet("{VehiculeId}", Name = "GetByvehID")]
        public IQueryable<Document> GetByAsync(Guid VehiculeId)
        {
            try
            {
                return _context.Documents.Where(u => u.VehiculeId == VehiculeId);

            }
            catch (Exception)
            {

                throw;
            }

        }

        // PUT: api/Documents/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocument([FromRoute] Guid id, [FromBody] Document document)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != document.DocumentId)
            {
                return BadRequest();
            }

            _context.Entry(document).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocumentExists(id))
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

        // POST: api/Documents
        [HttpPost]
        public async Task<IActionResult> PostDocument([FromBody] Document document)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Documents.Add(document);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DocumentExists(document.DocumentId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDocument", new { id = document.DocumentId }, document);
        }

        // DELETE: api/Documents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocument([FromRoute] Guid id)
        {
            try { 
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var document =  _context.Documents.FirstOrDefault(e => e.DocumentId == id);
               
                if (document == null)
            {
                return NotFound();
            }

            _context.Documents.Remove(document);
                SaveChanges(_context);

                return Ok(document);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private static void SaveChanges(ApplicationContext ctx)
        {
            bool saveFailed;
            do
            {
                saveFailed = false;

                try
                {
                    ctx.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    saveFailed = true;
                    //System.Diagnostics.Trace.TraceWarning("{1}------DbUpdateConcurrencyException {0}", ex.ToString(), DateTime.Now);
                    // Update the values of the entity that failed to save from the store
                    ex.Entries.Single().Reload();
                }

            } while (saveFailed);
        }

        private bool DocumentExists(Guid id)
        {
            return _context.Documents.Any(e => e.DocumentId == id);
        }
    }
}