using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalsProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabPage1 : ContentPage
    {
        private int count = 0;
        public TabPage1()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            count++;
            lblClick.Text = "You clicked " + count.ToString() + " times.";
        }
    }
}