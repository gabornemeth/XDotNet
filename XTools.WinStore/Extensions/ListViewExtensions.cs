using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Controls;

namespace XDotNet.Extensions
{
    static class ListViewExtensions
    {
        public static bool IsItemSelected(this ListView listView)
        {
            return listView.SelectedItem != null;
        }

        /// <summary>
        /// Gets the index of first visible item in a ListView
        /// </summary>
        /// <param name="listView"></param>
        /// <returns></returns>
        public static int GetFirstVisibleItemIndex(this ListView listView)
        {
            var isp = (ItemsStackPanel)listView.ItemsPanelRoot;
            return isp.LastVisibleIndex;
        }

        public static void SetAsFirstVisibleItem(this ListView listView, int index)
        {
            if (index >= 0 && listView.Items.Count > index)
                listView.ScrollIntoView(listView.Items[index]);
        }
    }
}
