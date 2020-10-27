using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace Xuesky.Common.Mongo
{
    /// <summary>
    /// Mongo db的数据库帮助类
    /// </summary>
    public class MongoDbHelper
    {
        string keyName = "Id";
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
        public List<T> InsertBatch<T>(List<T> list) where T : EntityBase, new()
        {
            var collection = _db.GetCollection<T>(typeof(T).Name);
            collection.InsertMany(list);
            return list;
        }
        #endregion
        #region UPDATE
        ///<summary>
        /// 根据主键按需更新数据
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="MemberAccessException"></exception>
        /// <exception cref="System.Reflection.TargetInvocationException"></exception>
        /// <exception cref="TypeLoadException"></exception>
        public bool UpdateOne<T>(string id, Expression<Action<T>> entity) where T : EntityBase, new()
        {
            IMongoCollection<T> collection = _db.GetCollection<T>(typeof(T).Name);
            List<UpdateDefinition<T>> fieldList = GetUpdateDefinition(entity);
            var result = collection.UpdateOne(o => o.Id == id, Builders<T>.Update.Combine(fieldList));
            return result.ModifiedCount > 0;
        }
        ///<summary>
        /// 根据条件按需更新数据
        /// </summary>
        /// <param name="filter">过滤条件</param>
        /// <param name="entity">按需更新实体字段对象</param>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="MemberAccessException"></exception>
        /// <exception cref="System.Reflection.TargetInvocationException"></exception>
        public bool UpdateMany<T>(Expression<Func<T, bool>> filter, Expression<Action<T>> entity) where T : EntityBase, new()
        {
            IMongoCollection<T> collection = _db.GetCollection<T>(typeof(T).Name);
            List<UpdateDefinition<T>> fieldList = GetUpdateDefinition(entity);
            var result = collection.UpdateMany(filter, Builders<T>.Update.Combine(fieldList));
            return result.ModifiedCount > 0;
        }
        /// <summary>
        /// 获取更新对象属性
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        private List<UpdateDefinition<T>> GetUpdateDefinition<T>(Expression<Action<T>> entity) where T : EntityBase, new()
        {
            var fieldList = new List<UpdateDefinition<T>>();
            var param = entity.Body as MemberInitExpression;
            foreach (var item in param.Bindings)
            {
                string propertyName = item.Member.Name;
                var attributes = item.Member.GetCustomAttributes();//获取自定义Attribute
                foreach (var attr in attributes)
                {
                    if (attr is BsonIdAttribute)
                    {
                        keyName = propertyName;
                    }
                }
                object propertyValue;
                var memberAssignment = item as MemberAssignment;
                if (memberAssignment.Expression.NodeType == ExpressionType.Constant)
                {
                    propertyValue = (memberAssignment.Expression as ConstantExpression).Value;
                }
                else
                {
                    propertyValue = Expression.Lambda(memberAssignment.Expression, null).Compile().DynamicInvoke();
                }
                if (propertyName != "Id")//更新集中不能有实体键_id
                {
                    fieldList.Add(Builders<T>.Update.Set(propertyName, propertyValue));
                }
            }
            return fieldList;
        }

        ///<summary>
        /// 根据Id更新数据
        /// </summary>
        /// <param name="Id">Id</param>
        /// <param name="update">更新对象</param>
        public bool UpdateOne<T>(string Id, UpdateDefinition<T> update) where T : EntityBase, new()
        {
            var collection = _db.GetCollection<T>(typeof(T).Name);
            var result = collection.UpdateOne(o => o.Id == Id, update);
            return result.ModifiedCount > 0;
        }
        ///<summary>
        /// 根据条件更新数据
        /// </summary>
        /// <param name="filter">过滤条件</param>
        /// <param name="update">更新对象</param>
        public bool UpdateMany<T>(FilterDefinition<T> filter, UpdateDefinition<T> update) where T : EntityBase, new()
        {
            var collection = _db.GetCollection<T>(typeof(T).Name);
            var result = collection.UpdateMany(filter, update);
            return result.ModifiedCount > 0;
        }
        #endregion
        #region SELECT
        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<T> GetAll<T>() where T : EntityBase, new()
        {
            var collection = _db.GetCollection<T>(typeof(T).Name);
            return collection.Find(new BsonDocument()).ToList();
        }
        /// <summary>
        /// 根据查询条件，获取实体数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetOne<T>(Expression<Func<T, bool>> conditions) where T : EntityBase, new()
        {
            var collection = _db.GetCollection<T>(typeof(T).Name);
            return collection.Find(conditions).FirstOrDefault();
        }
        /// <summary>
        /// 根据查询条件，获取实体数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public long GetCount<T>(Expression<Func<T, bool>> conditions) where T : EntityBase, new()
        {
            if (this._db == null)
            {
                return 0;
            }
            try
            {
                var collection = _db.GetCollection<T>(typeof(T).Name);
                return collection.CountDocuments(conditions);
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="conditions">查询条件</param>
        /// <param name="pageIndex">当前索引页</param>
        /// <param name="pageSize">每页显示数量</param>
        /// <returns></returns>
        public (List<T> list, int pageCount) GetListByPage<T>(Expression<Func<T, bool>> conditions = null,
            int pageIndex = 0, int pageSize = 25, Expression<Func<T, object>> sortBy = null) where T : EntityBase, new()
        {
            if (this._db == null)
            {
                return (null, 0);
            }
            var collection = _db.GetCollection<T>(typeof(T).Name);
            pageIndex = pageIndex < 0 ? 0 : pageIndex;
            pageSize = pageSize <= 0 ? 25 : pageSize;
            if (conditions == null)
            {
                conditions = _ => true;
            }
            if (sortBy == null)
            {
                sortBy = s => s.Id;
            }
            var list = collection.Find(conditions).SortByDescending(sortBy).Skip(pageIndex * pageSize).Limit(pageSize).ToList();
            decimal recordCount = collection.Find(conditions).CountDocuments();
            int pageCount = (int)Math.Ceiling(recordCount / pageSize);
            return (list, pageCount);
        }
        /// <summary>
        /// 根据查询条件，获取数据列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public List<T> GetList<T>(Expression<Func<T, bool>> conditions = null) where T : EntityBase, new()
        {
            var collection = _db.GetCollection<T>(typeof(T).Name);
            if (conditions != null)
            {
                return collection.Find(conditions).ToList();
            }
            return collection.Find(_ => true).ToList();
        }
        #endregion
        #region DELETE
        ///<summary>
        /// 删除单条数据
        /// </summary>
        /// <param name="id">id</param>
        public bool DeleteOne<T>(string id) where T : EntityBase, new()
        {
            var collection = _db.GetCollection<T>(typeof(T).Name);
            var result = collection.DeleteOne(o => o.Id == id);
            return result.DeletedCount > 0;
        }
        ///<summary>
        /// 删除多条数据
        /// </summary>
        /// <param name="filter">过滤条件</param>
        public long DeleteBatch<T>(Expression<Func<T, bool>> filter) where T : EntityBase, new()
        {
            var collection = _db.GetCollection<T>(typeof(T).Name);
            var result = collection.DeleteMany(filter);
            return result.DeletedCount;
        }
        #endregion
        #region REPLACE
        ///<summary>
        /// 根据主键替换数据
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="MemberAccessException"></exception>
        /// <exception cref="System.Reflection.TargetInvocationException"></exception>
        /// <exception cref="TypeLoadException"></exception>
        public bool ReplaceOne<T>(string id, T entity) where T : EntityBase, new()
        {
            IMongoCollection<T> collection = _db.GetCollection<T>(typeof(T).Name);

            var result = collection.ReplaceOne(o => o.Id == id, entity);
            return result.ModifiedCount > 0;
        }
        #endregion
        #region INDEX
        /// <summary>
        /// 根据Key创建索引
        /// </summary>
        /// <typeparam name="T">需要创建索引的实体类型</typeparam>
        /// <exception cref="Exception"></exception>
        public bool CreateIndex<T>() where T : EntityBase, new()
        {
            if (this._db == null)
            {
                return false;
            }
            try
            {
                string collectionName = typeof(T).Name;
                IMongoCollection<BsonDocument> mc = this._db.GetCollection<BsonDocument>(collectionName);

                PropertyInfo[] propertys = typeof(T).GetProperties(BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty);
                //得到该实体类型的属性

                foreach (PropertyInfo property in propertys)
                {
                    //在各个属性中得到其特性
                    foreach (object obj in property.GetCustomAttributes(true))
                    {
                        MongoDbFieldAttribute mongoField = obj as MongoDbFieldAttribute;
                        if (mongoField != null)
                        {
                            IndexKeysDefinition<BsonDocument> indexKey;
                            if (mongoField.Ascending)
                            {
                                //升序 索引
                                indexKey = Builders<BsonDocument>.IndexKeys.Ascending(property.Name);
                            }
                            else
                            {
                                //降序索引
                                indexKey = Builders<BsonDocument>.IndexKeys.Descending(property.Name);
                            }
                            CreateIndexModel<BsonDocument> indexModel = new CreateIndexModel<BsonDocument>(indexKey);
                            //创建该索引
                            mc.Indexes.CreateOne(indexModel);
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
