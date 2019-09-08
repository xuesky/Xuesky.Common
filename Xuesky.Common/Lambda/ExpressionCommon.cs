using System;
using System.Linq.Expressions;
using Xuesky.Common.Models;

namespace Xuesky.Common.Lambda
{
    public class ExpressionCommon
    {
        /// <summary>
        /// GetResult
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static TResult presson<TSource, TResult>(Expression<Func<TSource, TResult>> expression) where TSource : class, new()
        {
            //Expression<Func<TSource, TResult>> la = n => new { fname = "李四", id = "60" };
            //var body = (MemberInitExpression)la.Body;
            //var list = new List<string>();
            //body.Bindings.ToList().Select(s => new { });
            //body.Bindings.ToList().ForEach(s =>
            //{
            //    string val = s.Member.Name + "=" + ((MemberAssignment)s).Expression;
            //    list.Add(val);
            //});
            return expression.Compile()(null);
            //return default;
        }
    }
    public class myStudent : Student
    {

    }
}
