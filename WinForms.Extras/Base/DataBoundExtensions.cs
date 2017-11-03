using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace System.Windows.Forms
{
    public static class DataBoundExtensions
    {

        /// <summary>
        /// 创建数据绑定新实例。
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="dataSource"></param>
        /// <param name="propertyExpression"></param>
        /// <returns></returns>
        public static DataBoundItem CreateDataBoundItem<TSource, TProperty>(this TSource dataSource, Expression<Func<TSource, TProperty>> propertyExpression)
        {
            var member = propertyExpression.Body as MemberExpression;
            if (member.Member.MemberType != MemberTypes.Property)
            {
                throw new InvalidOperationException($"{member.Member.Name} is not a property.");
            }
            return new DataBoundItem(dataSource, member.Member.Name);
        }
    }
}
