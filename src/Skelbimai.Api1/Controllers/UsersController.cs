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
  public class UsersController : ControllerBase
  {
    #region Privates
    private readonly SkelbimaiContext _context;

    public UsersController(SkelbimaiContext context)
    {
      _context = context;
    }

    private bool UserExists(Guid id)
    {
      return _context.Users.Any(e => e.ID == id);
    }
    #endregion

    #region GET
    //[HttpGet] // GET: api/Users
    //public async Task<ActionResult<IEnumerable<Types.User.Get.User>>> GetUsers()
    //{
    //  return await _context.Users
    //    .Select(item => new Helpers.User.UserDeep(null, item))
    //    .ToListAsync()
    //  ;
    //}
    [HttpGet("{id}")] // GET: api/Users/5
    public async Task<ActionResult<Types.User.Get.User>> GetUser(Guid id)
    {
      var user = await Helpers.User.UserDeep.Includes(_context.Users)
        .FirstOrDefaultAsync(item => item.ID == id);
      if(user == null) {
        return NotFound();
      }
      return new Helpers.User.UserDeep(null, user);
    }
    #endregion
    #region PUT
    //// PUT: api/Users/5
    //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    //[HttpPut("{id}")]
    //public async Task<IActionResult> PutUser(Guid id, User user)
    //{
    //  if(id != user.ID) {
    //    return BadRequest();
    //  }

    //  _context.Entry(user).State = EntityState.Modified;

    //  try {
    //    await _context.SaveChangesAsync();
    //  } catch(DbUpdateConcurrencyException) {
    //    if(!UserExists(id)) {
    //      return NotFound();
    //    } else {
    //      throw;
    //    }
    //  }

    //  return NoContent();
    //} 
    #endregion
    #region POST
    // POST: api/Users
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Types.User.Get.User>> PostUser(Types.User.Post.Create data)
    {
      var user = Helpers.User.Core(data);
      _context.Users.Add(user);
      await _context.SaveChangesAsync();
      return CreatedAtAction("GetUser", new { id = user.ID }, new Helpers.User.UserDeep(null, user));
    }
    #endregion
    #region DELETE
    //// DELETE: api/Users/5
    //[HttpDelete("{id}")]
    //public async Task<IActionResult> DeleteUser(Guid id)
    //{
    //  var user = await _context.Users.FindAsync(id);
    //  if(user == null) {
    //    return NotFound();
    //  }

    //  _context.Users.Remove(user);
    //  await _context.SaveChangesAsync();

    //  return NoContent();
    //}
    #endregion
  }
}
