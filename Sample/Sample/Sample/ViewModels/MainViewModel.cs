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
        public ICommand ChangeCommand => new Command(async () => UpdateChart());
        public double MaxHeight => 300;
        public ObservableCollection<Chart> Charts { get; set; } = new ObservableCollection<Chart>();
        public MainViewModel()
        {
            var i = 0;
            while (i < 8)
            {
                Charts.Add(new Chart() { Value = new Random().Next(0, 1000) });
                i++;
            }
        }
        private void UpdateChart()
        {
            foreach (var a in Charts)
            {
                a.Value = new Random().Next(0, 1000);
                a?.Update();
            }
        }
    }
}
