using MahApps.Metro;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ProjetWPF
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        
        protected override void OnStartup(StartupEventArgs e)
        {
            int theme=IOData.LireDonnesTheme();
            ThemeManager.AddAccent("AccentL", new Uri("pack://application:,,,/ProjetWPF;component/Theme/Accent1.xaml"));
            ThemeManager.AddAppTheme("ThemeL", new Uri("pack://application:,,,/ProjetWPF;component/Theme/LightTheme.xaml"));
            ThemeManager.AddAccent("AccentD", new Uri("pack://application:,,,/ProjetWPF;component/Theme/Accent2.xaml"));
            ThemeManager.AddAppTheme("ThemeD", new Uri("pack://application:,,,/ProjetWPF;component/Theme/DarkTheme.xaml"));
            if (theme < 2)
            {
                ThemeManager.ChangeAppStyle(Application.Current,ThemeManager.GetAccent("AccentL"), ThemeManager.GetAppTheme("ThemeL"));
            }
            else
            {
                ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent("AccentD"), ThemeManager.GetAppTheme("ThemeD"));

            }
            base.OnStartup(e);

        }
    }
}
