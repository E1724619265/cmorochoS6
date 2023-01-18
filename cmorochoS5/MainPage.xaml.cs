using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace cmorochoS5
{
    public partial class MainPage : ContentPage
    {

        private const string Url = "http://192.168.56.1//moviles/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<cmorochoS5.datos> _post;
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnget_Clicked(object sender, EventArgs e)
        {
            var content = await client.GetStringAsync(Url);
            List<cmorochoS5.datos> posts = JsonConvert.DeserializeObject<List<cmorochoS5.datos>>(content);
            _post = new ObservableCollection<cmorochoS5.datos>(posts);

            MyListView.ItemsSource = _post;
        }

        private void btnnext_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new registro());
        }
    }
}
