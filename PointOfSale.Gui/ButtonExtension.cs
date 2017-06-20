using PointOfSale.Contents.Common;
using System;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace PointOfSale.Gui
{
    public static class ButtonExtension
    {
        public static TEnum Get<TEnum>(this ButtonBase button) where TEnum : struct, IComparable, IFormattable, IConvertible
            => Enum<TEnum>.TryParse(Enum<TEnum>.GetNames()
                                                .FirstOrDefault(x => typeof(TEnum).GetMember(x).FirstOrDefault().GetCustomAttribute<I18NAttribute>().Summary.Equals(button.Text)), out TEnum e) ? e : default(TEnum);
    }
}
