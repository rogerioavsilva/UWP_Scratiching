using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization.Json;
using System.Xml.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace DataAsy_Sec4
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RestCall : Page
    {
        public RestCall()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            //step 1
            //var client = new HttpClient();
            //var text = await client.GetStringAsync("http://servicos.cptec.inpe.br/XML/listaCidades");

            var client = new HttpClient();
            var response = await client.GetAsync("http://servicos.cptec.inpe.br/XML/listaCidades");
            var text = await response.Content.ReadAsStringAsync();
            var xml = XElement.Parse(text);
            var title = xml.Element("cidade").Elements("cidades").Select(i => i.Element("uf").Value);
            Result.Text = string.Join("\r\n", title);
        }


        private async void Button_ClickJson(object sender, RoutedEventArgs e)
        {

            var client = new HttpClient();
            var response = await client.GetAsync("https://jsonplaceholder.typicode.com/posts");
            var text = await response.Content.ReadAsStringAsync();

            var posts = JsonConvert.DeserializeObject<Posts[]>(text);

            var titles = string.Join("\n", posts.Select(p => p.title));

            Result.Text = titles;

            //using (var stream = await response.Content.ReadAsStreamAsync())
            //{
            //    var desserializer = new DataContractJsonSerializer(typeof(Posts[]));

            //    var posts = (Posts[])desserializer.ReadObject(stream);

            //    var titles = string.Join("\n", posts.Select( p => p.title));

            //    Result.Text = titles;
            //}
        }

        public class Rootobject
        {
            public Posts[] Property { get; set; }
        }

        public class Posts
        {
            public string userId { get; set; }
            public string id { get; set; }
            public string title { get; set; }
            public string body { get; set; }
        }


    }

    
}
