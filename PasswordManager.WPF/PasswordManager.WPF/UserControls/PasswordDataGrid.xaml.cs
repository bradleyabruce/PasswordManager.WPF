using PasswordManager.WPF.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PasswordManager.WPF.UserControls
{
   /// <summary>
   /// Interaction logic for PasswordDataGrid.xaml
   /// </summary>
   public partial class PasswordDataGrid : UserControl
   {
      #region Variables 

      private string _categoryName;
      public string CategoryName
      {
         get { return _categoryName; }
         set
         {
            _categoryName = value;
            LabelCategory.Content = _categoryName;
         }
      }

      private List<PasswordEntryObject> _passwords;
      public List<PasswordEntryObject> Passwords
      {
         get { return _passwords; }
         set
         {
            _passwords = value;
            GenerateRows();
         }
      }

      private bool _gridCollapsed;
      public bool GridCollapsed
      {
         get { return _gridCollapsed; }
         set
         {
            _gridCollapsed = value;
            if (_gridCollapsed)
            {
               Grid.Visibility = Visibility.Collapsed;
               dropdownImage.Icon = FontAwesome.WPF.FontAwesomeIcon.SortAsc;
            }
            else
            {
               Grid.Visibility = Visibility.Visible;
               dropdownImage.Icon = FontAwesome.WPF.FontAwesomeIcon.SortDesc;
            }
         }
      }

      #endregion Variables



      public PasswordDataGrid(string category, List<PasswordEntryObject> passwords)
      {
         InitializeComponent();
         CategoryName = category;
         Passwords = passwords;
         GenerateHeight();
      }

      public void GenerateRows()
      {
         Grid.ItemsSource = Passwords;
      }

      public void GenerateHeight()
      {
         this.Height = 45 + (Grid.Items.Count * Grid.RowHeight);
      }

      private void Grid_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
      {
         DataGrid grid = sender as DataGrid;
         DependencyObject parentGrid = VisualTreeHelper.GetParent(grid);
         DependencyObject parentContentPresenter = VisualTreeHelper.GetParent(parentGrid);
         DependencyObject parentBorder = VisualTreeHelper.GetParent(parentContentPresenter);
         DependencyObject parentPasswordDataGrid = VisualTreeHelper.GetParent(parentBorder);
         DependencyObject parentInnerGrid= VisualTreeHelper.GetParent(parentPasswordDataGrid);
         DependencyObject parentScrollContentPresenter = VisualTreeHelper.GetParent(parentInnerGrid);
         DependencyObject parentOuterGrid = VisualTreeHelper.GetParent(parentScrollContentPresenter);
         DependencyObject parentScrollView = VisualTreeHelper.GetParent(parentOuterGrid);


         ScrollViewer scrollView = parentScrollView as ScrollViewer;
         scrollView.ScrollToVerticalOffset(scrollView.VerticalOffset - e.Delta);
         e.Handled = true;
      }

      private void DropdownImage_MouseEnter(object sender, MouseEventArgs e)
      {
         this.Cursor = Cursors.Hand;
      }

      private void DropdownImage_MouseLeave(object sender, MouseEventArgs e)
      {
         this.Cursor = Cursors.Arrow;
      }

      private void DropdownImage_MouseDown(object sender, MouseButtonEventArgs e)
      {
         if (GridCollapsed)
         {
            GridCollapsed = false;
         }
         else
         {
            GridCollapsed = true;
         }
      }
   }
}
