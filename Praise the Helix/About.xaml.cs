using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media.Imaging;
using Microsoft.Phone.Tasks;
using System.Diagnostics;
using Microsoft.Advertising.Mobile.UI;
using System.Device.Location;

namespace Praise_the_Helix
{
    public partial class About : PhoneApplicationPage, IDisposable
    {
        //Geographical position tracker for geoposition based ads
        private GeoCoordinateWatcher gcw = null;
        public About()
        {
            InitializeComponent();
            avatar.Source = new BitmapImage(new Uri("/Images/briano.png", UriKind.Relative));
            //Initiating the GeoCordinater and assigning it's handlers
            this.gcw = new GeoCoordinateWatcher();
            this.gcw.PositionChanged += new EventHandler<GeoPositionChangedEventArgs<GeoCoordinate>>(gcw_PositionChanged);
            this.gcw.Start();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //WebBrowserTask used to open IE and send to a pre-determinated webpage
            WebBrowserTask follow = new WebBrowserTask();
            follow.Uri = new Uri("https://m.twitter.com/BrianoStorm", UriKind.Absolute);
            follow.Show();
        }

        private void RedditTPP_Click(object sender, RoutedEventArgs e)
        {
            WebBrowserTask follow = new WebBrowserTask();
            follow.Uri = new Uri("http://www.reddit.com/r/twitchplayspokemon/", UriKind.Absolute);
            follow.Show();
        }

        private void gcw_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            // Stop the GeoCoordinateWatcher now that we have the device location.
            this.gcw.Stop();

            adControl1.Latitude = e.Position.Location.Latitude;
            adControl1.Longitude = e.Position.Location.Longitude;

            Debug.WriteLine("Device lat/long: " + e.Position.Location.Latitude + ", " + e.Position.Location.Longitude);
        }

        private void adControl1_ErrorOccurred(object sender, Microsoft.Advertising.AdErrorEventArgs e)
        {
            Debug.WriteLine("AdControl error: " + e.Error.Message);
        }


        private void AdControl_AdRefreshed(object sender, EventArgs e)
        {
            Debug.WriteLine("AdControl new ad received");
        }

        #region IDisposable Members

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.gcw != null)
                {
                    this.gcw.Dispose();
                    this.gcw = null;
                }
            }
        }

        #endregion
    }
}