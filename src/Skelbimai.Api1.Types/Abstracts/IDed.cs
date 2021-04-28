using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skelbimai.Api1.Types
{
  public interface IIDed<TKey>
  {
    public TKey ID { get; set; }
  }
  public class IDed : IIDed<Guid>
  {
    public Guid ID { get; set; }
  }
}
