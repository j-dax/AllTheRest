using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Android.App;
using Android.Content;

namespace AllToRest.Service
{
    public class InstalledService
    {
        public ObservableCollection<ActivityManager.RunningAppProcessInfo> ProcessInfos { get; set; }
        public InstalledService()
        {
            ProcessInfos = new ObservableCollection<ActivityManager.RunningAppProcessInfo>();

            InitializeAppInfo();
        }

        public void InitializeAppInfo()
        {
            ProcessInfos.Clear();
            var context = Android.App.Application.Context;
            var runningApps = ((ActivityManager)context.GetSystemService(Context.ActivityService)).RunningAppProcesses;
            foreach (ActivityManager.RunningAppProcessInfo appInfo in runningApps)
            {
                ProcessInfos.Add(appInfo);
            }
        }

        public async Task<ObservableCollection<ActivityManager.RunningAppProcessInfo>> GetProcessInfoAsync(string query)
        {
            InitializeAppInfo();
            if (query != string.Empty)
            {
                List<ActivityManager.RunningAppProcessInfo> procList = ProcessInfos.Where(
                    proc => proc.ProcessName.ToLower().Contains(query.ToLower()))
                    .ToList();

                ProcessInfos.Clear();
                foreach (var procInfo in procList)
                {
                    ProcessInfos.Add(procInfo);
                }
            }
            return await Task.FromResult(ProcessInfos);
        }

        /*
        public static ObservableCollection<string> getBackgroundProcesses(ActivityManager actMgr) 
        {
            ActivityManager.MemoryInfo memoryInfo = new ActivityManager.MemoryInfo();
            actMgr.GetMemoryInfo(memoryInfo);

            ObservableCollection<string> processNames = new ObservableCollection<string>();

            foreach (var proc in actMgr.RunningAppProcesses)
            {
                processNames.Add(proc.ProcessName);
            }

            return processNames;
        }

        public static ObservableCollection<string> getInstalledApplications(PackageManager pkgMgr)
        {
            PackageInfoFlags flags = PackageInfoFlags.MatchAll;

            ObservableCollection<string> installedNames = new ObservableCollection<string>();

            foreach (var pkg in pkgMgr.GetInstalledApplications(flags))
            {
                installedNames.Add(pkg.ProcessName);
            }

            return installedNames;
        }

        */
    }
}
