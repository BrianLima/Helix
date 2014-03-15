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
using Windows.Phone.Speech.Synthesis;

namespace Praise_the_Helix
{
    public partial class MainPage : PhoneApplicationPage
    {
        //For the easter egg
        int eggCount = 0;
        //SpeechSynthesizer is the common TTS control for WP
        SpeechSynthesizer talk;

        // Constructor
        public MainPage()
        {
            InitializeComponent();
            //Replacing all the placeholders
            lordsWord.Text = "Tap the button on the AppBar to hear our Lord and Savior Word";
            lordsImage.Source = new BitmapImage(new Uri("Images/Omanyte.png", UriKind.Relative));
            
            //Code to localize the ApplicationBar
            BuildLocalizedApplicationBar();
            //Initializing the TTS Service
            this.talk = new SpeechSynthesizer();
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

            ApplicationBarIconButton appBarButtonSpeech = new ApplicationBarIconButton(new Uri("/Images/microphone.png", UriKind.Relative));
            appBarButtonSpeech.Text = "Speech";
            appBarButtonSpeech.Click += appBarButtonSpeech_Click;
            ApplicationBar.Buttons.Add(appBarButtonSpeech);

            // Create a new menu item with the localized string from AppResources.
            ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
            appBarMenuItem.Text = "About";
            appBarMenuItem.Click += appBarMenuItem_Click; 
            ApplicationBar.MenuItems.Add(appBarMenuItem);
        }

        private async void appBarButtonSpeech_Click(object sender, EventArgs e)
        {
            try
            {
                await talk.SpeakTextAsync(lordsWord.Text);
            }
            catch (Exception exception)
            {
                
                throw new Exception("Error when trying to use TTS", exception);
            }
        }

        void appBarMenuItem_Click(object sender, EventArgs e)
        {
            //Navigate trough pages in the app
            NavigationService.Navigate(new Uri("/About.xaml", UriKind.Relative));
        }

        void TileUpdate()
        {
            //Updating live tiles with actual word
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
            //Initialize a page where user can review the app
            MarketplaceReviewTask task = new MarketplaceReviewTask();
            task.Show();
        }

        void appBarButtonShare_Click(object sender, EventArgs e)
        {
            //Initialize a page where user can share Lords phrases
            ShareStatusTask shareOurLordWord = new ShareStatusTask();
            shareOurLordWord.Status = "Our Lord and Savior Omanyte said: " + lordsWord.Text;
            shareOurLordWord.Show();
        }

        void appBarButton_Click(object sender, EventArgs e)
        {
            //Ramdomize the displayed phrase
            LordsWords LordsWords = new LordsWords(); 
            Random rand = new Random();
            int phrase = rand.Next(LordsWords.words.Length);
            lordsWord.Text = LordsWords.HearOurLord(phrase);
            TileUpdate();
        }

        private void lordsImage_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            //Handling the Eastter Egg
            lordsWord.Text = "DON'T DARE TOUCHING ME!";
            eggCount += 1;
            if (eggCount == 50)
            {
                Random rand = new Random();
                int image = rand.Next(0, 3);
                egg.Visibility = System.Windows.Visibility.Visible;
                lordsWord.Visibility = System.Windows.Visibility.Collapsed;
                LordsWords LordsWords = new LordsWords();
                egg.Source = new BitmapImage(new Uri(LordsWords.EasterEgg(image),UriKind.Relative));
            }
        }

        private void egg_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            //Getting rid of the Easter Egg and returning to previous state
            egg.Visibility = System.Windows.Visibility.Collapsed;
            lordsWord.Visibility = System.Windows.Visibility.Visible;
            egg.Source = null;
            eggCount = 0;
        }
    }
}