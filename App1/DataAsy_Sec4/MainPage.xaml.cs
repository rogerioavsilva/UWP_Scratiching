using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DataAsy_Sec4
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        //private async void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    var Folder = Windows.ApplicationModel.Package.Current.InstalledLocation;
        //    var File = await Folder.GetFileAsync("Help.txt");
        //    await Task.Delay(3000);
        //    //Task.Delay(3000).Wait(); //breaking screen
        //    var Text = await FileIO.ReadTextAsync(File);
        //    Result.Text = Text;
        //}

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var picker = new FolderPicker();
            picker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            picker.FileTypeFilter.Add("*");

            var folder = await picker.PickSingleFolderAsync();
            var files = await folder.GetFilesAsync();

            CancelPictures();

            _cts = new CancellationTokenSource();

            var AddImageTasks = new List<Task<Image>>();

            foreach( var file in files)
            {

                AddImageTasks.Add(AddImagemFromFileAsync(file, _cts.Token));

                //await Task.Delay(2000);

                //using (var stream = await file.OpenReadAsync())
                //{
                //    var bi = new BitmapImage();
                //    bi.SetSource(stream);

                //    var image = new Image() { Width = 200, Height = 200 };
                //    image.Source = bi;
                //    ControlPanel.Children.Add(image);
                //}
            }

            try
            {
                await Task.WhenAll(AddImageTasks);
            }
            catch (OperationCanceledException)
            {
                return;
            }


            foreach(var task in AddImageTasks)
            {
                var image = await task;

                if(image != null)
                    ControlPanel.Children.Add(image);
            }

            //var picker = new FileOpenPicker();
            //picker.ViewMode = PickerViewMode.Thumbnail;
            //picker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            //picker.FileTypeFilter.Add(".jpg");
            //picker.FileTypeFilter.Add(".jpeg");
            //picker.FileTypeFilter.Add(".png");

            //var file = await picker.PickSingleFileAsync();

            //var stream = await file.OpenReadAsync();
            //var image = new BitmapImage();
            //image.SetSource(stream);
            //Pic.Source = image;
        }

        private void CancelPictures()
        {
            if(_cts != null)
            {
                _cts.Cancel();
                _cts = null;
            }
        }

        CancellationTokenSource _cts;

        private async Task<Image> AddImagemFromFileAsync(StorageFile file, CancellationToken Token)
        {
            await Task.Delay(2000);

            using (var stream = await file.OpenReadAsync())
            {

                Token.ThrowIfCancellationRequested();
                //if (Token.IsCancellationRequested)
                //    return null;

                var bi = new BitmapImage();
                bi.SetSource(stream);

                var image = new Image() { Width = 200, Height = 200 };
                image.Source = bi;
                return image;
                //ControlPanel.Children.Add(image);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            CancelPictures();
        }
    }
}
