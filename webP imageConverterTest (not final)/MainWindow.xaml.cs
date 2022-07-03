using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Win32;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Media.Animation;
using System.Data.SqlClient;
using System.CodeDom;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Markup;
using System.Security.RightsManagement;
using Imazen.WebP;
using System.Net.Http;

namespace imageConverterTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public string destinationfolder, fullfile;
        public bool selectedFile=false;
        public MainWindow()
        {
            InitializeComponent();
            cnvs.Focusable = true;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.Description = "choose destination folder";
            if(dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtEditor.IsEnabled = true;
                txtEditor.Text = dlg.SelectedPath;
                destinationfolder = dlg.SelectedPath;
                txtEditor.Visibility = Visibility.Visible;
            }
        }
        private void buttonBrowse_Click(object sender, RoutedEventArgs e)
        {
            
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            //openFileDialog.Filter = "webp files (*.webp)|*.webp";
            if (openFileDialog.ShowDialog() == true)
            {
                //int size1;
                //size1 = openFileDialog.FileName.Length - filename.Length;
                fullfile = openFileDialog.FileName;
                selectedFile = true;
                // filedestination =  fullfile.Remove(size1, openFileDialog.SafeFileName.Length);
            }
        }

        private void image_Drop(object sender, System.Windows.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(System.Windows.DataFormats.FileDrop))
            {
                var files = (string[])e.Data.GetData(System.Windows.DataFormats.FileDrop);
                fullfile = System.IO.Path.GetFullPath(files[0]);

                UriBuilder builder = new UriBuilder();
                BitmapImage b = new BitmapImage();
                System.Windows.Controls.Image img = new System.Windows.Controls.Image();
                Uri u = new Uri(fullfile);
                b.BaseUri = u;
                ImageSourceConverter c = new ImageSourceConverter();
                ImageSourceValueSerializer isvs = new ImageSourceValueSerializer();
                //Uri.TryCreate(fullfile, UriKind.Absolute, out u);
                //image.Source = b;


                //image.Source = isvs.ConvertFromString(u.LocalPath,IValueSerializerContext);
                object k =  c.ConvertFromString(fullfile);
            //    string s = c.ConvertToString(image.Source);
                
                txtEditor.IsEnabled = true;
                txtEditor.Visibility = Visibility.Visible;
                txtEditor.Text = k.ToString();
            }
        }

        private void cnvs_Drop(object sender, System.Windows.DragEventArgs e)
        {
            System.Windows.Controls.Image img = new System.Windows.Controls.Image();
           // Canvas.SetLeft(image, 1000);
        }

        private void buttonConvert_Click(object sender, RoutedEventArgs e)
        {
            if (txtEditor.IsEnabled == true && selectedFile ==  true)
            {
                try
                {

                    Imazen.WebP.Extern.WebPPicture webPPicture = new Imazen.WebP.Extern.WebPPicture();
                    var buffer = File.ReadAllBytes(fullfile);
                    var decoder = new Imazen.WebP.SimpleDecoder();
                    string filename, filedestination, newfile;
                    filename = System.IO.Path.GetFileNameWithoutExtension(fullfile);
                    filedestination = System.IO.Path.GetDirectoryName(fullfile);
                    newfile = System.IO.Path.Combine(filedestination, filename);
                    //System.Drawing.Image png = System.Drawing.Image.FromFile(fullfile);
                    //if (fullfile.EndsWith(".webp"))
                    
                        var bitmap = decoder.DecodeFromBytes(buffer, buffer.Length);
                    
               //     else
                    
                  //      var bitmap = (Bitmap)Bitmap.FromFile(fullfile);
                    
                    using (MemoryStream ms = new MemoryStream())
                    {
                        bitmap.Save(newfile + ".jpg", ImageFormat.Jpeg);
                    }
                    bitmap.Dispose();
                }
                catch (IOException iox)
                {
                    System.Windows.MessageBox.Show(iox.Message);
                }
            }
            else
            {
                System.Windows.MessageBox.Show("Choose destination folder or choose file or both");
            }
        }
    }
}
