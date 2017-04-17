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
			int input = 0;
			try
			{
				input = Int32.Parse(TextBox.Text);
				Label.Content = $"Znajduję {input}. liczbę pierwszą. Liczę... Chwileczkę";
			}
			catch (FormatException ex)
			{
				Label.Content = $"Podałeś: \"{TextBox.Text}\". Coś poszło nie tak...";
				return;
			}
			await Task.Factory.StartNew(() => primeNumber.Find(input),
										TaskCreationOptions.LongRunning);
			Label.Content = $"{primeNumber.GetKey()}. liczbą pierwszą z kolei jest: {primeNumber.GetValue()}";
		}
    }
}
