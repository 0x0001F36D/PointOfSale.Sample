using PointOfSale.Contents.Common;
using System.Windows.Forms;

namespace PointOfSale.Gui
{
    public static class ButtonExtension
    {
        public static string GetInfo(this ButtonBase button)
            => button.Text.GetSummary();
    }
}
