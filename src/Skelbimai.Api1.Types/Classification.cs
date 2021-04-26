using System;
using System.Collections.Generic;
using System.Linq;

namespace Skelbimai.Api1.Types.Classification
{
  public class Classification
  {
    public class X
    {
      public Guid ID { get; set; }
    }
    public class Y
    {
      public int ID { get; set; }
    }

    public Guid ID { get; set; }
    public X Who { get; set; }
    public Y What { get; set; }
    public Actions.Action? Action { get; set; }
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
