using SimpleCharts.Models;
using SimpleCharts.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace SimpleCharts
{
    public partial class MainPage : ContentPage
    {
        private MainViewModel mainViewModel;
        public MainPage()
        {
            InitializeComponent();
            BindingContext = mainViewModel = new MainViewModel();
            mainViewModel.Notify += Update;
        }
        
        public void Update(Chart chart)
        {
            
        }

        private async void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            if (sender is Grid grid)
                if(grid.Children.FirstOrDefault() is BoxView boxview)
                    boxview.LayoutTo(new Rectangle(0, boxview.Height-50, boxview.Width, boxview.Height+50), 2000, new Easing(t => 1 - Math.Cos(10 * Math.PI * t) * Math.Exp(-5 * t)));
            
        }
    }
}
