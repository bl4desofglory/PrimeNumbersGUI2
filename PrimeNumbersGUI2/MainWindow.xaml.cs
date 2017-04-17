using PrimeNumbersGUI2.Models;
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

namespace PrimeNumbersGUI2
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PrimeNumber primeNumber = new PrimeNumber();

		public MainWindow()
        {
            InitializeComponent();
        }

		private async void Button_Click(object sender, EventArgs e)
		{
			int input = Int32.Parse(TextBox.Text);
			Label.Content = $"Podałeś {input}. Liczę... Chwileczkę";
			var progress = new Progress<string>(s => Label.Content = s);
			await Task.Factory.StartNew(() => primeNumber.Find(input),
										TaskCreationOptions.LongRunning);
			Label.Content = $"Liczbą pierwszą {primeNumber.GetKey()} z kolei jest {primeNumber.GetValue()}";
		}
    }
}
