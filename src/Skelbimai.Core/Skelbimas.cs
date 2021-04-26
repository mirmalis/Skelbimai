using System;

namespace Skelbimai.Core
{
  public class Skelbimas : IIDed<int>
  {
    public int ID { get; set; }
    public string Header { get; set; }
    public string Body { get; set; }
    public string BodyShort { get; set; }
  }
}
