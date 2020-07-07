using AllToRest.Service;
using Android.App;
using Android.Content.PM;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AllToRest
{
    class ProcessInfoListViewModel : INotifyPropertyChanged
    {
        InstalledService installedService;

        public ICommand searchCommand => new Command<string>(FilterInstalledApplications);

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<ApplicationInfo> _runningProcesses;
        public ObservableCollection<ApplicationInfo> RunningProcesses
        {
            get { return _runningProcesses; }
            set { _runningProcesses = value; OnPropertyChanged(); }
        }

        public string ProcessName { get; set; }
        public string Name { get; set; }
        public int Logo { get; set; }

        public string SelectedProcess { get; set; }

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { _isBusy = value; OnPropertyChanged(); }
        }

        public ProcessInfoListViewModel()
        {
            installedService = new InstalledService();
            LoadProcesses(string.Empty);

            //MessagingCenter.Subscribe<ViewInstalledDetailPage, ActivityManager.RunningAppProcessInfo>(this, "ViewInstalledInfo",
            //    (page, appInfo) =>
            //    {
            //        // TODO: register event type? maybe leave to that page to handle
            //    });
        }

        public void LoadProcesses(string query)
        {
            IsBusy = true;
            Task.Run(async () =>
            {
                RunningProcesses = await installedService.GetApplicationInfoAsync(query);
                IsBusy = false;
            });
        } 

        public void FilterInstalledApplications(string query)
        {
            IsBusy = true;
            Task.Run(async () =>
            {
                RunningProcesses = await installedService.GetApplicationInfoAsync(query);
                IsBusy = false;
            });
        }
    }
}
