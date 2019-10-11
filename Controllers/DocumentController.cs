using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectPFE.Interface.IController;
using ProjectPFE.Interface.IServices;
using ProjectPFE.Models;
using ProjectPFE.Models.DBContext;

namespace ProjectPFE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class DocumentController : ControllerBase, IDocumentController
    {
        private readonly IDocumentServices _ServicesDocument;
        private readonly ApplicationContext _context;


        public DocumentController(IDocumentServices serviceDocument , ApplicationContext context)
        {
            _ServicesDocument = serviceDocument;
            _context = context;
        }
     
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocumentAsync([FromRoute] Guid id)
        {
            try
            {
                return Ok(await _ServicesDocument.DeleteAsync(id));
            }
            catch (Exception ex )
            {
                throw ex;
            }
        }
        [HttpGet]
        public IEnumerable<Document> GetAllDocument()
        {
            return _ServicesDocument.GetAllAsync();
        }
        
        [Route("{id}")]
        [HttpGet]

        public async Task<IActionResult> GetDocumentAsync([FromRoute] Guid id)
        {
            try
            {
                return Ok(await _ServicesDocument.GetByIdAsync(id));
            }
            catch (Exception)
            {
                return NotFound();

            }
        }
        



        /***get doc by vehicule id **/


        [HttpGet("{VehiculeId}", Name = "GetByID")]
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

















        [HttpPost]
        public async Task<IActionResult> PostDocumentAsync([FromBody] Document document)
        {
            var createdEntity = await _ServicesDocument.AddAsync(document);
            return CreatedAtAction(nameof(GetDocumentAsync), new { id = createdEntity.DocumentId }, createdEntity);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Document document)
        {
            try
            {
                await _ServicesDocument.UpdateAsync(id, document);

                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}