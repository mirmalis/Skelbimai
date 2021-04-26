using System;
using System.Collections.Generic;
using System.Linq;

namespace Skelbimai.Api1.Types.Classification
{
  public interface I
  {
    public Guid ID { get; set; }
  }
  public class Classification_UserID_SkelbimasID : I
  {
    public Guid ID { get; set; }
    public Actions.Action? Action { get; set; }
  }
  public class Classification : I
  {
    public class X : IDed { }
    public class Y : IIDed<int>
    {
      public int ID { get; set; }
    }

    public Guid ID { get; set; }
    public X User { get; set; }
    public Y What { get; set; }
    public Actions.Action? Action { get; set; }
  }
  namespace Put
  {
    public class ClassificationUpdateData
    {
      public Actions.Action Action { get; set; }
    }
  }
  namespace Post
  {
    public class ClassificationCreateData
    {
      public Guid WhoID { get; set; }
      public Skelbimas.POST.SkelbimasCreateData What { get;set; }
      public Actions.Action Action { get; set; }
    }
  }
}
