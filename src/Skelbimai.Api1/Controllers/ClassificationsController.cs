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
  public class ClassificationsController : ControllerBase
  {
    #region Privates
    private readonly SkelbimaiContext _context;

    public ClassificationsController(SkelbimaiContext context)
    {
      _context = context;
    }
    private bool SkelbimasClassificationExists(Guid id)
    {
      return _context.Classifications.Any(e => e.ID == id);
    }
    #endregion
    #region GET
    // GET: api/Classifications
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Types.Classification.Classification>>> GetClassifications(Guid? userID, int? skelbimasID)
    {
      
      return await this._context.Classifications
        .Where(item => (userID == null || item.UserID == userID.Value) && (skelbimasID == null || item.SkelbimasID == skelbimasID))
        .Select(item => new Helpers.Classification.ClassificationDeep(null, item))
        .ToListAsync();
    }

    //// GET: api/Classifications/5
    //[HttpGet("{id}")]
    //public async Task<ActionResult<SkelbimasClassification>> GetSkelbimasClassification(Guid id)
    //{
    //  var skelbimasClassification = await _context.Classifications.FindAsync(id);

    //  if(skelbimasClassification == null) {
    //    return NotFound();
    //  }

    //  return skelbimasClassification;
    //} 
    #endregion

    //// PUT: api/Classifications/5
    //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    //[HttpPut("{id}")]
    //public async Task<IActionResult> PutSkelbimasClassification(Guid id, SkelbimasClassification skelbimasClassification)
    //{
    //  if(id != skelbimasClassification.ID) {
    //    return BadRequest();
    //  }

    //  _context.Entry(skelbimasClassification).State = EntityState.Modified;

    //  try {
    //    await _context.SaveChangesAsync();
    //  } catch(DbUpdateConcurrencyException) {
    //    if(!SkelbimasClassificationExists(id)) {
    //      return NotFound();
    //    } else {
    //      throw;
    //    }
    //  }

    //  return NoContent();
    //}

    // POST: api/Classifications
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Types.Classification.Classification>> PostSkelbimasClassification(Types.Classification.Post.ClassificationCreateData data)
    {
      if(!_context.Users.Any(item => item.ID == data.WhoID)) {
        return BadRequest("User doesn't exist.");
      }
      if(!_context.Skelbimai.Any(item => item.ID == data.What.ID )) {
        await new SkelbimasController(_context)
          .PostSkelbimas(data.What)
        ;
        //return BadRequest("Skelbimas doesn't exist.");
      }

      var skelbimasClassification = Helpers.Classification.Core(data);
      _context.Classifications.Add(skelbimasClassification);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetClassifications", new { userID = skelbimasClassification.UserID, skelbimasID = skelbimasClassification.SkelbimasID }, 
        new Helpers.Classification.ClassificationDeep(null, skelbimasClassification)
      );
    }

    //// DELETE: api/Classifications/5
    //[HttpDelete("{id}")]
    //public async Task<IActionResult> DeleteSkelbimasClassification(Guid id)
    //{
    //  var skelbimasClassification = await _context.Classifications.FindAsync(id);
    //  if(skelbimasClassification == null) {
    //    return NotFound();
    //  }

    //  _context.Classifications.Remove(skelbimasClassification);
    //  await _context.SaveChangesAsync();

    //  return NoContent();
    //}


  }
}
