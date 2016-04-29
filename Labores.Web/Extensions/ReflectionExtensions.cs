using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;

namespace Labores.Web.Extensions
{
    public class ReflectionExtensions
    {
        public static string GetPropertyName<TModel, TValue>(Expression<Func<TModel, TValue>> expression)
        {
            var body = expression.Body as MemberExpression;
            if (body == null)
            {
                throw new ArgumentException("The expression is not a property", expression.ToString());
            }

            var innerExpresion = body.Expression as MemberExpression;
            if (innerExpresion != null)
            {
                return GetAccessString(innerExpresion) + "." + body.Member.Name;
            }
            else
            {
                return body.Member.Name;
            }
        }

        private static string GetAccessString(MemberExpression mExpresion)
        {
            var innerExpression = mExpresion.Expression as MemberExpression;
            if (innerExpression != null)
            {
                return GetAccessString(innerExpression) + "." + mExpresion.Member.Name;
            }
            else
            {
                return mExpresion.Member.Name;
            }
        }

        public static PropertyInfo GetPropertyInfo(Type modelType, string propertyName)
        {
            PropertyInfo resutProperty = null;
            var accessPropertyString = propertyName.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
            Type currentType = modelType;
            for (int i = 0; i < accessPropertyString.Length; i++)
            {
                resutProperty = currentType.GetProperty(accessPropertyString[i]);
                currentType = resutProperty.PropertyType;
            }
            return resutProperty;
        }
    }
}