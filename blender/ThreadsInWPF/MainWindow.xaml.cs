using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace ThreadsInWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnPutIn1_Click(object sender, RoutedEventArgs e)
        {
            if (lbFruits.SelectedItem != null)
            {
                var fruit = (lbFruits.SelectedItem as ListBoxItem).Content;
                lbBlender1.Items.Add(new ListBoxItem { Content = fruit });
            }
        }

        private void BtnPutIn2_Click(object sender, RoutedEventArgs e)
        {
            if (lbFruits.SelectedItem != null)
            {
                var fruit = (lbFruits.SelectedItem as ListBoxItem).Content;
                lbBlender2.Items.Add(new ListBoxItem { Content = fruit });
            }
        }

        private void BtnBlend1_Click(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(Blend1);
            thread.Start();
        }

        private void BtnBlend2_Click(object sender, RoutedEventArgs e)
        {
            Thread thread2 = new Thread(Blend2);
            thread2.Start();
        }

        private void Blend1()
        {
            int blendTime = 10;
            btnBlend1.Dispatcher.Invoke(new Action(() => btnBlend1.IsEnabled = false));
            for (int i = 0; i < blendTime; i++)
            {
                lblStatus1.Dispatcher.Invoke(new Action(() => lblStatus1.Content = $"Blending {i}"));
                Thread.Sleep(1000);                
            }
            btnBlend1.Dispatcher.Invoke(new Action(() => btnBlend1.IsEnabled = true));
            lblStatus1.Dispatcher.Invoke(new Action(() => lblStatus1.Content = "Juice Ready"));
                
        }

        private void Blend2()
        {
            int blendTime = 10;
            btnBlend2.Dispatcher.Invoke(new Action(() => btnBlend2.IsEnabled = false));
            for (int i = 0; i < blendTime; i++)
            {
                lblStatus2.Dispatcher.Invoke(new Action(() => lblStatus2.Content = $"Blending{i}"));
                Thread.Sleep(1000);
                
            }
            lblStatus2.Dispatcher.Invoke(new Action(() => lblStatus2.Content = "Juice Ready"));
            btnBlend2.Dispatcher.Invoke(new Action(() => btnBlend2.IsEnabled = true));
        }

        private void btnClean1_Click(object sender, RoutedEventArgs e)
        {
            Thread cleaner = new Thread(Clean1);
            cleaner.Start();
        }

        private void Clean1()
        {
            int cleanTime = 2;
            
            btnClean1.Dispatcher.Invoke(new Action(() => btnClean1.IsEnabled = false));
            for (int i = 0; i < cleanTime; i++)
            {
                lblStatus1.Dispatcher.Invoke(new Action(() => lblStatus1.Content = $"Cleaning{i}"));
                lbBlender1.Dispatcher.Invoke(new Action(() => lbBlender1.Items.Clear()));
                Thread.Sleep(1000);

            }
            lblStatus1.Dispatcher.Invoke(new Action(() => lblStatus1.Content = "Cleaned"));
            btnClean1.Dispatcher.Invoke(new Action(() => btnClean1.IsEnabled = true));
        }

        private void BtnClean2_Click(object sender, RoutedEventArgs e)
        {
            Thread cleaner = new Thread(Clean2);
            cleaner.Start();
        }

        private void Clean2()
        {
            int cleanTime = 2;

            btnClean2.Dispatcher.Invoke(new Action(() => btnClean2.IsEnabled = false));
            for (int i = 0; i < cleanTime; i++)
            {
                lblStatus2.Dispatcher.Invoke(new Action(() => lblStatus2.Content = $"Cleaning{i}"));
                lbBlender2.Dispatcher.Invoke(new Action(() => lbBlender2.Items.Clear()));
                Thread.Sleep(1000);

            }
            lblStatus2.Dispatcher.Invoke(new Action(() => lblStatus2.Content = "Cleaned"));
            btnClean2.Dispatcher.Invoke(new Action(() => btnClean2.IsEnabled = true));
        }

        private void BtnStop1_Click(object sender, RoutedEventArgs e)
        {
            Thread stop = new Thread(Stop);
            stop.Start();
        }

        private void Stop()
        {

        }
    }

}
