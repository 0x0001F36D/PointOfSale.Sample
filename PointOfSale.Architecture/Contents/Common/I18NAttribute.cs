using System;
using System.Reflection;

namespace PointOfSale.Contents.Common
{
    [AttributeUsage(AttributeTargets.All)]
    internal sealed class I18NAttribute : Attribute
    {
        public I18NAttribute(string summary)
            => this.Summary = summary;
        
        public string Summary { get; private set; }
        
    }           
    
    public static class I18N
    {
        public static string GetSummary(this object target)
            => target.GetType().GetCustomAttribute<I18NAttribute>()?.Summary ?? string.Empty;
    }
}
