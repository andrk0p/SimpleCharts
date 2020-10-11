using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpleCharts.Templates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChartTemplate : Grid
    {
        public static readonly BindableProperty ColumnSizeProperty =
        BindableProperty.Create("ColumnSize", typeof(double), typeof(ChartTemplate), 0.0d, 
            BindingMode.TwoWay, propertyChanged: ColumnSizeChanging);
        public double ColumnSize
        {
            set
            {
                SetValue(ColumnSizeProperty, value);
                SetColumn(value);
            }
            get
            {
                return (double)GetValue(ColumnSizeProperty);
            }
        }
        public ChartTemplate()
        {
            InitializeComponent();
        }
        private static void ColumnSizeChanging(BindableObject bindable, object oldValue, object newValue)
        {
            var ctrl = (ChartTemplate)bindable;
            ctrl.ColumnSize = (double)newValue;
        }
        private async void SetColumn(double value)
        {
            double height = ChartColumn.HeightRequest;
            while (height != value)
            {
                height = height < value ? ++height : --height;
                ChartColumn.HeightRequest = height;
                await Task.Delay(10);
            }
            //ChartColumn.LayoutTo(new Rectangle(0, value, ChartColumn.Width, ChartColumn.Height),
            //    2000, new Easing(t => 1 - Math.Cos(10 * Math.PI * t) * Math.Exp(-5 * t)));
        }
    }
}