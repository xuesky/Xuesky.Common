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
        /// <param name="data"></param>
        /// <returns></returns>
        /// </summary>
        public T InsertOne<T>(T data) where T : EntityBase, new()
        {
            var collection = _db.GetCollection<T>(typeof(T).Name);
            collection.InsertOne(data);
            return data;
        }
        ///<summary>
        /// 插入多条数据，数据用list表示
        /// <param name="list"></param>
        /// <returns></returns>
        /// </summary>

        public List<T> InsertMany<T>(List<T> list) where T : EntityBase, new()
        {
            var collection = _db.GetCollection<T>(typeof(T).Name);
            collection.InsertMany(list);
            return list;
        }
        #endregion
        #region REPLACE
        ///<summary>
        /// 根据主键更新数据
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// </summary>
        public T ReplaceOne<T>(string id, T data) where T : EntityBase, new()
        {
            var collection = _db.GetCollection<T>(typeof(T).Name);
            collection.ReplaceOne(o => o.Id == id, data);
            return data;
        }
        #endregion
        #region UPDATE
        ///<summary>
        /// 根据主键更新数据
        /// <param name="id"></param>
        /// </summary>
        public T UpdateOne<T>(string id, UpdateDefinition<T> update) where T : EntityBase, new()
        {
            var collection = _db.GetCollection<T>(typeof(T).Name);
            collection.UpdateOne(o => o.Id == id, update);
            return T;
        }
        #endregion
    }
}
