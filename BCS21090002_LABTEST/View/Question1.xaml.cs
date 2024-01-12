using System.Globalization;
using System;

using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace BCS21090002_LABTEST.View;

public partial class Question1 : ContentPage
{

    public Question1()
    {
        InitializeComponent();
        slider1.ValueChanged += OnSliderValueChanged;
        // Call once to set initial state
        UpdateSliderVisualState(slider1.Value);
    }
    private void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
    {
        UpdateSliderVisualState(e.NewValue);
    }

    private void UpdateSliderVisualState(double value)
    {
        label1.Text = $"{(int)value}";

        if (value >= 0 && value <= 39)
        {
            label2.Text = "Failed";
            label2.TextColor = Colors.Red;
            // Custom renderer logic to change the slider bar color to blue on the left, red on the right
        }
        else if (value >= 40 && value <= 79)
        {
            label2.Text = "Passed";
            label2.TextColor = Colors.Black;
        }
        else if (value >= 80 && value <= 100)
        {
            label2.Text = "Excellent";
            label2.TextColor = Colors.Green;
        }
    }
}
