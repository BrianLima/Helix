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
        	"Democracy!",
        	"Anarchy!",
        	"Use Surf",
        	"My sources says: NO",
        	"Don't forget those who died for us",
        	"February 23, never forget"
		};

        public String HearOurLord(int i)
        {
			String word = "Not in the mood";
			if(i < words.Length) word = words[i];
			return word;
        }

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

        internal static string EasterEgg(int image)
        {
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
