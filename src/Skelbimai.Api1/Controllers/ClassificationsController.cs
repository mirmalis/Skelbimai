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
    [HttpGet("{id}")]
    public async Task<ActionResult<Types.Classification.Classification>> GetSkelbimasClassification(Guid id)
    {
      var skelbimasClassification = await _context.Classifications.FirstOrDefaultAsync(item => item.ID == id);

      if (skelbimasClassification == null)
      {
        return NotFound();
      }

      return new Helpers.Classification.ClassificationDeep(null, skelbimasClassification);
    }
    [HttpGet("{userID}/{skelbimasID}")]
    public async Task<ActionResult<Types.Classification.Classification_UserID_SkelbimasID>> GetSkelbimasClassification(Guid userID, int skelbimasID)
    {
      var classification = await Helpers.Classification.Classification_UserID_SkelbimasID.Includes(_context.Classifications)
        .FirstOrDefaultAsync(item => item.UserID == userID && item.SkelbimasID == skelbimasID);

      if (classification == null)
      {
        return NotFound();
      }

      return new Helpers.Classification.Classification_UserID_SkelbimasID(null, classification);
    }
    [HttpGet("{userID}/{skelbimasID}/action")]
    public async Task<ActionResult<Types.Actions.Action>> GetSkelbimasClassificationAction(Guid userID, int skelbimasID)
    {

      var classification = await Helpers.Classification.Classification_UserID_SkelbimasID.Includes(_context.Classifications)
        .FirstOrDefaultAsync(item => item.UserID == userID && item.SkelbimasID == skelbimasID);

      if (classification == null)
      {
        return Types.Actions.Action.Unknown;
      }

      return new Helpers.Classification.Classification_UserID_SkelbimasID(null, classification).Action;// TODO: simplify
    }
    #endregion
    #region PUT
    // PUT: api/Classifications/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<ActionResult<Types.Classification.Classification>> PutSkelbimasClassification(Guid id, Types.Classification.Put.ClassificationUpdateData data)
    {
      var skelbimasClassification = Helpers.Classification.Core(_context.Classifications.Find(id), data);
      
      if (id != skelbimasClassification.ID)
      {
        return BadRequest();
      }
      
      _context.Entry(skelbimasClassification).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!SkelbimasClassificationExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }
      return new Helpers.Classification.ClassificationDeep(null, skelbimasClassification);
      //return NoContent();
    }
    #endregion
    #region POST
    // POST: api/Classifications
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Types.Classification.Classification>> PostSkelbimasClassification(Types.Classification.Post.ClassificationCreateData data)
    {
      if (!_context.Users.Any(item => item.ID == data.Who.ID))
      {
        return BadRequest("User doesn't exist.");
      }
      if (!_context.Skelbimai.Any(item => item.ID == data.What.ID))
      {
        await new SkelbimasController(_context)
          .PostSkelbimas(data.What)
        ;
        //return BadRequest("Skelbimas doesn't exist.");
      }
      var x = await _context.Classifications.FirstOrDefaultAsync(item => item.SkelbimasID == data.What.ID && item.UserID == data.Who.ID);
      if (x != null)
      {
        return await PutSkelbimasClassification(x.ID, Helpers.Classification.UpdateData(data));
        //return BadRequest("Assignment from this User to this Skelbimas already exist.");
        //return await PutSkelbimasClassification(, );
      }

      var skelbimasClassification = Helpers.Classification.Core(data);
      _context.Classifications.Add(skelbimasClassification);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetClassifications", new { userID = skelbimasClassification.UserID, skelbimasID = skelbimasClassification.SkelbimasID },
        new Helpers.Classification.ClassificationDeep(null, skelbimasClassification)
      );
    }
    #endregion
    #region DELETE
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
    #endregion
  }
}
