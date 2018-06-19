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

namespace DoList
{
    /// <summary>
    /// item.xaml 的互動邏輯
    /// </summary>
    public partial class DoDoList : UserControl
    {

        public DoDoList()
        {
            InitializeComponent();
        }

        public int itemPriceValue
        {
            get
            {
                 try
                {
                    return int.Parse(ItemPrice.Text);
                }
                catch
                {
                    MessageBox.Show("請輸入數字");
                    return 0;
                }
            }
            set
            {
                ItemPrice.Text = value.ToString();
            }
        }

        public event EventHandler Delete;

        private void itemPrice_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (ItemPrice.Text == "" && e.Key == Key.Back)
            {
                Delete(this, null);
            }
        }

        private void Day_GotFocus(object sender, RoutedEventArgs e)
        {
            Day.Text = "";
        }

        private void Day_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Day.Text == "")
                Day.Text = DateTime.Now.ToString("M / dd");
        }

        private void Day_Loaded(object sender, RoutedEventArgs e)
        {
            Day.Text = DateTime.Now.ToString("M / dd");
        }

        private void ItemName_GotFocus(object sender, RoutedEventArgs e)
        {
            ItemName.Text = "";
        }

        private void ItemName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (ItemName.Text == "")
                ItemName.Text = "New Task";
        }

        private void ItemPrice_GotFocus(object sender, RoutedEventArgs e)
        {
            ItemPrice.Text = "";
        }

        private void ItemPrice_LostFocus(object sender, RoutedEventArgs e)
        {
            if (ItemPrice.Text == "")
                ItemPrice.Text = "0";
        }
    }
}
