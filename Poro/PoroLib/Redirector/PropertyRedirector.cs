using PoroLib.Redirector.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace PoroLib.Redirector
{
    public class PropertyRedirector
    {
        private FileSystemWatcher _watcher;
        private int _internalCounter;
        private PoroServerSettings _settings;

        //
        // PropertyRedirector
        // The property redirector modifies the lol.properties on the fly by watching for a patcher launch.
        // The patcher writes the lol.properties file on launch each time so by modifying it AFTER the patcher launches.
        // We can use our own custom lol.properties to connect to our RTMPS server without actually making the user go through
        // modifying it manually. The file gets rewritten on each launch so this modification is only temporary.
        //
        // Notes: The LoLPatcher does 3 writes to lol.properties. Just override the last one.
        //

        public PropertyRedirector(PoroServerSettings settings)
        {
            _settings = settings;

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

            _internalCounter += 1;

            if (_internalCounter == 3)
            {
                Console.WriteLine(string.Format("[LOG] LoLPatcher detected, server redirected to {0}", _settings.RTMPSHost));

                _internalCounter = 0;

                PoroProperties properties = new PoroProperties();
                properties.host = _settings.RTMPSHost;

                BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Instance;
                PropertyInfo[] members = typeof(PoroProperties).GetProperties(bindingFlags).ToArray();
                List<string> modifiedProperties = new List<string>();
                foreach (var x in members)
                {
                    modifiedProperties.Add(string.Format("{0}={1}", x.Name, x.GetValue(properties)));
                }

                //Override property file
                File.Delete(e.FullPath);
                File.WriteAllLines(e.FullPath, modifiedProperties.ToArray());
            }
        }
    }
}
