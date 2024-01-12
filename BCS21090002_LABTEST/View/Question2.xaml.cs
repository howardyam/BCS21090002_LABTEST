using System.Linq;
using Microsoft.Maui.Controls;

namespace BCS21090002_LABTEST.View
{
    public partial class Question2 : ContentPage
    {
        public Question2()
        {
            InitializeComponent();
            PhoneEntry.TextChanged += OnPhoneEntryTextChanged;
            PasswordEntry.TextChanged += OnPasswordEntryTextChanged;
            TermsAndConditionsCheckBox.CheckedChanged += OnTermsAndConditionsCheckBoxChanged;
        }

        private void OnPhoneEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            InvalidPhoneLabel.IsVisible = !IsValidPhoneNumber(PhoneEntry.Text);
        }
        private void OnPasswordEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            InvalidPasswordLabel.IsVisible = PasswordEntry.Text.Length < 6;
        }
        private void OnTermsAndConditionsCheckBoxChanged(object sender, CheckedChangedEventArgs e)
        {
           
            UpdateRegisterButtonState();
        }
        private bool IsValidPhoneNumber(string number)
        {
            
            return !string.IsNullOrWhiteSpace(number) && number.All(char.IsDigit) ;
        }
        private void UpdateRegisterButtonState()
        {
           
            bool isValidPhone = !string.IsNullOrWhiteSpace(PhoneEntry.Text) && PhoneEntry.Text.All(char.IsDigit);       
            bool isValidPassword = PasswordEntry.Text.Length >= 6;
            bool areTermsAccepted = TermsAndConditionsCheckBox.IsChecked;
            InvalidPhoneLabel.IsVisible = !isValidPhone;
            InvalidPasswordLabel.IsVisible = !isValidPassword;
            RegisterButton.IsEnabled = isValidPhone && isValidPassword && areTermsAccepted;
        }
    }
}
