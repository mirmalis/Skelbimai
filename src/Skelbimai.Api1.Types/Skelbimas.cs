using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skelbimai.Api1.Types.Skelbimas
{
  namespace GET
  {
    public class Skelbimas
    {
      public int ID { get; set; }
      public string Header { get; set; }
      public string Body { get; set; }
      public string BodyShort { get; set; }
    }
  }
  namespace POST
  {
    public class SkelbimasCreateData
    {
      public int ID { get; set; }
      public string Header { get; set; }
      public string Body { get; set; }
      public string BodyShort { get; set; }
    }
  }
}
