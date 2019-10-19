using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using ProjetWPF.Fenetres.UserControls;
using System.Windows;

namespace ProjetWPF.Fenetres
{
    /// <summary>
    /// Logique d'interaction pour Administration.xaml
    /// </summary>
    public partial class Administration : MetroContentControl
    {
        public Administration()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Erreur.Visibility = Visibility.Hidden;
            if (IOData.Autintification(OldPass.Password))
            {
               
                if (Pass.Password == Pass2.Password)
                {
                    if (Pass.Password != "")
                    {
                        IOData.EcrireMotDePasse(Pass.Password);
                        MessageBoxAlert.Show("Mot de passe modifier", "Votre mot de passe a été modifier");
                        Pass.Password = "";
                        Pass2.Password = "";
                        OldPass.Password = "";
                    }
                    else
                    {
                        Erreur.Content = "Vous devez entrer un nouveau mot de passe.";
                        Erreur.Visibility = Visibility.Visible;
                    }
                }
                else
                {
                    if (Pass2.Password != "")
                    {
                        Erreur.Content = "Le mot de passe et la confirmation ne sont pas identiques";
                        Erreur.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        Erreur.Content = "Confirmer votre mot de passe";
                        Erreur.Visibility = Visibility.Visible;
                    }
                    
                }
            }
            else
            {
                if(OldPass.Password!="")
                {
                    Erreur.Content = "Mot de passe incorrect";
                    Erreur.Visibility = Visibility.Visible;
                }
                else
                {
                    Erreur.Content = "Vous devez entrer l'ancien mot de passe.";
                    Erreur.Visibility = Visibility.Visible;
                }
                
            }            
        }      
    }
}