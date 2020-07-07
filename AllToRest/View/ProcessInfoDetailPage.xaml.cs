using Android.App;
using Android.Content.PM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AllToRest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProcessInfoDetailPage : ContentPage
    {
        public ProcessInfoDetailPage(ApplicationInfo appInfo)
        {
            InitializeComponent();

            if (appInfo != null)
            {
                ((ProcessInfoViewModel)BindingContext).ProcessInfo = appInfo;
            }
        }
    }
}