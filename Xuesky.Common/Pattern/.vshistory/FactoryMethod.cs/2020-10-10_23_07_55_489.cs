using System;
namespace Xuesky.Common.Pattern
{
    public class FactoryMethod
    {
        
    }
    public abstract class Mouse
    {
        public abstract void print();
    }
    public class DellMouse:Mouse
    {
        public void print(){
          System.Console.WriteLine("DellMouse");
        }
    }
        public class HPMouse:Mouse
    {
        public void print(){
          System.Console.WriteLine("HpMouse");
        }
    }
    public abstract class MouseFactory
    {
        public abstract Mouse CreateMouse();
    }
    public DellMouseFactory:MouseFactory
    {
      
    }
    
}