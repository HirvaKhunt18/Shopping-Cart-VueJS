using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueProj.API.Models;
using VueProj.Lib;

namespace VueProj.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagesController : ControllerBase
    {
        private readonly ProductDbContext _context;
        public PagesController(ProductDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pages>>> Get()
        {
            return await _context.Pages.OrderBy(x => x.PageId).ToListAsync();
        }
        //api/Product/categoryName

        [HttpPost]
        public async Task<ActionResult<Pages>> CreateUpdate([FromForm] Pages pages)
        {
            if (pages.PageId > 0)
            {
                _context.Pages.Update(pages);
                await _context.SaveChangesAsync();
            }
            else
            {
                _context.Pages.Add(pages);
                await _context.SaveChangesAsync();
            }
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Pages>> Delete(int id)
        {
            var pages = await _context.Pages.FindAsync(id);
            _context.Pages.Remove(pages);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
