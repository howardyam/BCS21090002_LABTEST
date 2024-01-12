using BCS21090002_LABTEST.Model;
using BCS21090002_LABTEST.ViewModel;
namespace BCS21090002_LABTEST.View;

public partial class Question3 : ContentPage
{
	public Question3()
	{
		InitializeComponent();
        BindingContext = new Question3ViewModel();
    }
}