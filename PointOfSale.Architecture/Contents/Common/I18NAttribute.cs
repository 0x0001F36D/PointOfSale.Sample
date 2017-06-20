using System;
using System.Linq;
using System.Reflection;

namespace PointOfSale.Contents.Common
{
    [AttributeUsage(AttributeTargets.All)]
    public sealed class I18NAttribute : Attribute
    {
        public I18NAttribute(string summary)
            => this.Summary = summary;
        
        public string Summary { get; private set; }
        
    }           
    
}
