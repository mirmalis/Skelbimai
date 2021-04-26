using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skelbimai.Api1.Helpers
{
  internal static class Skelbimas
  {
    internal static Core.Skelbimas Core(Types.Skelbimas.POST.SkelbimasCreateData data) => new Core.Skelbimas() {
      ID = data.ID,
      Body = data.Body,
      BodyShort = data.BodyShort,
      Header = data.Header
    };
    public class SkelbimasDeep : Types.Skelbimas.GET.Skelbimas
    {
      public SkelbimasDeep(int? id, Core.Skelbimas core) : base()
      {
        ID = Calc.ID(id, core);
        this.Header = core.Header;
        this.Body = core.Body;
        this.BodyShort = core.BodyShort;
      }
      public static IQueryable<Core.User> Includes(IQueryable<Core.User> Q)
        => Q
      ;
    }
  }
}
