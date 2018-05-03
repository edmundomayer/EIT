using es.eit.application;
using es.eit.application.Messages;
using es.eit.application.Services;
using es.eit.application.Views.ComplexViews;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

namespace es.eit.wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        protected static readonly log4net.ILog log = log4net.LogManager.GetLogger( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType );

        IDepartment_Service service = API.Container.GetInstance<IDepartment_Service>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void cmdLoadSampleList_Click( object sender, RoutedEventArgs e )
        {
            //this.dgSample.ItemsSource = null;

            //var request = new Sample_Request();

            //var result = service.GetAll( request );

            //var data = result.Items.Cast<SubSample_By_Sample_View>().ToList();

            this.dgSample.ItemsSource = await GetSamples(new Uri( "http://localhost:2817/api/sample" ) );
        }

        public async Task<IEnumerable<Persons_By_Department_View>> GetSamples(Uri uri)
        {
            using ( var client = new HttpClient() )
            {
                HttpResponseMessage response = null;

                try
                {
                    response = await client.GetAsync( uri ).ConfigureAwait(false);
                }
                catch ( Exception _error )
                {
                    log.Error( _error );
                }

                if ( response.IsSuccessStatusCode )
                {
                    string result = await response.Content.ReadAsStringAsync();

                    var rootResult = JsonConvert.DeserializeObject<List<Persons_By_Department_View>>( result );

                    return rootResult;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
