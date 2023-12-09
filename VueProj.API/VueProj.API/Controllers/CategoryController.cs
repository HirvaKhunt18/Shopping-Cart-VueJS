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
    public class CategoryController : ControllerBase
    {
        private readonly ProductDbContext _context;
        public CategoryController(ProductDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> Get()
        {
            return await _context.Category.OrderBy(x => x.CategoryId).ToListAsync();
        }

    }
}
