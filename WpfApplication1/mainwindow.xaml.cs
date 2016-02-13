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
using System.Net;
using EasyHttp.Http;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<Guid> u1packages = new List<Guid>();
        List<Guid> u2packages = new List<Guid>();
        List<Guid> u3packages = new List<Guid>();
        List<Guid> u4packages = new List<Guid>();
        List<Guid> u5packages = new List<Guid>();
        List<string> verifiedusers = new List<string>();

        HttpListener listener = new HttpListener();

        int currentUser = 1;

        float startlat;
        float endlat;
        float startlong;
        float endlong;

        public MainWindow()
        {

            var http = new HttpClient("http://localhost:8080");

            InitializeComponent();
            
            http.Request.Accept = HttpContentTypes.ApplicationJson;
            listener.Start();
            listener.Prefixes.Add("127.0.0.1:8080");
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void VerifyAdmin(object sender, RoutedEventArgs e)
        {
            
        }

        private void User2(object sender, RoutedEventArgs e)
        {

        }

        private void User3(object sender, RoutedEventArgs e)
        {

        }

        private void User4(object sender, RoutedEventArgs e)
        {

        }

        private void User5(object sender, RoutedEventArgs e)
        {

        }

        private void NewAccount(object sender, RoutedEventArgs e)
        {
            if (verifiedusers.Count > 3)
            {
                MaxUsers useralert = new MaxUsers();
                useralert.ShowDialog();
            }
            if (verifiedusers.Count <= 3)
            {
                AddUserPopup userpopup = new AddUserPopup();
                userpopup.ShowDialog();
                if (verifiedusers.Contains(userpopup.username))
                {
                    UserExists existspopup = new UserExists();
                    existspopup.ShowDialog();
                } else
                {
                    var menuitemtemp = new MenuItem();
                    menuitemtemp.Header = userpopup.username;
                    verifiedusers.Add(userpopup.username);
                    switch (verifiedusers.Count)
                    {
                        case 0:
                            menuitemtemp.Click += User2;
                            break;
                        case 1:
                            menuitemtemp.Click += User3;
                            break;
                        case 2:
                            menuitemtemp.Click += User4;
                            break;
                        case 3:
                            menuitemtemp.Click += User5;
                            break;
                    }
                    UserMenu.Items.Add(menuitemtemp);
                }
            }
        }

        private void NewPackageGET(HttpClient http)
        {
            var newpackageuuid = Guid.NewGuid();
            switch (currentUser)
            {
                case 1:
                    u1packages.Add(newpackageuuid);
                    break;
                case 2:
                    u1packages.Add(newpackageuuid);
                    u2packages.Add(newpackageuuid);
                    break;
                case 3:
                    u1packages.Add(newpackageuuid);
                    u3packages.Add(newpackageuuid);
                    break;
                case 4:
                    u1packages.Add(newpackageuuid);
                    u4packages.Add(newpackageuuid);
                    break;
                case 5:
                    u1packages.Add(newpackageuuid);
                    u5packages.Add(newpackageuuid);
                    break;
            }
            
        }

        private void showGMAP(float latstart, float longstart, float latend, float longend)
        {
            var link = "https://www.google.com/maps/dir/" + Convert.ToString(latstart) + "," + Convert.ToString(longstart) + "/" + Convert.ToString(latend) + "," + Convert.ToString(longend);
            WebViewer.Navigate(new Uri(link));
        }
    }
}
