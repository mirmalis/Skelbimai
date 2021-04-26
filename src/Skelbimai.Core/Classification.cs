using System;
using System.Collections.Generic;
using System.Linq;

namespace Skelbimai.Core
{
  public enum SkelbimasAction { Unknown, Show, Hide }
  public class Classification : IDed
  {
    public User User { get; set; } public Guid UserID { get; set; }
    public Skelbimas Skelbimas { get; set; } public int SkelbimasID { get; set; }
    public SkelbimasAction Action { get; set; }
  }
}
