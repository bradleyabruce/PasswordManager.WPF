using PasswordManager.WPF.DataAccess;
using PasswordManager.WPF.DataObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PasswordManager.WPF.UserControls
{
   /// <summary>
   /// Interaction logic for PasswordDataGrid.xaml
   /// </summary>
   public partial class PasswordDataGrid : UserControl
   {
      #region Variables 

      DataGetLogo dgl = new DataGetLogo();

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

      private PasswordEntryObject _selectedPassword;
      public PasswordEntryObject SelectedPassword
      {
         get { return _selectedPassword; }
         set
         {
            _selectedPassword = value;
            Popup pop = new Popup();
         }
      }


      private List<PasswordEntryObject> _passwordsWithoutImages;
      public List<PasswordEntryObject> PasswordsWithoutImages
      {
         get { return _passwordsWithoutImages; }
         set
         {
            _passwordsWithoutImages = value;
            GenerateImages();
         }
      }

      private List<PasswordEntryObject> _passwordsWithImages;
      public List<PasswordEntryObject> PasswordsWithImages
      {
         get { return _passwordsWithImages; }
         set
         {
            _passwordsWithImages = value;

            //bind to datagrid
            CollectionViewSource itemCollectionViewSource;
            itemCollectionViewSource = (CollectionViewSource)(FindResource("ItemCollectionViewSource"));
            itemCollectionViewSource.Source = _passwordsWithoutImages;
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
               //Grid.Visibility = Visibility.Collapsed;
               dropdownImage.Icon = FontAwesome.WPF.FontAwesomeIcon.SortAsc;
            }
            else
            {
               //Grid.Visibility = Visibility.Visible;
               dropdownImage.Icon = FontAwesome.WPF.FontAwesomeIcon.SortDesc;
            }
         }
      }

      #endregion Variables

      #region Constructor

      public PasswordDataGrid(string category, List<PasswordEntryObject> passwords)
      {
         InitializeComponent();
         CategoryName = category;
         PasswordsWithoutImages = passwords;
         this.Height = 45 + (PasswordsWithoutImages.Count * 52);
         GenerateImages();
      }

      #endregion Constructor

      #region Methods


      public async void GenerateImages()
      {
         List<PasswordEntryObject> newPasswords = new List<PasswordEntryObject>();

         foreach(PasswordEntryObject password in PasswordsWithoutImages)
         {
            Task<BitmapImage> asyncImage = dgl.GetImage(password.WebsiteDomain, 50);
            BitmapImage image = await asyncImage;
            if (image != null)
            {
               password.Image = image;
               newPasswords.Add(password);
               /*
               string path = "..\\..\\Images\\unlock.png";
               Bitmap bitmap = new Bitmap(path);
               Bitmap transparent = DataGetLogo.ModifyTransparency(bitmap);
               BitmapImage bitmapImage = DataGetLogo.BitmapToImageSource(transparent);
               password.Image = bitmapImage;
               newPasswords.Add(password);
               */
            }
            else
            {
               string path = "..\\..\\Images\\unlock.png";
               Bitmap bitmap = new Bitmap(path);
               Bitmap transparent = DataGetLogo.ModifyTransparency(bitmap);
               BitmapImage bitmapImage = DataGetLogo.BitmapToImageSource(transparent);
               password.Image = bitmapImage;
               newPasswords.Add(password);
            }
         }

         PasswordsWithImages = newPasswords;
         
      }

      #endregion Methods

      #region Events

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

      #endregion Events

      private void PasswordGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
      {
         DataGrid dg = sender as DataGrid;
         PasswordEntryObject password = dg.SelectedValue as PasswordEntryObject;

         //create viewer from password
      }
   }
}
