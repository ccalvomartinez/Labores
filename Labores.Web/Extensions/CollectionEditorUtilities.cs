using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Labores.Web.Extensions
{
    public static class CollectionEditorUtilities
    {
        /// <summary>Generates the item property path for the given index to use for custom validation.</summary>
        /// <param name="collectionPropertyName">The name of the collection property in the master view model.</param>
        /// <param name="index">The item index.</param>
        /// <param name="propertyPath">The property path.</param>
        /// <returns>The item path.</returns>
        /// <exception cref="InvalidOperationException">Previous collection indices not available.</exception>
        public static string GetItemPropertyPath(string collectionPropertyName, int index, string propertyPath)
        {
            var previousIndicesValues = HttpContext.Current.Request[collectionPropertyName + ".Index"];
            if (!String.IsNullOrWhiteSpace(previousIndicesValues))
                return collectionPropertyName + "[" + previousIndicesValues.Split(',')[index] + "]." + propertyPath;

            throw new InvalidOperationException("Previous collection indices not available.");
        }
    }
}