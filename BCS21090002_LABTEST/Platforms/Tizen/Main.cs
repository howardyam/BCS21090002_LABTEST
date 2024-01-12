using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using System;

namespace BCS21090002_LABTEST
{
    internal class Program : MauiApplication
    {
        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}