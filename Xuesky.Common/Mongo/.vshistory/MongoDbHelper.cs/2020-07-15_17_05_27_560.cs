using MongoDB.Driver;

namespace Xuesky.Common.MongoDB
{
    /// <summary>  
    /// Mongo db的数据库帮助类  
    /// </summary>  
    public class MongoDbHelper
    {
        /// <summary>  
        /// 数据库的实例  
        /// </summary>  
        private IMongoDatabase _db;

        /// <summary>  
        /// ObjectId的键  
        /// </summary>  

        public MongoDbHelper(string host, string timeOut)
        {
            this._db = new MongodbInit(host, timeOut).GetDataBase();
        }

        public MongoDbHelper(IMongoDatabase db)
        {
            this._db = db;
        }
    }
}
