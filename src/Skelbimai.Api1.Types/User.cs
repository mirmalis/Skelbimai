using System;
using System.Collections.Generic;

namespace Skelbimai.Api1.Types.User
{
  namespace Get
  {
    public interface I {
      public Guid ID { get; set; }
      public string Name { get; set; }
    }
    public class User : I {
      public class UsersSkelbimas
      {
        public int ID { get; set; }
        //public Actions.Action Action { get; set; }
      }
      public Guid ID { get; set; }
      public string Name { get; set; }
      public IEnumerable<UsersSkelbimas> Hide { get; set; }
      public IEnumerable<UsersSkelbimas> Show { get; set; }
    }
  }
  namespace Post
  {
    public class Create
    {
      public string Name { get; set; }
    }
  }
}
