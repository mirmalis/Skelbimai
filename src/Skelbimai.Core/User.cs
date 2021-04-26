using System;
using System.Collections.Generic;
using System.Linq;

namespace Skelbimai.Core
{
  public class User : IDed
  {
    public string Name { get; set; }

    public ICollection<Classification> Groupings { get; set; }
  }
}