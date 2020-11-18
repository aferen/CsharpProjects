using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using WpfProject.Models;

namespace WpfProject.Views
{
    /// <summary>
    /// Interaction logic for UserControlMenuItem.xaml
    /// </summary>
    public partial class UserControlMenuItem : UserControl
    {
        private MainWindow mainWindow;
        public UserControlMenuItem(MainCategory category, MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            ExpanderMenu1.Visibility = category.SubCategory1List.Count == 0 ? Visibility.Collapsed : Visibility.Visible;
            foreach (var item in category.SubCategory1List)
            {
                if (item.SubCategory2List.Count == 0)
                {
                    ListViewMenu1.Visibility = Visibility.Visible;
                }
                else
                {
                    ListViewMenu1.Visibility = Visibility.Collapsed;
                }
            }
            this.DataContext = category;
            ExpanderMenu1.IsExpanded = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            int cnt = 0;
            ExpanderMenu1.IsExpanded = false;
            if (ListViewMenu1.ItemContainerGenerator.Status == GeneratorStatus.ContainersGenerated)
            {
                foreach (var item in ListViewMenu1.Items)
                {
                    SubCategory1 mdl = (SubCategory1)ListViewMenu1.Items[cnt];
                    ListBoxItem container = ListViewMenu1.ItemContainerGenerator.ContainerFromItem(item) as ListBoxItem;
                    Expander expander = FindVisualChild<Expander>(container, "ExpanderMenu2");
                    if (expander != null)
                    {
                        expander.Visibility = mdl.SubCategory2List.Count == 0 ? Visibility.Collapsed : Visibility.Visible;
                    }
                    cnt++;
                }
            }
        }
       
        private void ExpanderMenu_PreviewMouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement fe = e.OriginalSource as FrameworkElement;
            MainCategory main = fe.DataContext as MainCategory;
            SubCategory1 sub1 = fe.DataContext as SubCategory1;
            SubCategory2 sub2 = fe.DataContext as SubCategory2;
            if (main != null)
            {
                mainWindow.ChangeContent(main);
            }
            else if (sub1 != null)
            {
                mainWindow.ChangeContent(sub1);
            }
            else if (sub2 != null)
            {
                mainWindow.ChangeContent(sub2);
            }
        }

        private void TextBlock_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Change(sender, e);
        }
        private void TextBlock_PreviewMouseLeftButtonUp_2(object sender, MouseButtonEventArgs e)
        {
            Change(sender, e);
        }
        private void TextBlock_PreviewMouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            Change(sender, e);
        }
        private void Change(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement fe = e.OriginalSource as FrameworkElement;
            MainCategory main = fe.DataContext as MainCategory;
            SubCategory1 sub1 = fe.DataContext as SubCategory1;
            SubCategory2 sub2 = fe.DataContext as SubCategory2;
            if (main != null)
            {
                mainWindow.ChangeContent(main);
            }
            else if (sub1 != null)
            {
                mainWindow.ChangeContent(sub1);
            }
            else if (sub2 != null)
            {
                mainWindow.ChangeContent(sub2);
            }
        }

        private static T FindVisualChild<T>(DependencyObject parent, string childName) where T : DependencyObject
        {
            if (parent == null)
                return null;

            T foundChild = null;

            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                T childType = child as T;
                if (childType == null)
                {
                    foundChild = FindVisualChild<T>(child, childName);

                    if (foundChild != null)
                        break;
                }
                else if (!string.IsNullOrEmpty(childName))
                {
                    FrameworkElement frameworkElement = child as FrameworkElement;
                    if (frameworkElement != null && frameworkElement.Name == childName)
                    {
                        foundChild = (T)child;
                        break;
                    }
                }
                else
                {
                    foundChild = (T)child;
                    break;
                }
            }

            return foundChild;
        }

    }
}