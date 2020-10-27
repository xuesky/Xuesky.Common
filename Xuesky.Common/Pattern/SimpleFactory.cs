namespace Xuesky.Common.Pattern
{
    /// <summary>
    /// 简单工厂
    /// </summary>
    public class SimpleFactory
    {
        public static ISQLAccess GetSQLAccess(string name)
        {
            switch (name)
            {
                case "ms":
                  return new MySqlAccess();
                default:
                  return new MySqlAccess();
            }
        }
    }
    public interface ISQLAccess
    {

    }
    public class MySqlAccess:ISQLAccess{

    }
}
