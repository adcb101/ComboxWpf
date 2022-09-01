using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

   
    public partial class MainWindow : Window
    {

        ObservableCollection<Customer> custdata = new ObservableCollection<Customer>();

        public MainWindow()
            {
                InitializeComponent();
              combobox1.SelectedIndex = 0;
                Customer cm = new Customer();
                 cm.name = "33";
                cm.sex = SexEnum.男;
                custdata.Add(cm);
            Customer cm4 = new Customer();
            cm4.name = "34";
            cm4.sex = SexEnum.女;
            custdata.Add(cm4);
            DG1.ItemsSource = custdata;

         }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SexEnum type = (SexEnum)System.Enum.Parse(typeof(SexEnum), combobox1.Text);
            foreach (var item in custdata)
            {
                item.sex = type;
            }
            DG1.ItemsSource = null;
            DG1.ItemsSource = custdata;
            string x = "";
            foreach (var item in custdata)
            {
                var s = item.sex.ToString();
                x += s;
            }
           
            //DataGridTemplateColumn tempColumn1 = DG1.Columns[1] as DataGridTemplateColumn;
            //FrameworkElement element1 = tempColumn1.GetCellContent(DG1.Items[0]);
            //ComboBox comboBox1 = tempColumn1.CellTemplate.FindName("combobox2", element1) as ComboBox;
            //string info= "\n\r comboBox1:   " + comboBox1.Text;

            MessageBox.Show("项目参数修改结果: \n" + x, "提示");
        }

        private void combobox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //custdata.ForEach
            SexEnum type = (SexEnum)System.Enum.Parse(typeof(SexEnum), combobox1.Text);
            foreach (var item in custdata)
            {
                item.sex = type;
            }

        }
    }

    public class Customer
    {
        public SexEnum sex { get; set; }
        public string name { get; set; }
    }
    public enum SexEnum { 男, 女 };
}
