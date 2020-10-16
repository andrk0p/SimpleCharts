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
    public partial class Charts : StackLayout
    {
        public Charts()
        {
            InitializeComponent();
        }
    }
}