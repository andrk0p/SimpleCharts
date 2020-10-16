using System.ComponentModel;
using Xamarin.Forms;

namespace Sample.Models
{
    public class Chart : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public double Value { get; set; }
        public Color MinColor => Color.Red;
        public Color MaxColor => Color.GreenYellow;
        public void Update()
        {
            PropertyChanged?.Invoke(Value, new PropertyChangedEventArgs(nameof(Value)));
        }
    }
}
