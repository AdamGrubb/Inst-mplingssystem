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

namespace Övningen27augusti
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string[] tidVal = {"06:00", "06:30", "07:00", "07:30", "08:00", "08:30", "09:00", "10:00",
            "10:30", "11:00", "11:30", "12:00", "12:30", "13:00", "13:30", "14:00",
            "14:30", "15:00", "15:30", "16:00", "16:30", "17:00", "17:30", "18:00"};
        public string[] TidVal 
        { 
            get
            {
                return tidVal;
            }
            set
            {
                tidVal = value;
            }
        }
        public List<string> instämplingar = new List<string>();


        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            EnableButton();
            RefreshListbox();
        }
        private void EnableButton()
        {
            if (InputWorker.Text.Length == 0 || Instämpling.SelectedItem == null || Utstämpling.SelectedItem == null || WorkerSelectDate.SelectedDate == null)
            {
                Registrera.IsEnabled = false;
            }
            else Registrera.IsEnabled = true;
        }


        private void Registrera_Click(object sender, RoutedEventArgs e)
        {
            TimeSpan startTime = new TimeSpan();
            startTime = TimeSpan.Parse(Utstämpling.SelectedItem.ToString()) - TimeSpan.Parse(Instämpling.SelectedItem.ToString()); //mellanskilnnadne?

            string stämpling = $"{InputWorker.Text}\n{WorkerSelectDate.SelectedDate.Value.ToString("d")} {Instämpling.SelectedItem.ToString()} - {Utstämpling.SelectedItem.ToString()}\nArbetade timmar: {startTime.ToString("hh\\:mm")}";
            instämplingar.Add(stämpling);
            RefreshListbox();
        }

        private void RefreshListbox()
        {
            ListInstämpling.ItemsSource = null;
            ListInstämpling.ItemsSource = instämplingar;
        }

        private void InputWorker_TextChanged(object sender, TextChangedEventArgs e)
        {
            EnableButton();
        }

        private void WorkerSelectDate_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            EnableButton();
        }

        private void Instämpling_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EnableButton();
        }

        private void Utstämpling_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EnableButton();
        }
    }
}
