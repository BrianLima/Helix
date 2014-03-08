using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Praise_the_Helix
{
    public class LordsWords
    {
        //Array containing all the possible phrases, special tanks to @victrgama
        public static String[] words = new String[] {
        	"Up",
        	"Down",
        	"Left",
        	"Right",
        	"a",
        	"b",
        	"Start",
        	"Select",
        	"NOW",
        	"Don't count on that",
        	"NO!",
        	"Anarchy!",
        	"Use Surf",
        	"My sources says: NO",
        	"Don't forget those who died for us",
        	"February 23, never forget",
            "LET THERE BE COLOR!",
            "Go to Pokecenter",
            "You've all been worshipping FALSE GODS",
            "Prepare for UNFORESEEN CONSEQUENCES",
            "2000",
            "How embarassing",
            "Pikachu",
            "How am i supposed to do that?",
            "Roger that",
            "I'm hungry, feed me, NOW!"
		};

        public String HearOurLord(int i)
        {
            //Return the desired Lord Word, thanks to @victrgama again
			String word = "Not in the mood";
			if(i < words.Length) word = words[i];
			return word;
        }

        //The following code handles how the app should work on either WP themes
        #region appTheme
        public enum AppTheme
        {
            Dark = 0,
            Light = 1
        }

        private static System.Windows.Media.Color lightThemeBackground = System.Windows.Media.Color.FromArgb(255, 255, 255, 255);
        private static System.Windows.Media.Color darkThemeBackgroud = System.Windows.Media.Color.FromArgb(255, 0, 0, 0);
        private static SolidColorBrush backgroundBrush;

        internal static AppTheme CurrentTheme
        {
            get
            {
                if (backgroundBrush == null)
                    backgroundBrush = Application.Current.Resources["PhoneBackgroundBrush"] as SolidColorBrush;

                if (backgroundBrush.Color == darkThemeBackgroud)
                    return AppTheme.Dark;
                if (backgroundBrush.Color == lightThemeBackground)
                    return AppTheme.Light;

                return AppTheme.Dark;
            }
        }
        #endregion

        internal static string EasterEgg(int image)
        {
            //Return the desired image for the easter egg, last time you are going to see @victrgama mentioned here
			String[] images = new String[] { 
				"/Images/gods.jpg",
				"/Images/gods2.jpg",
				"/Images/Whenever.jpg"
			};
			String result = "/Images/zapdos.jpg";
			if(image < images.Length) result = images[image];
			return result;
        }
    }
}
