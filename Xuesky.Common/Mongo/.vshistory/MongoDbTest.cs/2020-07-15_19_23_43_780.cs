using MongoDB.Driver;
using System;

namespace Xuesky.Common.MongoDB
{
    public class MongoDbTest
    {
        /// <summary>
        /// ctor
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="MemberAccessException"></exception>
        /// <exception cref="System.Reflection.TargetInvocationException"></exception>
        /// <exception cref="TypeLoadException"></exception>
        public MongoDbTest()
        {
            MongoDbHelper mongoDb = new MongoDbHelper("127.0.0.1", "mydb", 10);
            var random = new Random(10);
            var randomNum = random.Next(0, 1000);
            var book = new Book()
            {
                BookName = "学习大全" + randomNum,
                Price = 123,
                Author = "xuesky1111" + randomNum,
                Category = "学习1111" + randomNum
            };
            var result = mongoDb.InsertOne<Book>(book);
            //更新
            //方式1
            var update = Builders<Book>.Update;
            mongoDb.Update("5f0ec96fd3d944988cd0457b", update.Set("Name", "我是被修改过的名字"));
            //方式2
            mongoDb.Update<Book>("5f0ed67acf77945b94e89277", b => new Book { BookName = "我是被表达式修改过的" });
            //方式3
            mongoDb.Update<Book>(id => id.Id == "5f0ed67acf77945b94e89277", b => new Book { BookName = "我是被表达式修改过的2" });
            //替换
            //mongoDb.ReplaceOne("5f0ed09b3d688d5644568feb", book);

            Console.WriteLine(result);
        }
    }
}
