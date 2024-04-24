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
using BusinessLayer;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

namespace Dash
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();

            DSeriesCollection = new SeriesCollection();

            PieSeries piSeries = new PieSeries
            {
                Title = "Fuel",
                Values = new ChartValues<ObservableValue> { new ObservableValue(45) },
                DataLabels = true
            };
            DSeriesCollection.Add(piSeries);

            piSeries = new PieSeries
            {
                Title = "Food",
                Values = new ChartValues<ObservableValue> { new ObservableValue(41) },
                DataLabels = true
            };
            DSeriesCollection.Add(piSeries);

            piSeries = new PieSeries
            {
                Title = "Rent",
                Values = new ChartValues<ObservableValue> { new ObservableValue(230) },
                DataLabels = true
            };
            DSeriesCollection.Add(piSeries);


            DataContext = this;
        }

        public SeriesCollection DSeriesCollection { get; set; }


        public LaunchCollection Launches { get; set; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Launches = Launch.GetListLaunch();

            this.totalGamesTextBlock.Text = this.Launches.GetTotalGames().ToString();



        }



    }
}
