using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Labores.Web.Attributes;
using System.Text;

namespace Labores.Web.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString InstructionsFor<TModel>(this HtmlHelper<TModel> html, string Property) 
        {
            PropertyInfo property = html.ViewData.ModelMetadata.ModelType.GetProperty(Property);
            InstructionsAttribute instructionAttData = property.GetCustomAttribute<InstructionsAttribute>();

          
            return new MvcHtmlString(RenderInstrucionHtml(Property));
        }

        private static string RenderInstrucionHtml(string Property)
        {
            StringBuilder resultConstructor = new StringBuilder();
            var divInstructions = new TagBuilder("div");
            divInstructions.AddCssClass("instructions");
            //      div.MergeAttribute("style", "display:none", true);
            divInstructions.GenerateId("instructions" + Property);
            var idInstructions = divInstructions.Attributes["id"];
            resultConstructor.AppendLine(divInstructions.ToString());

            var divClickable = new TagBuilder("a");
            divClickable.GenerateId("instructions" + Property + "Click");
            var idClickable = divClickable.Attributes["id"];
            divClickable.MergeAttribute("href", "");
            divClickable.InnerHtml = "Instructions";
            resultConstructor.AppendLine(divClickable.ToString());

            var script = new TagBuilder("script");
            StringBuilder scriptBuilder = new StringBuilder();

            scriptBuilder.AppendLine(string.Format("\\$( '\\#{0}' ).dialog({autoOpen:false});",idInstructions));
            scriptBuilder.AppendLine(string.Format("$( '#{1}' ).click(function() {$( '#{0}' ).dialog( 'open' ); });", idInstructions, idClickable));

            script.InnerHtml = scriptBuilder.ToString();
            resultConstructor.AppendLine(script.ToString());

            return resultConstructor.ToString();
        }
    }
}