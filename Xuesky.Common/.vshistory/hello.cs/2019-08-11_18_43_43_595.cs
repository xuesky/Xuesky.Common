using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Xuesky.Common
{
    interface IUserInfo{
      List<string> GetUser();
    }
  public class UserInfo : IUserInfo
  {
    public List<string> GetUser()
    {
      var list = new List<string>(new string[] {"1","2"});
      return list;
    }
  }
}