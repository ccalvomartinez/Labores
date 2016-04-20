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
namespace Labores.Web.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString InstructionsFor<TModel>(this HtmlHelper<TModel> html, string propertyName)
        {
            if (html == null) {
                throw new ArgumentNullException("HtmlHelper");
            }
            
            if (string.IsNullOrEmpty(propertyName)) {
                throw new ArgumentNullException("Property");
            }
          
            PropertyInfo property = html.ViewData.ModelMetadata.ModelType.GetProperty(propertyName);
            if (property == null) {
                throw new ArgumentException("Property does not exist on Model", propertyName);
            }

            InstructionsAttribute instructionAtt = property.GetCustomAttribute<InstructionsAttribute>();
            if (instructionAtt == null)
            {
                throw new ArgumentException("Instructions attribute does not exist on Model", propertyName);
            }

            return new MvcHtmlString(RenderInstrucionHtml(propertyName, html,instructionAtt.Instructions));
        }

        private static string RenderInstrucionHtml<TModel>(string Property, HtmlHelper<TModel> html,string instructions)
        {
            var guid = Guid.NewGuid().ToString("N");

            StringBuilder resultConstructor = new StringBuilder();
            var divInstructions = new TagBuilder("div");
            divInstructions.AddCssClass("instructions");
            divInstructions.GenerateId( string.Format("instructions_{0}_{1}", Property, guid));
            var  idInstructions = divInstructions.Attributes["id"];
            divInstructions.SetInnerText(instructions);
            resultConstructor.AppendLine(divInstructions.ToString());

            var divClickable = new TagBuilder("a");
            divClickable.GenerateId(string.Format("instructions_{0}_{1}_Click", Property, guid));
            var idClickable = divClickable.Attributes["id"];
            divClickable.MergeAttribute("href", "");
            divClickable.InnerHtml = "Instructions";
            resultConstructor.AppendLine(divClickable.ToString());

            using (html.BeginScriptContext()) {
                StringBuilder scriptConstructor = new StringBuilder();
                scriptConstructor.AppendLine();
                scriptConstructor.AppendLine("$(document).ready(function(){ ");
        
                scriptConstructor.AppendLine();
                scriptConstructor.AppendFormat("$( '#{0}' ).dialog({{autoOpen:false}});", idInstructions);
                scriptConstructor.AppendLine();
                scriptConstructor.AppendFormat("$( '#{1}' ).click(function(ev) {{{2}ev.preventDefault();{2}$( '#{0}' ).dialog( 'open' );{2} }});", idInstructions, idClickable,Environment.NewLine);

                scriptConstructor.AppendLine();
                scriptConstructor.AppendLine("});");

                html.AddScriptBlock(scriptConstructor.ToString());
            }
         
            return resultConstructor.ToString();
        }
    }
}