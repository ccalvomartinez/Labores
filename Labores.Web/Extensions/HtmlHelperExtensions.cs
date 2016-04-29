using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Labores.Web.Attributes;
using System.Text;
using Forloop.HtmlHelpers;
using System.Web.UI.WebControls.Expressions;
namespace Labores.Web.Extensions
{
    public static class HtmlHelperExtensions
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
        private static string GetAccessString(MemberExpression mExpresion) {
            var innerExpression = mExpresion.Expression as MemberExpression;
            if (innerExpression != null)
            {
                return GetAccessString(innerExpression) + "." + mExpresion.Member.Name;
            }
            else {
                return mExpresion.Member.Name;
            }
        }
        public static MvcHtmlString InstructionsForOBS<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            return InstructionsForOBS(html, GetPropertyName(expression));
        }
        public static MvcHtmlString InstructionsForOBS<TModel>(this HtmlHelper<TModel> html, string propertyName)
        {
            if (html == null)
            {
                throw new ArgumentNullException("HtmlHelper");
            }

            if (string.IsNullOrEmpty(propertyName))
            {
                throw new ArgumentNullException("Property");
            }

            PropertyInfo property = GetPropertyInfo(html.ViewData.ModelMetadata.ModelType, propertyName);
            if (property == null)
            {
                throw new ArgumentException("Property does not exist on Model", propertyName);
            }

            InstructionsAttribute instructionAtt = property.GetCustomAttribute<InstructionsAttribute>();
            if (instructionAtt == null)
            {
                throw new ArgumentException("Instructions attribute does not exist on Model", propertyName);
            }

            return new MvcHtmlString(RenderInstrucionHtml(propertyName, html, instructionAtt.Instructions));
        }

        public static PropertyInfo GetPropertyInfo(Type modelType,string propertyName) {
            PropertyInfo resutProperty=null;
            var accessPropertyString=propertyName.Split(new string[] {"."},StringSplitOptions.RemoveEmptyEntries);
            Type currentType = modelType;
            for (int i = 0; i < accessPropertyString.Length; i++) {
                resutProperty = currentType.GetProperty(accessPropertyString[i]);
                currentType = resutProperty.PropertyType;
            }
            return resutProperty;
        }

        public static string RenderInstrucionHtml<TModel>(string Property, HtmlHelper<TModel> html, string instructions)
        {
            var guid = Guid.NewGuid().ToString("N");
            
            StringBuilder resultConstructor = new StringBuilder();
            var divInstructions = new TagBuilder("div");
            divInstructions.AddCssClass("instructions");
            divInstructions.GenerateId(string.Format("instructions_{0}_{1}", Property, guid));
            var idInstructions = divInstructions.Attributes["id"];
            divInstructions.SetInnerText(instructions);
            resultConstructor.AppendLine(divInstructions.ToString());

            var divClickable = new TagBuilder("a");
            divClickable.GenerateId(string.Format("instructions_{0}_{1}_Click", Property, guid));
            var idClickable = divClickable.Attributes["id"];
            divClickable.MergeAttribute("href", "");
            divClickable.InnerHtml = "Instructions";
            resultConstructor.AppendLine(divClickable.ToString());

            using (html.BeginScriptContext())
            {
                StringBuilder scriptConstructor = new StringBuilder();
                scriptConstructor.AppendLine();
                scriptConstructor.AppendLine("$(document).ready(function(){ ");

                scriptConstructor.AppendLine();
                scriptConstructor.AppendFormat("$( '#{0}' ).dialog({{autoOpen:false}});", idInstructions);
                scriptConstructor.AppendLine();
                scriptConstructor.AppendFormat("$( '#{1}' ).click(function(ev) {{{2}ev.preventDefault();{2}$( '#{0}' ).dialog( 'open' );{2} }});", idInstructions, idClickable, Environment.NewLine);

                scriptConstructor.AppendLine();
                scriptConstructor.AppendLine("});");

                html.AddScriptBlock(scriptConstructor.ToString());
            }

            return resultConstructor.ToString();
        }
    }
}