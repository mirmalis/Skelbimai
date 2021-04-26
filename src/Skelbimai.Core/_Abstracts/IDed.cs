using System;

namespace Skelbimai.Core
{
  public interface IIDed<TKey>
  {
    public TKey ID { get; set; }
  }
  public abstract class IDed : IIDed<Guid>
  {
    public Guid ID { get; set; } = Guid.NewGuid();
  }
}
