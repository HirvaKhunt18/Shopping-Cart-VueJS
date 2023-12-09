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
    public class OrderController : ControllerBase
    {
        private readonly ProductDbContext _context;
        public OrderController(ProductDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Orders>>> Get()
        {
            return await _context.Order.OrderBy(x => x.OrderId).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Orders>> Create([FromForm] Orders order)
        {
            _context.Order.Add(order);
            await _context.SaveChangesAsync();

            return Ok();
        }

    }
}
