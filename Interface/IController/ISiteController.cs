using Microsoft.AspNetCore.Mvc;
using ProjectPFE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectPFE.Interface.IController
{
    public interface ISiteController
    {
        IEnumerable<Site> GetAllSites();
        Task<IActionResult> GetSiteAsync([FromRoute] Guid id);
        [HttpPost]
        Task<IActionResult> PostSiteAsync([FromBody] Site site);
        Task<IActionResult> DeleteSiteAsync([FromRoute] Guid id);
        Task<IActionResult> Update(Guid id, [FromBody] Site site);
    }
}
