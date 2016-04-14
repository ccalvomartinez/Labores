using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Labores.Web.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class InstructionsAttribute : Attribute
    {
        public string Instructions { get; private set; }
        public InstructionsAttribute(string instructions)
        {
            this.Instructions = instructions;
        }
    }
}