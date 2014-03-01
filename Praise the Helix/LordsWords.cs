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
        public String word1 = "Up";
        public String word2 = "Down";
        public String word3 = "Left";
        public String word4 = "Right";
        public String word5 = "a";
        public String word6 = "b";
        public String word7 = "Start";
        public String word8 = "Select";
        public String word9 = "NOW";
        public String word10 = "Don't count on that";
        public String word11 = "NO!";

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
                else if (i == 9) { return word9; }
                else if (i == 10) { return word10; }
                else if (i == 11) { return word11; }
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
    }
}
