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

namespace Zippers.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddPage.xaml
    /// </summary>
    public partial class AddPage : Page
    {
        public static Zip Zips { get; set; }
        public List<TypeZip> TypeZipp { get; set; }    
        public AddPage()
        {
            InitializeComponent();
            TypeCb.ItemsSource = null;
            TypeZipp = App.db.TypeZip.ToList();
            TypeCb.ItemsSource = TypeZipp;
            

        }

        private void Savebt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Zip zip = new Zip()
                {
                    Title = Titletb.Text,
                    TypeZipId = (TypeCb.SelectedItem as TypeZip).Id,
                    Color = Colortb.Text

                };
                App.db.Zip.Add(zip);
                App.db.SaveChanges();
                MessageBox.Show("Добавлено", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                Titletb.Text = "";
                Colortb.Text = "";
                TypeCb.ItemsSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Backbt_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ListPage1());
        }
    }
}
