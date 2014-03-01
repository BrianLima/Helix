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
        public static String word1 = "Up";
        public static String word2 = "Down";
        public static String word3 = "Left";
        public static String word4 = "Right";
        public static String word5 = "a";
        public static String word6 = "b";
        public static String word7 = "Start";
        public static String word8 = "Select";
        public static String word9 = "NOW";
        public static String word10 = "Don't count on that";
        public static String word11 = "NO!";
        public static String word12 = "Democracy!";
        public static String word13 = "Anarchy!";
        public static String word14 = "Use Surf";
        public static String word15 = "My sources says: NO";
        public static String word16 = "Don't forget those who died for us";
        public static String word17 = "February 23, never forget";

        public String HearOurLord(int i)
            {
                if (i == 0)
                {
                    return word1;
                }
                else if (i == 1) { return word2; }
                else if (i == 2) { return word3; }
                else if (i == 3) { return word4; }
                else if (i == 4) { return word5; }
                else if (i == 5) { return word6; }
                else if (i == 6) { return word7; }
                else if (i == 7) { return word8; }
                else if (i == 8) { return word9; }
                else if (i == 9) { return word10; }
                else if (i == 10) { return word11; }
                else if (i == 11) { return word12; }
                else if (i == 12) { return word13; }
                else if (i == 13) { return word14; }
                else if (i == 14) { return word15; }
                else if (i == 15) { return word16; }
                else if (i == 16) { return word17; }
                else
                {
                    return "Not in the mood";
                }
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
            if (image == 0)
            {
                return "/Images/gods.jpg";
            }
            else if (image == 1)
            {
                return "/Images/gods2.jpg";
            }
            else if (image == 2)
            {
                return "/Images/Whenever.jpg";
            }
            else
            {
                return "/Images/zapdos.jpg";
            }
        }
    }
}
