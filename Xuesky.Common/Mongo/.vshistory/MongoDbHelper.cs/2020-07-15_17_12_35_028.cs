using MongoDB.Driver;
using System.Collections.Generic;

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

        public MongoDbHelper(string host, string dbName, int timeOut)
        {
            this._db = new MongodbInit(host, dbName, timeOut).GetDataBase();
        }
        #region INSERT
        ///<summary>
        /// 插入单条数据
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        /// </summary>
        public T InsertOne<T>(T data)
        {
            var collection = _db.GetCollection<T>(typeof(T).Name);
            collection.InsertOne(data);
            return data;
        }
        ///<summary>
        /// 插入多条数据，数据用list表示
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        /// </summary>
        public List<T> InsertMany<T>(List<T> list)
        {
            var collection = _db.GetCollection<T>(typeof(T).Name);
            collection.InsertMany(list);
            return list;
        }
        #endregion
    }
}
