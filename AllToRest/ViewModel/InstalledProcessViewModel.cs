using AllToRest.Service;
using Android.App;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AllToRest
{
    class InstalledProcessListViewModel : INotifyPropertyChanged
    {
        InstalledService installedService;

        public ICommand searchCommand => new Command<string>(FilterInstalledApplications);

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName))
        }

        public ObservableCollection<ActivityManager.RunningAppProcessInfo> _runningProcesses;
        public ObservableCollection<ActivityManager.RunningAppProcessInfo> RunningProcesses
        {
            get { return _runningProcesses; }
            set { _runningProcesses = value; OnPropertyChanged(); }
        }

        public string ProcessName { get; set; }
        public string SelectedProcess { get; set; }

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { _isBusy = value; OnPropertyChanged(); }
        }

        public InstalledProcessListViewModel()
        {
            installedService = new InstalledService();

            //MessagingCenter.Subscribe<ViewInstalledDetailPage, ActivityManager.RunningAppProcessInfo>(this, "ViewInstalledInfo",
            //    (page, appInfo) =>
            //    {
            //        // TODO: register event type? maybe leave to that page to handle
            //    });
        }

        public void FilterInstalledApplications(string query)
        {
            IsBusy = true;
            Task.Run(async () =>
            {
                RunningProcesses = await installedService.GetProcessInfoAsync(query);
                IsBusy = false;
            });
        }
    }
}
