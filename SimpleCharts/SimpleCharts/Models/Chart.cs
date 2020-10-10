using System.ComponentModel;
using Xamarin.Forms;

namespace SimpleCharts.Models
{
    public class Chart : BaseItemModel, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public double? Value { get; set; }
        public double? Height { get; set; }
        public Color BackgroundColor => Value < 400 ? Color.Red : Color.GreenYellow;

        public void Update()
        {
            PropertyChanged?.Invoke(Value, new PropertyChangedEventArgs(nameof(Value)));
            PropertyChanged?.Invoke(Height, new PropertyChangedEventArgs(nameof(Height)));
            PropertyChanged?.Invoke(BackgroundColor, new PropertyChangedEventArgs(nameof(BackgroundColor)));
        }
    }
}
