using Flurry.Analytics.Portable;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PortableClassLibrary
{
    public class SharedCode : INotifyPropertyChanged
    {
        public SharedCode(string key)
        {
            AnalyticsApi.ApiKey = key;
            AnalyticsApi.SetAppVersion("wp7");
            AnalyticsApi.SetUserId(Guid.NewGuid().ToString());

            isWorking = false;
        }

        public bool IsFlurrySupported
        {
            get { return AnalyticsApi.IsSupported; }
        }

        public string FlurryApiKey
        {
            get { return AnalyticsApi.ApiKey; }
        }

        public string FlurryVersion
        {
            get { return AnalyticsApi.ApiVersion; }
        }

        private bool isWorking;
        public bool IsWorking
        {
            get { return isWorking; }
            set { SetProperty(ref isWorking, value, "IsWorking"); }
        }

        public async Task DoLoadsOfWork(string taskName)
        {
            using (AnalyticsApi.LogTimedEvent(taskName))
            {
                IsWorking = true;
                await Task.Factory.Delay(3000);
                IsWorking = false;
            }
        }

        public ICommand DoWorkCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    await DoLoadsOfWork("WindowsPhone7LongTask");
                });
            }
        }

        protected void SetProperty<T>(ref T backingStore, T value, string property)
        {
            if (Equals(backingStore, value))
            {
                return;
            }

            backingStore = value;

            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(property));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
