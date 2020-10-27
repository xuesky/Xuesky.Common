namespace Xuesky.Common.Pattern
{
  /// <summary>
  /// 工厂模式
  /// </summary>
  public class FactoryMethod
  {
    public FactoryMethod()
    {
        IMouse dellMouse = new DellMouseFactory().CreateMouse();
        dellMouse.print();
        var hpMouse = new HPMouseFactory().CreateMouse();
    }
  }
  public interface IMouse
  {
    void print();
  }
  public class DellMouse : IMouse
  {
    public void print()
    {
      System.Console.WriteLine("我要生产DellMouse");
    }
  }
  public class HPMouse : IMouse
  {
    public void print()
    {
      System.Console.WriteLine("HPMouse");
    }
  }
  public abstract class MouseFactory
  {
    public abstract IMouse CreateMouse();
  }
  public class DellMouseFactory : MouseFactory
  {
    public override IMouse CreateMouse()
    {
      return new DellMouse();
    }
  }
  public class HPMouseFactory : MouseFactory
  {
    public override IMouse CreateMouse()
    {
      return new HPMouse();
    }
  }
}