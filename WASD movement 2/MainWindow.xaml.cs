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
using System.Windows.Threading;

namespace GameW
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double pup;
        double pleft;
        Key lastkey = new Key();

        int keycount = 0;
        int up =0;
        int left =0;
        int spd;

        bool gun = false;
        bool gunshot = false;
        DispatcherTimer gtimer = new DispatcherTimer();

        DispatcherTimer gstimer = new DispatcherTimer();
        

        public MainWindow()
        {
            
            InitializeComponent();
            gtimer.Tick += MainEventTimer;
            gtimer.Interval= TimeSpan.FromMilliseconds(10);
            gtimer.Start();
            Canvas.SetLeft(StartImage, 193);
            Canvas.SetTop(StartImage, 134);

            gstimer.Tick += Gstimer_Tick;
            gstimer.Interval = TimeSpan.FromMilliseconds(10);

        }

        private void MainEventTimer(object sender, EventArgs e)
        {
            cnvs.Focus();
            pup = Canvas.GetTop(player1);
            pleft = Canvas.GetLeft(player1);

            if (Canvas.GetLeft(player1) + 60 == Canvas.GetLeft(gun1))
            {
                var uriSource = new Uri(@"/GameW;component/Images/playerwithgun.png", UriKind.Relative);
                player1.Source = new BitmapImage(uriSource);
                Canvas.SetLeft(gun1, -12);
                Canvas.SetTop(gun1, -474);
                gun = true;
            }
            //   if(keyWcount==0) { spd = 2; }
            //  if(keyAcount==0) { spd = 2; }
            // if(keyWcount>10 || keyScount>10) { spd = 4; }
            //  if(keyAcount>10 ||keyDcount>10) { spd = 4; }

            if (keycount > 10)
            {
                spd = 4;
            }
            else { spd = 2; }
            if (up == 1)
            {
                pup -= spd;
                if (left == 1) { pleft -= spd; }
                if (left == -1) { pleft += spd; }
            }
            if (up == -1)
            {
                pup += spd;
                if (left == 1) { pleft -= spd; }
                if (left == -1) { pleft += spd; }
            }
            if (left == 1 && up == 0) { pleft -= spd; }
            if (left == -1 && up == 0) { pleft += spd; }
            Canvas.SetTop(player1, pup);
            Canvas.SetLeft(player1, pleft);

            if(gun ==true && gunshot==true)
            {
                var shotsource = new Uri(@"/GameW;component/Images/bullet1.png", UriKind.Relative);
                Point bulletpoint = new Point(Canvas.GetLeft(player1) + 60, Canvas.GetTop(player1) + 47);
                //  int length= Math.Pow(Math.pow)
                Image shot = new Image();
                shot.Height = 3;
                shot.Width = 4;
                BitmapImage logo = new BitmapImage();
                logo.BeginInit();
                logo.UriSource = shotsource;
                logo.EndInit();
                shot.Source = logo;
                Canvas.SetLeft(shot, bulletpoint.X);
                Canvas.SetTop(shot, bulletpoint.Y);
                cnvs.Children.Add(shot);

                if (Canvas.GetLeft(shot) < 500)
                {
                    Canvas.SetLeft(shot, Canvas.GetLeft(shot) + 5);
                }
                
                // Canvas.SetTop(bullet1, bulletpoint.Y);
                // Canvas.SetLeft(bullet1, bulletpoint.X);
                // Vector v = new Vector();
                
                textBox.Text = (Canvas.GetTop(player1) + 47 + "    " + (Canvas.GetLeft(player1) + 60));
                
            }

        }
        private void image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            StartImage.Height -=2;
            StartImage.Width -=2;
        }
        private void StartImage_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Canvas.SetLeft(StartImage, -302);
            Canvas.SetTop(StartImage, -307);

            Canvas.SetLeft(player1, 216);
            Canvas.SetTop(player1, 230);

            Canvas.SetLeft(gun1, 388);
            Canvas.SetTop(gun1, 32);          
        }
        private void cnvs_KeyDown(object sender, KeyEventArgs e)
        {
            //wasd movement 
            if(true)
            {


                /*
                  if (e.Key == Key.W)
                  {
                      if(lastkey==Key.W)
                      {
                          keycount++;
                          if(keycount >= 15)
                          {
                              pup -= 6;
                          }
                          else { pup -= 3; }
                      }
                      else
                      {
                          pup -= 3;
                          keycount = 0;
                      }            
                      Canvas.SetTop(player1, pup);
                      lastkey = Key.W;
                  }
                  if (e.Key == Key.S)
                  {

                      if (lastkey == Key.S)
                      {
                          keycount++;
                          if (keycount >= 15)
                          {
                              pup += 6;
                          }
                          else { pup += 3; }
                      }
                      else
                      {
                          pup += 3;
                          keycount = 0;
                      }
                      Canvas.SetTop(player1, pup);
                      lastkey = Key.S;
                  }
                  if (e.Key == Key.A)
                  {
                      if (lastkey == Key.A)
                      {
                          keycount++;
                          if (keycount >= 15)
                          {
                              pleft -= 6;
                          }
                          else { pleft -= 3; }
                      }
                      else
                      {
                          pleft -= 3;
                          keycount = 0;
                      }
                      Canvas.SetLeft(player1, pleft);
                      lastkey = Key.A;
                  }
                  if (e.Key == Key.D)
                  {
                      if (lastkey == Key.D)
                      {
                          keycount++;
                          if (keycount >= 15)
                          {
                              pleft += 6;
                          }
                          else { pleft += 3; }
                      }
                      else
                      {
                          pleft += 3;
                          keycount = 0;
                      }
                      Canvas.SetLeft(player1, pleft);
                      lastkey = Key.D;
                  }
                */
            }
            if (e.Key == Key.W) { up = 1; lastkey = Key.W; if (lastkey == Key.W) { keycount++; } }
            if(e.Key == Key.A){ left = 1; lastkey = Key.A; if (lastkey == Key.A) { keycount++; } }
            if(e.Key==Key.S){ up = -1; lastkey = Key.S; if (lastkey == Key.S) { keycount++; } }
            if(e.Key==Key.D){ left = -1; lastkey = Key.D; if (lastkey == Key.D) { keycount++; } }
        }

        private void cnvs_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.Key==Key.W || e.Key==Key.S)
            {
                if(e.Key==Key.W)
                {
                    keycount = 0;
                }
                else { keycount = 0; }
                up = 0;
            }
            if(e.Key==Key.A || e.Key==Key.D)
            {
                if(e.Key==Key.A)
                {
                    keycount = 0;
                }
                else { keycount = 0; }
                left = 0;
            }
        }
        private void cnvs_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //if(gun==true)
            //{
            //    gunshot = true;
            //}
            /*
            var shotsource = new Uri(@"/GameW;component/Images/bullet1.png", UriKind.Relative);
            Point p = e.GetPosition(this.cnvs);
            if(gun)
            {
                Image shot = new Image();
                shot.Height = 3;
                shot.Width = 4;
                shot.Source = new BitmapImage(shotsource);
                Canvas.SetLeft(shot, p.X);
                Canvas.SetTop(shot, p.Y);

                gstimer.Start();
                Canvas.SetLeft(bullet1, p.X);
                Canvas.SetTop(bullet1, p.Y);
            }
            */
        }
        private void Gstimer_Tick(object sender, EventArgs e)
        {
            Point pointToWindow = Mouse.GetPosition(this);

        }

    }
}
