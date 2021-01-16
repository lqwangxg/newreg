using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Wxg.IO
{
    public class FileWatcher : FileSystemWatcher
    {
        private NotifyFilters defaultNotifyFilter;
        private string defaultFilter;
        public FileWatcher()
        {
            this.Path = Wxg.Utils.Xmler.GetAppSettingValue("path");
            Init();
        }
        public FileWatcher(string path)
            : base(path)
        {
            Init();
        }

        public FileWatcher(string path,string filter)
            : base(path, filter)
        {
            Init();
        }
        
        private void Init()
        {
            defaultNotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                                     | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            defaultFilter = Wxg.Utils.Xmler.GetAppSettingValue("filter", "*.*");
            // Add event handlers.
            this.Changed += new FileSystemEventHandler(OnChanged);
            this.Created += new FileSystemEventHandler(OnChanged);
            this.Deleted += new FileSystemEventHandler(OnChanged);
            this.Renamed += new RenamedEventHandler(OnRenamed);
        }

        /// <summary>
        /// Begin watching.
        /// </summary>
        public void Start()
        {
            if (string.IsNullOrEmpty(this.Filter))
            {
                this.Filter = this.defaultFilter;
            }

            if (this.NotifyFilter == 0)
            {
                this.NotifyFilter = this.defaultNotifyFilter;
            }
            
            if (this.CanRaiseEvents)
            {
                this.EnableRaisingEvents = true;
            }
        }
        /// <summary>
        /// Stop watching.
        /// </summary>
        public void Stop()
        {
            this.EnableRaisingEvents = false;
        }
        
        // Define the event handlers.
        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            // Specify what is done when a file is changed, created, or deleted.
            Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType);
        }

        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            // Specify what is done when a file is renamed.
            Console.WriteLine("File: {0} renamed to {1}", e.OldFullPath, e.FullPath);
        }
        
    }
}
