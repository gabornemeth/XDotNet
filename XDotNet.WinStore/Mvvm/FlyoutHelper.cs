using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

namespace XDotNet.Mvvm
{
    static class FlyoutHelper
    {
        #region DataContext dependency property

        public static readonly DependencyProperty DataContextProperty = DependencyProperty.RegisterAttached("DataContext", typeof(object), typeof(FlyoutHelper),
            new PropertyMetadata(null, OnDataContextChanged));

        public static void SetDataContext(DependencyObject d, object value)
        {
            d.SetValue(DataContextProperty, value);
        }

        public static object GetDataContext(DependencyObject d)
        {
            return d.GetValue(DataContextProperty);
        }

        private static void OnDataContextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var flyoutBase = d as FlyoutBase; //null check
            if (flyoutBase != null)
            {
                var flyout = flyoutBase as Flyout;
                if (flyout != null)
                {
                    var content = flyout.Content as FrameworkElement;
                    if (content != null)
                        content.DataContext = e.NewValue;
                }
                var menuFlyout = flyoutBase as MenuFlyout;
                if (menuFlyout != null)
                {
                    foreach (var menuItem in menuFlyout.Items)
                        menuItem.DataContext = e.NewValue;
                }
            }
        }

        #endregion

        public static readonly DependencyProperty IsOpenProperty =
            DependencyProperty.RegisterAttached("IsOpen", typeof(bool),
            typeof(FlyoutHelper), new PropertyMetadata(false, OnIsOpenPropertyChanged));

        public static readonly DependencyProperty ParentProperty =
            DependencyProperty.RegisterAttached("Parent", typeof(FrameworkElement),
            typeof(FlyoutHelper), new PropertyMetadata(null, OnParentPropertyChanged));

        public static void SetIsOpen(DependencyObject d, bool value)
        {
            d.SetValue(IsOpenProperty, value);
        }

        public static bool GetIsOpen(DependencyObject d)
        {
            return (bool)d.GetValue(IsOpenProperty);
        }

        public static void SetParent(DependencyObject d, FrameworkElement value)
        {
            d.SetValue(ParentProperty, value);
        }

        public static FrameworkElement GetParent(DependencyObject d)
        {
            return d.GetValue(ParentProperty) as FrameworkElement;
        }

        private static void OnParentPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var flyout = d as FlyoutBase;
            if (flyout != null)
            {
                flyout.Opening += (s, args) =>
                {
                    flyout.SetValue(IsOpenProperty, true);
                };

                flyout.Closed += (s, args) =>
                {
                    flyout.SetValue(IsOpenProperty, false);
                };
            }
        }

        private static void OnIsOpenPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var flyout = d as FlyoutBase;
            var parent = GetParent(d);

            var newValue = (bool)e.NewValue;

            if (newValue)
            {
                if (flyout != null && parent != null)
                    flyout.ShowAt(parent);
            }
            else if (flyout != null)
                flyout.Hide();
        }
    }
}
