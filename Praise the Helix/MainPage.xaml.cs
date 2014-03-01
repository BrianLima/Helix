using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Praise_the_Helix.Resources;
using System.Windows.Media.Imaging;
using Microsoft.Phone.Tasks;
using Windows.UI;
using System.Windows.Media;

namespace Praise_the_Helix
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            lordsWord.Text = "Tap the button on the AppBar to hear our Lord and Savior Word";
            lordsImage.Source = new BitmapImage(new Uri("Images/Omanyte.png", UriKind.Relative));
            
            // Sample code to localize the ApplicationBar
            BuildLocalizedApplicationBar();
        }

        // Sample code for building a localized ApplicationBar
        private void BuildLocalizedApplicationBar()
        {
            // Set the page's ApplicationBar to a new instance of ApplicationBar.
            ApplicationBar = new ApplicationBar();

            // Create a new button and set the text value to the localized string from AppResources.
            ApplicationBarIconButton appBarButtonHear = new ApplicationBarIconButton(new Uri("/Images/QuestionMark.png", UriKind.Relative));
            appBarButtonHear.Text = "Hear";
            appBarButtonHear.Click += appBarButton_Click;
            ApplicationBar.Buttons.Add(appBarButtonHear);

            ApplicationBarIconButton appBarButtonShare = new ApplicationBarIconButton(new Uri("/Images/share.png", UriKind.Relative));
            appBarButtonShare.Text = "Share";
            appBarButtonShare.Click += appBarButtonShare_Click;
            ApplicationBar.Buttons.Add(appBarButtonShare);

            ApplicationBarIconButton appBarButtonReview = new ApplicationBarIconButton(new Uri("/Images/favs.png", UriKind.Relative));
            appBarButtonReview.Text = "Review";
            appBarButtonReview.Click += appBarButtonReview_Click;
            ApplicationBar.Buttons.Add(appBarButtonReview);

            // Create a new menu item with the localized string from AppResources.
            ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
            appBarMenuItem.Text = "About";
            appBarMenuItem.Click += appBarMenuItem_Click; 
            ApplicationBar.MenuItems.Add(appBarMenuItem);
        }

        void appBarMenuItem_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/About.xaml", UriKind.Relative));
        }

        void TileUpdate()
        {
            ShellTile tile = ShellTile.ActiveTiles.FirstOrDefault();
            StandardTileData standardData = new StandardTileData
            {
                BackContent = lordsWord.Text,
                BackTitle = "༼ つ ◕_◕ ༽つ",
                BackgroundImage = new Uri("/Assets/ApplicationIcon.png", UriKind.Relative),
                Title = "Praise the Helix"
            };
            tile.Update(standardData);
        }

        void appBarButtonReview_Click(object sender, EventArgs e)
        {
            MarketplaceReviewTask task = new MarketplaceReviewTask();
            task.Show();
        }

        void appBarButtonShare_Click(object sender, EventArgs e)
        {
            ShareStatusTask shareOurLordWord = new ShareStatusTask();
            shareOurLordWord.Status = "Our Lord and Savior Omanyte said: " + lordsWord.Text;
            shareOurLordWord.Show();
        }

        void appBarButton_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            int phrase = rand.Next(11);
            LordsWords LordsWords = new LordsWords();
            lordsWord.Text = LordsWords.HearOurLord(phrase);
            TileUpdate();
        }

        private void lordsImage_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            lordsWord.Text = "DON'T DARE TOUCHING ME!";
        }
    }
}