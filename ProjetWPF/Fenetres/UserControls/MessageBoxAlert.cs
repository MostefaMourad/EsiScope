using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjetWPF.Fenetres.UserControls
{
    static class MessageBoxAlert
    {
        public async static void Show(string Titre,string message)
        {
            var mainWindow = (Application.Current.MainWindow as MetroWindow);
            await mainWindow.ShowMessageAsync(Titre,message);
        }        
    }
}
