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

            //DSeriesCollection = new SeriesCollection();

            //PieSeries piSeries = new PieSeries
            //{
            //    Title = "Fuel",
            //    Values = new ChartValues<ObservableValue> { new ObservableValue(45) },
            //    DataLabels = true
            //};
            //DSeriesCollection.Add(piSeries);

            //piSeries = new PieSeries
            //{
            //    Title = "Food",
            //    Values = new ChartValues<ObservableValue> { new ObservableValue(41) },
            //    DataLabels = true
            //};
            //DSeriesCollection.Add(piSeries);

            //piSeries = new PieSeries
            //{
            //    Title = "Rent",
            //    Values = new ChartValues<ObservableValue> { new ObservableValue(230) },
            //    DataLabels = true
            //};
            //DSeriesCollection.Add(piSeries);


           // DataContext = this;
        }

        public SeriesCollection DSeriesCollection { get; set; }


        public LaunchCollection Launches { get; set; }

        public PlatformCollection Platforms { get; set; }

        public PublisherCollection Publishers { get; set; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Launches = Launch.GetListLaunch();

            //this.totalLaunchesTextBlock.Text = this.Launches.GetTotalLaunches().ToString();
            this.totalGamesTextBlock.Text = this.Launches.GetTotalGames().ToString();



            //preenchimento das combo box
            int[] allYears = this.Launches.GetAllYears();
            for (int i = 0; i < allYears.Length; i++)
            {
                this.allYearsComboBox.Items.Add(allYears[i]);
            }

            this.platformsComboBox.SelectedValuePath = "Id";
            this.platformsComboBox.DisplayMemberPath = "PlatformName";

            Platforms = Platform.GetListPlatform();
            //string[] platforms = this.Platforms.GetPlatforms();
            //for (int i = 0; i < platforms.Length; i++)
            //{
            //    this.platformsComboBox.Items.Add(platforms[i]);
            //}
            this.platformsComboBox.ItemsSource = this.Platforms;

            Publishers = Publisher.GetListPublisher();
            string[] publishers = this.Publishers.GetPublishers();
            for (int i = 0; i < publishers.Length; i++)
            {
                this.publishersComboBox.Items.Add(publishers[i]);
            }

            this.allYearsComboBox.SelectionChanged += allYearsComboBox_SelectionChanged;
        }

        private void FilterValues(int year, long platformId)
        {
            int total = this.Launches.GetTotalLaunchesByFilter(year, platformId);
            this.totalLaunchesTextBlock.Text = total.ToString();

            DSeriesCollection = new SeriesCollection();

            foreach (Launch item in this.Launches)
            {
                PieSeries piSeries = new PieSeries
            {
                Title = item.GameId.ToString(),
                Values = new ChartValues<ObservableValue> { new ObservableValue(item.SalesNumber) },
                DataLabels = true
            };
            DSeriesCollection.Add(piSeries);
            }
            DataContext = this;
        }

        private void allYearsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.Filter();
            
        }

        private void Filter()
        {
            int year = 0;
            long platformId = 0;

            if (this.allYearsComboBox.SelectedItem != null)
            {
                year = (int)this.allYearsComboBox.SelectedItem;
            }
            if (this.platformsComboBox.SelectedItem != null)
            {
                platformId = ((Platform)this.platformsComboBox.SelectedItem).Id;
            }
            this.FilterValues(year, platformId);
        }
    }
}
