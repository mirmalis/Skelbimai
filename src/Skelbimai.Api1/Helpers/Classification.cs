using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skelbimai.Api1.Helpers
{
  internal static class Classification
  {
    internal static Core.Classification Core(Types.Classification.Post.ClassificationCreateData data)
    {
      return new Core.Classification() {
        UserID = data.WhoID,
        SkelbimasID = data.What.ID,
        Action = ConvertAction(data.Action)
      };
    }
    internal class ClassificationDeep : Types.Classification.Classification
    {
      #region Constructors
      public ClassificationDeep(Guid? id, Core.Classification core) : base()
      {
        ID = Calc.ID(id, core);
        this.Who = new X { ID = core.UserID };
        this.What = new Y { ID = core.SkelbimasID };
        this.Action = ConvertAction(core.Action);
      }
      #endregion
      public static IQueryable<Core.User> Includes(IQueryable<Core.User> Q)
        => Q
      ;
    }
    #region Converters
    static Types.Actions.Action? ConvertAction(Core.SkelbimasAction core) =>
     core switch {
       Skelbimai.Core.SkelbimasAction.Hide => Types.Actions.Action.Hide,
       Skelbimai.Core.SkelbimasAction.Show => Types.Actions.Action.Show,
       _ => throw new Exception($"Cannot convert {core} to Public Action.")
     };
    static Core.SkelbimasAction ConvertAction(Types.Actions.Action type) => type switch {
      Types.Actions.Action.Hide => Skelbimai.Core.SkelbimasAction.Hide,
      Types.Actions.Action.Show => Skelbimai.Core.SkelbimasAction.Show,
      _ => Skelbimai.Core.SkelbimasAction.Unknown
    };
    #endregion
  }
}
