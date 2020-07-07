using Android.App;
using Android.Content;
using Android.Content.PM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllToRest
{
    class InstalledService
    {

        public ObservableCollection<ApplicationInfo> InstalledInfoList { get; set; }
        public InstalledService()
        {
            InstalledInfoList = new ObservableCollection<ApplicationInfo>();

            InitializeAppInfo();
        }

        public void InitializeAppInfo()
        {
            var pkgMgr = Android.App.Application.Context.PackageManager;
            PackageInfoFlags flags = PackageInfoFlags.MatchAll;

            InstalledInfoList.Clear();
            foreach (var pkg in pkgMgr.GetInstalledApplications(flags))
            {
                InstalledInfoList.Add(pkg);
            }
        }

        public async Task<ObservableCollection<ApplicationInfo>> GetApplicationInfoAsync(string query)
        {
            InitializeAppInfo();

            if (query != string.Empty)
            {
                List<ApplicationInfo> applicationInfoList = InstalledInfoList.Where(
                    app => app.ProcessName.ToLower().Contains(query.ToLower())
                    ).ToList();

                InstalledInfoList.Clear();
                foreach (var app in applicationInfoList)
                {
                    InstalledInfoList.Add(app);
                    Console.WriteLine();
                    foreach (string s in app.SplitNames)
                    {
                        Console.Write(s + ", ");
                    }
                    Console.WriteLine(app.SplitNames);
                    Console.WriteLine(app.ClassName);
                    Console.WriteLine(app.PackageName);
                    string s = app.NonLocalizedLabel.ToString()
                    Console.WriteLine();
                }
            }

            return await Task.FromResult(InstalledInfoList);
        }
    }
}
