using Newtonsoft.Json;
using SQLite.Net;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
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
    public sealed partial class SqliteConnection : Page
    {
        public SqliteConnection()
        {
            this.InitializeComponent();
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var conn = await OpenOrRecreateConnection(true))
            {
                conn.CreateTable<TruckInfo>();
                foreach (var info in TruckInfos)
                {
                    conn.InsertOrReplace(info);
                }
            }

        }

        private async void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {

            using (var conn = await OpenOrRecreateConnection()) 
            {
                var infos = from p in conn.Table<TruckInfo>() select p;

                var names = string.Join(", ", infos.Select(t => t.Name));

                Result.Text = names;
            
            }


        }




        private async Task<SQLiteConnection> OpenOrRecreateConnection(bool ReCreate = false)
        {
            var filename = "trucks.sqlite";
            var folder = ApplicationData.Current.LocalFolder;

            if (ReCreate)
            {
                var file = await folder.TryGetItemAsync(filename);
                if (file != null)
                    await file.DeleteAsync();
            }

            var sqlpath = Path.Combine(folder.Path, filename);

            return new SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), sqlpath);
        }

        private static TruckInfo[] TruckInfos = new TruckInfo[]
        {
            new TruckInfo()
            {
                ID = "1",
                Name = "Burrito Boy",
                Style = "Mexica"
            },
            new TruckInfo()
            {
                ID = "2",
                Name = "Pasta Idol",
                Style = "Mexica"
            },
            new TruckInfo()
            {
                ID = "3",
                Name = "Burrito Boy",
                Style = "Desserts"
            },
        };

        
    }

    public class TruckInfo
    {
        [PrimaryKey]
        public string ID { get; set; }
        public string Name { get; set; }
        public string Style { get; set; }
    }


}
