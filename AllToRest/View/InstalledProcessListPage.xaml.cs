using AllToRest.Service;
using Android.App;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AllToRest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InstalledProcessListPage : ContentPage
    {
        public InstalledProcessListPage()
        {
            InitializeComponent();
        }

        //public void ToolbarItem_Refresh(object sender, EventArgs e)
        //{
        //    Navigation.PushAsync(new ViewInstalledDetailPage());
        //}

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new ViewInstalledDetailPage((ActivityManager.RunningAppProcessInfo)e.SelectedItem)));
        }
    }
}