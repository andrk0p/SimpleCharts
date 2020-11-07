using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpleCharts.Templates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Chart : Grid
    {
        public static readonly BindableProperty ValueProperty =
        BindableProperty.Create("Value", typeof(double), typeof(Chart), 0.0d, 
            BindingMode.TwoWay, propertyChanged: ValueChanging);
        public double Value
        {
            set
            {
                SetValue(ValueProperty, value);
                SetColumn(value);
            }
            get
            {
                return (double)GetValue(ValueProperty);
            }
        }
        private async void SetColumn(double value)
        {
            //ChartValue.IsVisible = IsLabelVisible;
            //ChartValue.Text = value.ToString();
            double changedValue = SetHeight(value);
            double height = ChartColumn.HeightRequest;
            while (height != changedValue)
            {
                await Task.Delay(20);
                if (IsAnimation)
                    height = height < changedValue ? ++height : --height;
                else
                    height = changedValue;
                ChartColumn.HeightRequest = height;
                if (IsMinAllowed)
                    ChartColumn.BackgroundColor = value < MinAllowedValue ? MinColor : MaxColor;
                else
                    ChartColumn.BackgroundColor = Color.GreenYellow;
            }
        }
        private double SetHeight(double value)
        {
            if (Parent is Charts charts)
                return value == 0 ? 0 : Math.Round((value * 100 / charts.HeightRequest), 0);
            else
                return 0.0d;
        }
        private static void ValueChanging(BindableObject bindable, object oldValue, object newValue)
        {
            var ctrl = (Chart)bindable;
            ctrl.Value = (double)newValue;
        }
        public static readonly BindableProperty MinColorProperty =
        BindableProperty.Create("MinColor", typeof(Color), typeof(Chart), Color.Red,
            BindingMode.TwoWay, propertyChanged: MinColorChanging);
        public Color MinColor
        {
            set
            {
                SetValue(MinColorProperty, value);
            }
            get
            {
                return (Color)GetValue(MinColorProperty);
            }
        }
        private static void MinColorChanging(BindableObject bindable, object oldValue, object newValue)
        {
            var ctrl = (Chart)bindable;
            ctrl.MinColor = (Color)newValue;
        }
        public static readonly BindableProperty MaxColorProperty =
        BindableProperty.Create("MaxColor", typeof(Color), typeof(Chart), Color.GreenYellow,
            BindingMode.TwoWay, propertyChanged: MaxColorChanging);
        public Color MaxColor
        {
            set
            {
                SetValue(MaxColorProperty, value);
            }
            get
            {
                return (Color)GetValue(MaxColorProperty);
            }
        }
        private static void MaxColorChanging(BindableObject bindable, object oldValue, object newValue)
        {
            var ctrl = (Chart)bindable;
            ctrl.MaxColor = (Color)newValue;
        }
        public static readonly BindableProperty MinAllowedValueProperty =
        BindableProperty.Create("MinAllowedValue", typeof(double), typeof(Chart), 0.0d,
            BindingMode.TwoWay, propertyChanged: MinAllowedValueChanging);
        public double MinAllowedValue
        {
            set
            {
                SetValue(MinAllowedValueProperty, value);
            }
            get
            {
                return (double)GetValue(MinAllowedValueProperty);
            }
        }
        private static void MinAllowedValueChanging(BindableObject bindable, object oldValue, object newValue)
        {
            var ctrl = (Chart)bindable;
            ctrl.MinAllowedValue = (double)newValue;
        }


        public static readonly BindableProperty IsAnimationProperty =
        BindableProperty.Create("IsAnimation", typeof(bool), typeof(Chart), true,
            BindingMode.TwoWay, propertyChanged: IsAnimationChanging);
        public bool IsAnimation
        {
            set
            {
                SetValue(IsAnimationProperty, value);
            }
            get
            {
                return (bool)GetValue(IsAnimationProperty);
            }
        }
        private static void IsAnimationChanging(BindableObject bindable, object oldValue, object newValue)
        {
            var ctrl = (Chart)bindable;
            ctrl.IsAnimation = (bool)newValue;
        }
        public static readonly BindableProperty IsMinAllowedProperty =
        BindableProperty.Create("IsMinAllowed", typeof(bool), typeof(Chart), true,
            BindingMode.TwoWay, propertyChanged: IsMinAllowedChanging);
        public bool IsMinAllowed
        {
            set
            {
                SetValue(IsMinAllowedProperty, value);
            }
            get
            {
                return (bool)GetValue(IsMinAllowedProperty);
            }
        }
        private static void IsMinAllowedChanging(BindableObject bindable, object oldValue, object newValue)
        {
            var ctrl = (Chart)bindable;
            ctrl.IsMinAllowed = (bool)newValue;
        }
        //public static readonly BindableProperty IsLabelVisibleProperty =
        //BindableProperty.Create("IsLabelVisible", typeof(bool), typeof(Chart), true,
        //    BindingMode.TwoWay, propertyChanged: IsLabelVisibleChanging);
        //public bool IsLabelVisible
        //{
        //    set
        //    {
        //        SetValue(IsLabelVisibleProperty, value);
        //    }
        //    get
        //    {
        //        return (bool)GetValue(IsLabelVisibleProperty);
        //    }
        //}
        //private static void IsLabelVisibleChanging(BindableObject bindable, object oldValue, object newValue)
        //{
        //    var ctrl = (Chart)bindable;
        //    ctrl.IsLabelVisible = (bool)newValue;
        //}
        
        public Chart()
        {
            InitializeComponent();
        }
    }
}