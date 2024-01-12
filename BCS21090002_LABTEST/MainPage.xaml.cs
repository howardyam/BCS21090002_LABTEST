using BCS21090002_LABTEST.View;
namespace BCS21090002_LABTEST
{
    public partial class MainPage : ContentPage
    {
      
        public MainPage()
        {
            InitializeComponent();
        }

        private void Question1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Question1());    // Quickreport in original.
        }

        private void Question2(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Question2());    // Quickreport in original.
        }

        private void Question3(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Question3());    // Quickreport in original.
        }
    }
}