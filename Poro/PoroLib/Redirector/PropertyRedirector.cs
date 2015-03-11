using PoroLib.Redirector.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace PoroLib.Redirector
{
    public class PropertyRedirector
    {
        public event PatcherFoundHandler PatcherFound;
        public delegate void PatcherFoundHandler();

        private FileSystemWatcher _watcher;
        private DateTime _lastWrite;
        private PoroServerSettings _settings;

        //
        // PropertyRedirector
        // The property redirector modifies the lol.properties on the fly by watching for a patcher launch.
        // The patcher writes the lol.properties file on launch each time so by modifying it AFTER the patcher launches.
        // We can use our own custom lol.properties to connect to our RTMPS server without actually making the user go through
        // modifying it manually. The file gets rewritten on each launch so this modification is only temporary.
        //

        public PropertyRedirector(PoroServerSettings settings)
        {
            _settings = settings;

            _lastWrite = DateTime.MinValue;

            _watcher = new FileSystemWatcher();
            _watcher.Path = _settings.LeagueDrive;
            _watcher.Filter = "lol.properties";
            _watcher.IncludeSubdirectories = true;
            _watcher.NotifyFilter = NotifyFilters.LastWrite;

            _watcher.Changed += new FileSystemEventHandler(OnChanged);
            _watcher.EnableRaisingEvents = true;
        }

        private void OnChanged(object source, FileSystemEventArgs e)
        {
            //Only override if it's lol_air_client (this allows patching while Poro is running)
            if (!e.FullPath.Contains("lol_air_client"))
                return;

            var diffInSeconds = (DateTime.Now - _lastWrite).TotalSeconds;

            //Only overwrite once every 5 seconds. This stops Poro from detecting itself and going into an infinite loop
            if (diffInSeconds < 5)
                return;

            Console.WriteLine(string.Format("[LOG] LoLPatcher detected, server redirected to {0}", _settings.RTMPSHost));

            //Generate the properties according to the current client's IP address
            PoroProperties properties = new PoroProperties();
            properties.host = _settings.RTMPSHost;

            BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Instance;
            PropertyInfo[] members = typeof(PoroProperties).GetProperties(bindingFlags).ToArray();
            List<string> modifiedProperties = new List<string>();
            foreach (var x in members)
            {
                modifiedProperties.Add(string.Format("{0}={1}", x.Name, x.GetValue(properties)));
            }

            //Wait for the file to be writeable
            FileStream fileWait = WaitForFile(e.FullPath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            fileWait.Close();

            //Set the last write time of the properties to now
            _lastWrite = DateTime.Now;

            //Override property file
            File.Delete(e.FullPath);
            File.WriteAllLines(e.FullPath, modifiedProperties.ToArray());

            PoroServer.ClientLocation = e.FullPath.Replace("lol.properties", "");

            if (PatcherFound != null)
                PatcherFound();
        }

        private FileStream WaitForFile(string fullPath, FileMode mode, FileAccess access, FileShare share)
        {
            for (int numTries = 0; numTries < 10; numTries++)
            {
                try
                {
                    FileStream fs = new FileStream(fullPath, mode, access, share);

                    fs.ReadByte();
                    fs.Seek(0, SeekOrigin.Begin);

                    return fs;
                }
                catch (IOException)
                {
                    Thread.Sleep(50);
                }
            }

            return null;
        }
    }
}
