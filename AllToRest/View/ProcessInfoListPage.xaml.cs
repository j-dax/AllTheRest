using Android.Content.PM;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AllToRest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProcessInfoListPage : ContentPage
    {
        public ProcessInfoListPage()
        {
            InitializeComponent();
        }

        public void ToolbarItem_Refresh(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new ProcessInfoDetailPage());
            return;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new ProcessInfoDetailPage((ApplicationInfo)e.SelectedItem));
        }
    }
}