﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
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
using PasswordManager.WPF;
using PasswordManager.WPF.DataAccess;
using PasswordManager.WPF.DataObjects;
using PasswordManager.WPF.UserControls;

namespace PasswordManager.WPF
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class EntryView : Window
   {
      #region Variables

      DataPasswordRetrieval passwordRetrieval = new DataPasswordRetrieval();
      DataGetLogo dgl = new DataGetLogo();

      private bool _menuCollapsed;
      public bool MenuCollapsed
      {
         get
         {
            return _menuCollapsed;
         }
         set
         {
            _menuCollapsed = value;
            if (_menuCollapsed)
            {
               GridLength gl = new GridLength(110);
               ColumnDefinitionMenu.Width = gl;
               IconMenuOpen.Icon = FontAwesome.WPF.FontAwesomeIcon.ArrowRight;
            }
            else
            {
               GridLength gl = new GridLength(320);
               ColumnDefinitionMenu.Width = gl;
               IconMenuOpen.Icon = FontAwesome.WPF.FontAwesomeIcon.ArrowLeft;
            }
         }
      }

      private bool _userSettingsCollapsed;
      public bool UserSettingsCollapsed
      {
         get
         {
            return _userSettingsCollapsed;
         }
         set
         {
            _userSettingsCollapsed = value;
            if (_userSettingsCollapsed)
            {
               BorderUserSettings.Visibility = Visibility.Collapsed;
            }
            else
            {
               BorderUserSettings.Visibility = Visibility.Visible;
            }
         }
      }

      private string _gridSort;
      public string GridSort
      {
         get { return _gridSort; }
         set
         {
            _gridSort = value;
            //TODO do sort stuff
         }
      }

      private string _gridOrCardView;
      public string GridOrCardView
      {
         get { return _gridOrCardView; }
         set
         {
            _gridOrCardView = value;
            var converter = new BrushConverter();
            if (_gridOrCardView == "Grid")
            {
               GridView.Foreground = Brushes.White;
               BorderButtonGridView.Background = (Brush)converter.ConvertFrom("#0066ff");

               IconView.Foreground = Brushes.Gray;
               BorderButtonIconView.Background = (Brush)converter.ConvertFrom("#e6e6e6");

               //TODO add grid change
            }
            else if(_gridOrCardView == "Card")
            {
               IconView.Foreground = Brushes.White;
               BorderButtonIconView.Background = (Brush)converter.ConvertFrom("#0066ff");

               GridView.Foreground = Brushes.Gray;
               BorderButtonGridView.Background = (Brush)converter.ConvertFrom("#e6e6e6");

               //TODO add grid change
            }
         }
      }

      private List<PasswordEntryObject> _passwordEntries;
      public List<PasswordEntryObject> PasswordEntries
      {
         get { return _passwordEntries; }
         set
         {
            _passwordEntries = value;
            ShowPasswordGrids();
         }
      }

      public string[] sortOptionsArray = { "Website A-Z", "Website Z-A", "Newest to Oldest", "Oldest to Neweset" };

      #endregion Variables

      #region Constructors

      public EntryView()
      {
         InitializeComponent();
         MenuCollapsed = true;
         UserSettingsCollapsed = true;
         GridOrCardView = "Grid";
      }

      private void Window_Loaded(object sender, RoutedEventArgs e)
      {
         try
         {
            //set data
            string userID = App.Current.Properties["UserID"].ToString();
            string email = App.Current.Properties["UserEmail"].ToString();
            ButtonUser.Content = ":)";
            UserSettingsEmailLabel.Content = email;
            UserSettingsUserNameLabel.Content = email;

            //get data
            SetsortOptions(sortOptionsArray);
            GridSort = ComboBoxSort.SelectedValue.ToString();
            getEntriesAsync(userID, "0");
         }
         catch
         {
            ErrorAndReturnToLogin("Application Error", "Could not load application data", "Error");
         }
      }

      #endregion Constructors

      #region Top Nav Events

      private void ButtonUserMenu_MouseEnter(object sender, MouseEventArgs e)
      {
         var converter = new BrushConverter();
         //textboxUserName.Background = (Brush)converter.ConvertFrom("#BEE6FD");
      }

      private void ButtonUserMenu_MouseLeave(object sender, MouseEventArgs e)
      {
         var converter = new BrushConverter();
         //textboxUserName.Background = Brushes.LightBlue;
      }

      private void ButtonUser_Click(object sender, RoutedEventArgs e)
      {
         if (UserSettingsCollapsed)
         {
            UserSettingsCollapsed = false;
         }
         else
         {
            UserSettingsCollapsed = true;
         }
      }

      private void UserSettingsSignOut_MouseDown(object sender, MouseButtonEventArgs e)
      {
         App.Current.Properties["UserID"] = null;
         App.Current.Properties["UserEmail"] = null;

         LoginWindow login = new LoginWindow();
         this.Close();
         login.ShowDialog();
         login.HorizontalAlignment = HorizontalAlignment.Center;
         login.VerticalAlignment = VerticalAlignment.Center;
      }

      #endregion End Top Nav Events

      #region Side Menu Events

      private void Menu_MouseEnter(object sender, MouseEventArgs e)
      {
         Grid grid = sender as Grid;
         if (grid != null)
         {
            var converter = new BrushConverter();
            grid.Background = (Brush)converter.ConvertFrom("#666666");
         }
         this.Cursor = Cursors.Hand;
      }

      private void Menu_MouseLeave(object sender, MouseEventArgs e)
      {
         Grid grid = sender as Grid;
         if (grid != null)
         {
            var converter = new BrushConverter();
            grid.Background = (Brush)converter.ConvertFrom("#808080");
         }
         this.Cursor = Cursors.Arrow;
      }

      private void Menu_MouseDown(object sender, MouseButtonEventArgs e)
      {
         Grid grid = sender as Grid;
         string name = grid.Name;

         if (name == "MenuCollapse")
         {
            if (MenuCollapsed)
            {
               MenuCollapsed = false;
            }
            else
            {
               MenuCollapsed = true;
            }
         }
         else
         {
            //do nothing
         }
      }

      #endregion Side Menu Events

      #region General Events

      private void TextButton_MouseEnter(object sender, MouseEventArgs e)
      {
         TextBlock textBlock = sender as TextBlock;
         if (textBlock != null)
         {
            textBlock.TextDecorations = TextDecorations.Underline;
            this.Cursor = Cursors.Hand;
         }
      }

      private void TextButton_MouseLeave(object sender, MouseEventArgs e)
      {
         TextBlock textBlock = sender as TextBlock;
         if (textBlock != null)
         {
            textBlock.TextDecorations = null; ;
            this.Cursor = Cursors.Arrow;
         }
      }

      private void Button_MouseEnter(object sender, MouseEventArgs e)
      {
         this.Cursor = Cursors.Hand;
      }

      private void Button_MouseLeave(object sender, MouseEventArgs e)
      {
         this.Cursor = Cursors.Arrow;
      }

      #endregion General Events

      #region Password Pane Events 

      private void ResultIconView_MouseDown(object sender, MouseButtonEventArgs e)
      {
         GridOrCardView = "Card";
      }

      private void ResultGridView_MouseDown(object sender, MouseButtonEventArgs e)
      {
         GridOrCardView = "Grid";
      }

      private void ComboBoxSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
      {
         GridSort = ComboBoxSort.SelectedItem.ToString();
      }

      #endregion Password Pane Events

      #region Methods
      public async void getEntriesAsync(string UserID, string CategoryID)
      {
         Task<List<PasswordEntryObject>> passwordRetreivalAsync = passwordRetrieval.RetreivePasswords(UserID, CategoryID);
         //LoginLoading.Visibility = Visibility.Visible;
         //ButtonLogin.Content = "";

         PasswordEntries = await passwordRetreivalAsync;

         //LoginLoading.Visibility = Visibility.Collapsed;
      }

      public void SetsortOptions(string[] array)
      {
         ComboBoxSort.ItemsSource = array;

         ComboBoxSort.SelectedIndex = 0;
      }

      public void ErrorAndReturnToLogin(string errorTitle, string errorMessage, string errorIcon)
      {
         //let user know there is an issue
         DialogWindow dialog = new DialogWindow(errorTitle, errorMessage, errorIcon);
         dialog.Owner = this;
         dialog.ShowDialog();

         //go back to sign in screen
         LoginWindow loginWindow = new LoginWindow();
         this.Close();
         loginWindow.ShowDialog();
      }

      public void ShowPasswordGrids()
      {
         if (PasswordEntries == null)
         {
            ErrorAndReturnToLogin("Application Error", "Could not retrieve passwords from server", "Error");
         }
         else
         {
            if (PasswordEntries.Count < 1)
            {
               //if there are no passwords for user
            }
            else
            {
               PasswordList.Children.Clear();
               PasswordDataGrid grid = new PasswordDataGrid("Passwords", PasswordEntries);
               grid.Margin = new Thickness(50, 0, 50, 50);
               PasswordList.Children.Add(grid);
            }
         }
      }

      #endregion Methods
   }
}
