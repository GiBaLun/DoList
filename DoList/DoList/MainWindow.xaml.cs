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
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        string GiBaLunNote;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog aList = new Microsoft.Win32.OpenFileDialog();

            Nullable<bool> result = aList.ShowDialog();

            if (result == true)
            {
                GiBaLunNote = aList.FileName;

                string[] lines = System.IO.File.ReadAllLines(GiBaLunNote);

                foreach (string line in lines)
                {
                    string[] parts = line.Split('|');

                    DoDoList item = new DoDoList();

                    item.Day.Text = parts[0];
                    item.ItemName.Text = parts[1];
                    item.ItemPrice.Text = parts[2];

                   ToDoList.Children.Add(item);
                }
            }
        }



        private void Window_Closed(object sender, EventArgs e)
        {
            List<string> GiBaLuns = new List<string>();

            foreach (DoDoList item in ToDoList.Children)
            {
                string GiBaLun = "";

                 GiBaLun += item.Day.Text + "|" + item.ItemName.Text + "|" + item.ItemPrice.Text;

                GiBaLuns.Add(GiBaLun);
            }

            try
                {
                    System.IO.File.WriteAllLines(GiBaLunNote, GiBaLuns);
                }
            catch
            {
                Microsoft.Win32.SaveFileDialog aList = new Microsoft.Win32.SaveFileDialog();

                Nullable<bool> result = aList.ShowDialog();

                if (result == true)
                {
                    GiBaLunNote = aList.FileName;

                    System.IO.File.WriteAllLines(GiBaLunNote, GiBaLuns);
                }
            }
             
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            int all = 0;

            foreach (DoDoList item in ToDoList.Children)
            {
                all += item.itemPriceValue;
            }
            
             AllMoney.Text = all + "";

        }

        private void plus_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DoDoList item = new DoDoList();
            item.Delete += new EventHandler(Delete);

            ToDoList.Children.Add(item);
        }
        private void Delete(object sender, EventArgs e)
        {
            ToDoList.Children.Remove((DoDoList)sender);
        }
    }
}
