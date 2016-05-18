using System;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;

namespace XDotNet.Extensions
{
    static class UIElementExtensions
    {
        /// <summary>
        /// Láthatóság egyszerűbb beállítása
        /// </summary>
        /// <param name="element">UI elem, aminek a láthatóságát szabályozni akarjuk</param>
        /// <param name="visible">látható vagy nem</param>
        public static void SetVisible(this UIElement element, bool visible)
        {
            element.Visibility = visible ? Visibility.Visible : Visibility.Collapsed;
        }

        public static bool IsVisible(this UIElement element)
        {
            return element.Visibility == Visibility.Visible;
        }

        public async static Task ShowErrorAsync(this UIElement page, string error)
        {
            var dialog = new MessageDialog(error, "Error");
            dialog.Commands.Add(new UICommand("Ok"));
            await dialog.ShowAsync();
        }

        public async static Task ShowErrorAsync(this UIElement page, Exception ex)
        {
            //Log.Write(ex);
            await ShowErrorAsync(page, ex.Message);
        }
    }
}
