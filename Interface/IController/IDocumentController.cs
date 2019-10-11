using Microsoft.AspNetCore.Mvc;
using ProjectPFE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectPFE.Interface.IController
{
    public interface IDocumentController
    {
        IEnumerable<Document> GetAllDocument();
        Task<IActionResult> GetDocumentAsync([FromRoute] Guid id);
        [HttpPost]
        Task<IActionResult> PostDocumentAsync([FromBody] Document document);
        Task<IActionResult> DeleteDocumentAsync([FromRoute] Guid id);
        Task<IActionResult> Update(Guid id, [FromBody] Document document);

    }
}
