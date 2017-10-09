using SQLiteNullableDateTimeIssue.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SQLiteNullableDateTimeIssue
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        #region Fields

        private Steps _currentStep = Steps.CreateDog;
        private int _createdDogId;

        #endregion

        #region Constructors

        public MainPage()
        {
            this.InitializeComponent();
        }

        #endregion

        #region UI Events

        private void btnNextStep_Click(object sender, RoutedEventArgs e)
        {
            switch (_currentStep)
            {
                case Steps.CreateDog:
                    if (!string.IsNullOrEmpty(txtDogName.Text))
                    {
                        txtDogName.IsEnabled = false;
                        var createdDog = new Dog() { Name = txtDogName.Text };
                        DataAccessService.Instance.AddDog(createdDog);
                        _createdDogId = createdDog.Id;

                        runDogCreationResult.Text = "OK!";
                        tbDogCreationResult.Visibility = Visibility.Visible;
                        spGetYourDog.Visibility = Visibility.Visible;
                        _currentStep = Steps.GettingDog;
                    }
                    else
                    {
                        ShowMessage("Please enter your dog name");
                    }
                    break;
                case Steps.GetDog:
                    spSetBirthDate.Visibility = Visibility.Visible;
                    _currentStep = Steps.UpdateDog;
                    break;
                case Steps.UpdateDog:
                    if (dpDogBirthDate.Date != null)
                    {
                        dpDogBirthDate.IsEnabled = false;
                        var actualDog = DataAccessService.Instance.GetDog(_createdDogId);
                        actualDog.Birthdate = dpDogBirthDate.Date.Date;
                        DataAccessService.Instance.UpdateDog(actualDog);

                        runDogUpdateResult.Text = "OK!";
                        tbDogUpdateResult.Visibility = Visibility.Visible;
                        spGetYourDog2.Visibility = Visibility.Visible;
                        _currentStep = Steps.GettingDog2;
                    }
                    else
                    {
                        ShowMessage("Please select your dog birth date");
                    }
                    break;
                default:
                    break;
            }
        }

        private void btnGetYourDog_Click(object sender, RoutedEventArgs e)
        {
            var recoveredDog = DataAccessService.Instance.GetDog(_createdDogId);

            runGetYourDogResult.Text = recoveredDog.ToString();
            tbGetYourDogResult.Visibility = Visibility.Visible;

            _currentStep = Steps.GetDog;
        }

        private void btnGetYourUpdatedDog_Click(object sender, RoutedEventArgs e)
        {
            var recoveredDog2 = DataAccessService.Instance.GetDog(_createdDogId);

            runGetYourDog2Result.Text = recoveredDog2.ToString();
            tbGetYourDog2Result.Visibility = Visibility.Visible;

            btnNextStep.Visibility = Visibility.Collapsed;
            btnTryAgain.Visibility = Visibility.Visible;
        }

        private void btnTryAgain_Click(object sender, RoutedEventArgs e)
        {
            _currentStep = Steps.CreateDog;
            _createdDogId = 0;

            txtDogName.Text = string.Empty;
            txtDogName.IsEnabled = true;

            tbDogCreationResult.Visibility = Visibility.Collapsed;
            spGetYourDog.Visibility = Visibility.Collapsed;

            tbGetYourDogResult.Visibility = Visibility.Collapsed;
            spSetBirthDate.Visibility = Visibility.Collapsed;

            tbDogUpdateResult.Visibility = Visibility.Collapsed;
            spGetYourDog2.Visibility = Visibility.Collapsed;
            dpDogBirthDate.IsEnabled = true;

            tbGetYourDog2Result.Visibility = Visibility.Collapsed;
            btnNextStep.Visibility = Visibility.Visible;
            btnTryAgain.Visibility = Visibility.Collapsed;
        }

        #endregion

        #region Private methods

        private async void ShowMessage(string message)
        {
            var dialog = new MessageDialog(message);
            await dialog.ShowAsync();
        }

        #endregion
    }

    enum Steps
    {
        CreateDog,
        GettingDog,
        GetDog,
        UpdateDog,
        GettingDog2
    }
}
