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
        }

        public SeriesCollection DSeriesCollection { get; set; }

        public LaunchCollection Launches { get; set; }

        public GameCollection Games { get; set; }

        public PlatformCollection Platforms { get; set; }

        public PublisherCollection Publishers { get; set; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Launches = Launch.GetListLaunch();

            //preenchimento das combo box
            int[] allYears = this.Launches.GetAllYears();
            for (int i = 0; i < allYears.Length; i++)
            {
                this.allYearsComboBox.Items.Add(allYears[i]);
            }

            this.platformsComboBox.SelectedValuePath = "Id";
            this.platformsComboBox.DisplayMemberPath = "PlatformName";
            this.Platforms = Platform.GetListPlatform();
            this.platformsComboBox.ItemsSource = this.Platforms;

            this.publishersComboBox.SelectedValuePath = "Id";
            this.publishersComboBox.DisplayMemberPath = "PublisherName";
            this.Publishers = Publisher.GetListPublisher();
            this.publishersComboBox.ItemsSource = this.Publishers;


            this.allYearsComboBox.SelectionChanged += allYearsComboBox_SelectionChanged;
        }

        private void FilterValues(int year, long platformId, long publisherId)
        {
            int totalLaunches = this.Launches.GetTotalLaunchesByFilter(year, platformId, publisherId);
            this.totalLaunchesTextBlock.Text = totalLaunches.ToString();

            int totalGames = this.Launches.GetTotalGamesByFilter(year, platformId, publisherId);
            this.totalGamesTextBlock.Text = totalGames.ToString();

            int mostUsedlLatform = (int)this.Launches.GetMostUsedPlatformByFilter(year, publisherId);
            string platform = Platforms.GetPlatformNameById(mostUsedlLatform);
            this.mostPlatformTextBlock.Text = platform;


            int mostUsedPublisher = (int)this.Launches.GetMostUsedPublisherByFilter(year, publisherId);
            string publisher = Publishers.GetPublisherNameById(mostUsedPublisher);
            this.mostPublisherTextBlock.Text = publisher;


            DSeriesCollection = new SeriesCollection();
            Games = new GameCollection();
            foreach (Launch item in this.Launches)
            {
                if (item.RealeaseDate.Year == year)
                {
                    string gameName = this.Games.GetGameNameById(item.GameId);
                    PieSeries piSeries = new PieSeries
                    {
                        Title = gameName,
                        Values = new ChartValues<ObservableValue> { new ObservableValue(item.SalesNumber) },
                        DataLabels = true
                    };
                    DSeriesCollection.Add(piSeries);
                }
            }
            DataContext = this;
        }
        private void Filter()
        {
            int year = 0;
            long platformId = 0;
            long publisherId = 0;

            if (this.allYearsComboBox.SelectedItem != null)
            {
                year = (int)this.allYearsComboBox.SelectedItem;
            }
            if (this.platformsComboBox.SelectedItem != null)
            {
                platformId = ((Platform)this.platformsComboBox.SelectedItem).Id;
            }
            if (this.publishersComboBox.SelectedItem != null)
            {
                publisherId = ((Publisher)this.publishersComboBox.SelectedItem).Id;
            }
            this.FilterValues(year, platformId, publisherId);
        }

        private void allYearsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.Filter();
            
        }
        private void platformsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.Filter();
        }

        private void publishersComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.Filter();
        }


    }
}
