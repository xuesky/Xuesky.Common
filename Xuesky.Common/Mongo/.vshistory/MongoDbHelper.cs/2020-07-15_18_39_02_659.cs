using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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
        /// </summary>
        /// <param name="data"></param>
        public T InsertOne<T>(T data) where T : EntityBase, new()
        {
            var collection = _db.GetCollection<T>(typeof(T).Name);
            collection.InsertOne(data);
            return data;
        }
        ///<summary>
        /// 插入多条数据，数据用list表示
        /// </summary>
        /// <param name="list"></param>
        public List<T> InsertMany<T>(List<T> list) where T : EntityBase, new()
        {
            var collection = _db.GetCollection<T>(typeof(T).Name);
            collection.InsertMany(list);
            return list;
        }
        #endregion
        //#region REPLACE
        /////<summary>
        ///// 根据主键更新数据
        ///// </summary>
        ///// <param name="id"></param>
        ///// <param name="data"></param>
        //public T ReplaceOne<T>(string id, T data) where T : EntityBase, new()
        //{
        //    data.Id = "0";
        //    var collection = _db.GetCollection<T>(typeof(T).Name);
        //    var properties = typeof(T).GetProperties().ToList();
        //    properties.ForEach(p =>
        //    {
        //        p.Name;
        //        p.GetValue(data);
        //    });
        //    collection.ReplaceOne(o => o.Id == id, data, ReplaceOptions.);
        //    return data;
        //}
        //#endregion
        #region UPDATE
        ///<summary>
        /// 根据主键更新数据
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public bool UpdateOne<T>(string id, Expression<Action<T>> entity) where T : EntityBase, new()
        {
            var collection = _db.GetCollection<T>(typeof(T).Name);
            var fieldList = new List<UpdateDefinition<T>>();
            var properties = typeof(T).GetProperties().ToList();
            properties.ForEach(p =>
            {
                fieldList.Add(Builders<T>.Update.Set(p.Name, p.GetValue(entity)));
            });
            var result = collection.UpdateOne(o => o.Id == id, Builders<T>.Update.Combine(fieldList));
            return result.ModifiedCount > 0;
        }
        ///<summary>
        /// 根据条件更新数据
        /// <param name="filter"></param>
        /// </summary>
        public bool UpdateOne<T>(FilterDefinition<T> filter, UpdateDefinition<T> update) where T : EntityBase, new()
        {
            var collection = _db.GetCollection<T>(typeof(T).Name);
            var result = collection.UpdateOne(filter, update);
            return result.ModifiedCount > 0;
        }
        #endregion
    }
}
