using System;
namespace Xuesky.Common.Pattern
{
  public class Observer
  {

    public Observer()
    {
      Cat cat = new Cat { name = "heheheheh" };
      Mouse mouse1 = new Mouse("老黄", cat);
      Mouse mouse2 = new Mouse("老灰", cat);
      Mouse mouse3 = new Mouse("老小白", cat);
      cat.CatGo();
    }
  }
  public class Cat
  {
    public string name { get; set; }
    public void CatGo(){
      System.Console.WriteLine($"老猫:${this.name},真的来了，哈哈");
      CatComing?.Invoke();
    }
    public event Action CatComing;
  }
  public class Mouse
  {
    public Mouse(string name, Cat cat)
    {
      this.name = name;
      cat.CatComing += GoAway;
    }
    private string name { get; set; }

    private void GoAway()
    {
      System.Console.WriteLine($"老鼠:{this.name}说老猫来了，赶快跑");
    }
  }
}