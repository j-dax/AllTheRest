using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Android.App;
using Android.Content;

namespace AllToRest.Service
{
    public class RunningProcessService
    {
        public ObservableCollection<ActivityManager.RunningAppProcessInfo> ProcessInfoList { get; set; }
        public RunningProcessService()
        {
            ProcessInfoList = new ObservableCollection<ActivityManager.RunningAppProcessInfo>();

            InitializeAppInfo();
        }

        public void InitializeAppInfo()
        {
            ProcessInfoList.Clear();
            var context = Android.App.Application.Context;
            var runningApps = ((ActivityManager)context.GetSystemService(Context.ActivityService)).RunningAppProcesses;
            foreach (ActivityManager.RunningAppProcessInfo appInfo in runningApps)
            {
                ProcessInfoList.Add(appInfo);
            }
        }

        public async Task<ObservableCollection<ActivityManager.RunningAppProcessInfo>> GetProcessInfoAsync(string query)
        {
            InitializeAppInfo();
            if (query != string.Empty)
            {
                List<ActivityManager.RunningAppProcessInfo> procList = ProcessInfoList.Where(
                    proc => proc.ProcessName.ToLower().Contains(query.ToLower()))
                    .ToList();

                ProcessInfoList.Clear();
                foreach (var procInfo in procList)
                {
                    ProcessInfoList.Add(procInfo);
                }
            }
            return await Task.FromResult(ProcessInfoList);
        }

        /*

        

        */
    }
}
