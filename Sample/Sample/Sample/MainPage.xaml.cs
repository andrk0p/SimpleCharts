using Sample.Models;
using Sample.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Sample
{
    public partial class MainPage : ContentPage
    {
        private MainViewModel mainViewModel;
        public MainPage()
        {
            BindingContext = mainViewModel = new MainViewModel();
            mainViewModel.Notify += Update;
            InitializeComponent();
        }

        public void Update(Chart chart)
        {
        }
    }
}
