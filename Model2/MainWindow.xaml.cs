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

        private long? PublisherIdFiltered = null;

        private long? PlatformIdFiltered = null;

        private int? YearFiltered = null;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Launches = Launch.GetListLaunch();

            //preenchimento das combo box
            int[] allYears = this.Launches.GetAllYears();
            Array.Sort(allYears);
            for (int i = 0; i < allYears.Length; i++)
            {
                this.allYearsComboBox.Items.Add(allYears[i]);
            }

            this.platformsComboBox.SelectedValuePath = "Id";
            this.platformsComboBox.DisplayMemberPath = "PlatformName";
            this.Platforms = Platform.GetListPlatform();
            this.SetPlatforms();
            

            this.publishersComboBox.SelectedValuePath = "Id";
            this.publishersComboBox.DisplayMemberPath = "PublisherName";
            this.Publishers = Publisher.GetListPublisher();
            this.SetPublishers();
            //this.publishersComboBox.ItemsSource = this.Publishers;


            this.allYearsComboBox.SelectionChanged += allYearsComboBox_SelectionChanged;
        }

        private void SetPublishers()
        {
            this.publishersComboBox.ItemsSource = this.Publishers;
        }

        private void SetPlatforms()
        {
            this.platformsComboBox.ItemsSource = this.Platforms;
            
        }
        private void SetYears()
        {
            
        }

        private void FilterValues( )
        {
            int totalLaunches = this.Launches.GetTotalLaunchesByFilter(this.YearFiltered, this.PlatformIdFiltered, this.PublisherIdFiltered);
            this.totalLaunchesTextBlock.Text = totalLaunches.ToString();

            int totalGames = this.Launches.GetTotalGamesByFilter(this.YearFiltered, this.PlatformIdFiltered, this.PublisherIdFiltered);
            this.totalGamesTextBlock.Text = totalGames.ToString();

            int mostUsedlLatform = (int)this.Launches.GetMostUsedPlatformByFilter(this.YearFiltered, this.PublisherIdFiltered);
            string platform = Platforms.GetPlatformNameById(mostUsedlLatform);
            this.mostPlatformTextBlock.Text = platform;


            int mostUsedPublisher = (int)this.Launches.GetMostUsedPublisherByFilter(this.YearFiltered, this.PublisherIdFiltered);
            string publisher = Publishers.GetPublisherNameById(mostUsedPublisher);
            this.mostPublisherTextBlock.Text = publisher;

            DSeriesCollection = new SeriesCollection();
            Games = new GameCollection();
            foreach (Launch item in this.Launches)
            {
                if (item.RealeaseDate.Year == this.YearFiltered)
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
            //int year = 0;
            //long platformId = 0;
            //long publisherId = 0;

            if (this.allYearsComboBox.SelectedItem != null)
            {
                this.YearFiltered = (int)this.allYearsComboBox.SelectedItem;


            }
            else
            {
                this.YearFiltered = null;
            }
            if (this.platformsComboBox.SelectedItem != null)
            {
                this.PlatformIdFiltered = ((Platform)this.platformsComboBox.SelectedItem).Id;
            }
            else
            {
                this.PlatformIdFiltered = null;
            }
            if (this.publishersComboBox.SelectedItem != null)
            {
                this.PublisherIdFiltered = ((Publisher)this.publishersComboBox.SelectedItem).Id;
            }
            else
            {
                this.PublisherIdFiltered = null;
            }
            this.FilterValues();
            this.RefreshCombos();
        }

        private void RefreshCombos()
        {
            SetYears();
            SetPlatforms();
            SetPublishers();
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
