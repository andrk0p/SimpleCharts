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
    public class MainViewModel : INotifyPropertyChanged
    {
        public delegate void AccountHandler(Chart chart);
        public event AccountHandler Notify;
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand ChangeCommand => new Command(async () => await UpdateChart());
        public double MaxHeight => 300;
        public ObservableCollection<Chart> Charts { get; set; } = new ObservableCollection<Chart>();
        public MainViewModel()
        {
            var i = 0;
            while (i < 20)
            {
                Charts.Add(new Chart() { Value = new Random().Next(0, 1000) });
                i++;
            }
            foreach (var a in Charts)
                a.Height = a?.Value == 0 ? 0 : Math.Round((a.Value * 100 / MaxHeight), 0);
        }
        private async Task UpdateChart()
        {
            foreach (var a in Charts)
            {
                Notify?.Invoke(a);
                a.Value = new Random().Next(0, 1000);
                a.Height = a?.Value == 0 ? 0 : Math.Round((a.Value * 100 / MaxHeight), 0);
                await Task.Delay(500);
                a?.Update();
            }
        }
    }
}
