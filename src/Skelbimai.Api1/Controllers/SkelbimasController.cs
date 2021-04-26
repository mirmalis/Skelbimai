using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Skelbimai.Core;
using Skelbimai.Db;

namespace Skelbimai.Api1.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SkelbimasController : ControllerBase
  {
    #region Privates
    private readonly SkelbimaiContext _context;
    public SkelbimasController(SkelbimaiContext context)
    {
      _context = context;
    }
    private bool SkelbimasExists(int id)
    {
      return _context.Skelbimai.Any(e => e.ID == id);
    }
    #endregion
    #region GET
    // GET: api/Skelbimas
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Types.Skelbimas.GET.Skelbimas>>> GetSkelbimai()
    {
      return await _context.Skelbimai
        .Select(item => new Helpers.Skelbimas.SkelbimasDeep(null, item))
        .ToListAsync();
    }
    // GET: api/Skelbimas/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Types.Skelbimas.GET.Skelbimas>> GetSkelbimas(int id)
    {
      var skelbimas = await _context.Skelbimai
        .FirstOrDefaultAsync(item => item.ID == id);

      if(skelbimas == null) {
        return NotFound();
      }

      return new Helpers.Skelbimas.SkelbimasDeep(null, skelbimas);
    }
    #endregion
    #region PUT
    //// PUT: api/Skelbimas/5
    //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    //[HttpPut("{id}")]
    //public async Task<IActionResult> PutSkelbimas(int id, Skelbimas skelbimas)
    //{
    //  if(id != skelbimas.ID) {
    //    return BadRequest();
    //  }

    //  _context.Entry(skelbimas).State = EntityState.Modified;

    //  try {
    //    await _context.SaveChangesAsync();
    //  } catch(DbUpdateConcurrencyException) {
    //    if(!SkelbimasExists(id)) {
    //      return NotFound();
    //    } else {
    //      throw;
    //    }
    //  }

    //  return NoContent();
    //} 
    #endregion
    #region POST
    // POST: api/Skelbimas
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Types.Skelbimas.GET.Skelbimas>> PostSkelbimas(Types.Skelbimas.POST.SkelbimasCreateData data)
    {
      var skelbimas = Helpers.Skelbimas.Core(data);
      _context.Skelbimai.Add(skelbimas);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetSkelbimas", new { id = skelbimas.ID }, new Helpers.Skelbimas.SkelbimasDeep(null, skelbimas));
    }
    #endregion
    #region DELETE
    //// DELETE: api/Skelbimas/5
    //[HttpDelete("{id}")]
    //public async Task<IActionResult> DeleteSkelbimas(int id)
    //{
    //  var skelbimas = await _context.Skelbimai.FindAsync(id);
    //  if(skelbimas == null) {
    //    return NotFound();
    //  }

    //  _context.Skelbimai.Remove(skelbimas);
    //  await _context.SaveChangesAsync();

    //  return NoContent();
    //} 
    #endregion
  }
}
