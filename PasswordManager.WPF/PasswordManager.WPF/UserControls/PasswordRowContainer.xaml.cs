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
   /// Interaction logic for PasswordEntryContainer.xaml
   /// </summary>
   public partial class PasswordRowContainer : UserControl
   {
      #region Variables
      private string _categoryName;
      public string CategoryName
      {
         get { return _categoryName; }
         set
         {
             _categoryName = value;
         }
      }

      private List<PasswordEntryObject> _passwords;

      public List<PasswordEntryObject> Passwords
      {
         get { return _passwords; }
         set
         {
            _passwords = value;
            Rows = CreateRows(_passwords);
         }
      }

      private List<PasswordRow> _rows;
      public List<PasswordRow> Rows
      {
            get { return _rows; }
         set
         {
            _rows = value;
            double height = 0;
            foreach (PasswordRow row in Rows)
            {
               Thickness thickness = new Thickness(0, height, 0, 0);
               row.Margin = thickness;
               RowGrid.Children.Add(row);
               height += 50;
            }
         }
      }

 


      #endregion Variables

      public PasswordRowContainer(string category)
      {
         InitializeComponent();
         CategoryName = category;
         TextBoxCategory.Content = CategoryName;

         
      }


      public List<PasswordRow> CreateRows(List<PasswordEntryObject> passwords)
      {
         List<PasswordRow> rows = new List<PasswordRow>();

         foreach(PasswordEntryObject password in passwords)
         {
            PasswordRow row = new PasswordRow(password);
            rows.Add(row);
         }

         return rows;
      }
   }
}
