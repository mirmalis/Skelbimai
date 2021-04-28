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
        UserID = data.Who.ID,
        SkelbimasID = data.What.ID,
        Action = CoreAction(data.Action)
      };
    }
    internal static Core.Classification Core(Core.Classification core, Types.Classification.Put.ClassificationUpdateData data)
    {
      if(data.Action != null)
        core.Action = CoreAction(data.Action);
      return core;
    }
    internal static Types.Classification.Put.ClassificationUpdateData UpdateData(Types.Classification.Post.ClassificationCreateData createData)
    {
      return new Types.Classification.Put.ClassificationUpdateData() {
        Action = createData.Action
      };
    }
    internal class ClassificationDeep : Types.Classification.Classification
    {
      #region Constructors
      public ClassificationDeep(Guid? id, Core.Classification core) : base()
      {
        ID = Calc.ID(id, core);
        this.User = new() { ID = core.UserID };
        this.What = new() { ID = core.SkelbimasID };
        this.Action = TypesAction(core.Action);
      }
      #endregion
      public static IQueryable<Core.Classification> Includes(IQueryable<Core.Classification> Q)
        => Q
      ;
    }
    internal class Classification_UserID_SkelbimasID  : Types.Classification.Classification_UserID_SkelbimasID
    {
      #region Constructors
      public Classification_UserID_SkelbimasID(Guid? id, Core.Classification core) : base()
      {
        ID = Calc.ID(id, core);
        this.Action = TypesAction(core.Action);
      }
      #endregion
      public static IQueryable<Core.Classification> Includes(IQueryable<Core.Classification> Q)
        => Q
      ;
    }
    #region Converters
    static Types.Actions.Action? TypesAction(Core.SkelbimasAction core) =>
     core switch {
       Skelbimai.Core.SkelbimasAction.Hide => Types.Actions.Action.Hide,
       Skelbimai.Core.SkelbimasAction.Show => Types.Actions.Action.Show,
       Skelbimai.Core.SkelbimasAction.Unknown => null,
       _ => throw new Exception($"Cannot convert {core} to Public Action.")
     };
    static Core.SkelbimasAction CoreAction(Types.Actions.Action? type) {
      if(type == null)
        return Skelbimai.Core.SkelbimasAction.Unknown;
      return type switch {
        Types.Actions.Action.Hide => Skelbimai.Core.SkelbimasAction.Hide,
        Types.Actions.Action.Show => Skelbimai.Core.SkelbimasAction.Show,
        _ => Skelbimai.Core.SkelbimasAction.Unknown
      };
    }
    #endregion
  }
}
