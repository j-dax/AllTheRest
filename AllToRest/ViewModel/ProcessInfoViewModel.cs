using Android.Content.PM;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AllToRest
{
    class ProcessInfoViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ApplicationInfo _processInfo;
        public ApplicationInfo ProcessInfo
        {
            get { return _processInfo; }
            set { _processInfo = value; OnPropertyChanged(); }
        }
    }
}
