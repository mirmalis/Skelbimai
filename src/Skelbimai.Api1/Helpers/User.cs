using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skelbimai.Api1.Helpers
{
  internal static class User
  {
    internal static Core.User Core(Types.User.Post.Create data)
    {
      return new Core.User() {
        Name = data.Name
      };
    }
    public class UserDeep : Types.User.Get.User
    {
      public UserDeep(Guid? id, Core.User core) : base()
      {
        ID = Calc.ID(id, core);
        Name = core.Name;
        Hide = core.Groupings?.Where(item => item.Action == Skelbimai.Core.SkelbimasAction.Hide)
          .Select(item => new Types.User.Get.User.UsersSkelbimas() {
            ID = item.SkelbimasID
          });
        Show = core.Groupings?.Where(item => item.Action == Skelbimai.Core.SkelbimasAction.Show)
          .Select(item => new Types.User.Get.User.UsersSkelbimas() {
            ID = item.SkelbimasID
          });
      }
      public static IQueryable<Core.User> Includes(IQueryable<Core.User> Q)
        => Q
          .Include(item => item.Groupings)
      ;
    }
  }
}
