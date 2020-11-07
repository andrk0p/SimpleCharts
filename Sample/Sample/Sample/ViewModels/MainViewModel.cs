using Sample.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Sample.ViewModels
{
    public class MainViewModel
    {
        public ICommand ChangeCommand => new Command(() => UpdateChart());
        public double MaxHeight => 300;
        public ObservableCollection<Chart> Charts { get; set; } = new ObservableCollection<Chart>();
        public MainViewModel()
        {
            var i = 0;
            while (i < 29)
            {
                var a = new Chart() { Value = new Random().Next(0, 500) };
                Charts.Add(a);
                i++;
            }
            UpdateChart();
        }
        private void UpdateChart()
        {
            foreach (var a in Charts)
            {
                a.Value = new Random().Next(0, 500);
                a?.Update();
            }
        }
    }
}
