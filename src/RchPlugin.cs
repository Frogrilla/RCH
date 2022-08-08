using BepInEx;
using Bepinject;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Utilla;

namespace RCH
{
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class RchPlugin : BaseUnityPlugin
    {
        void Start()
        {
            try { Zenjector.Install<CI.MainInstaller>().OnProject(); }
            catch { Console.WriteLine("RchView not installed"); }

            string HeaderPath = Path.Combine(Path.GetDirectoryName(typeof(RchPlugin).Assembly.Location), "Custom Headers.txt");
            if (File.Exists(HeaderPath)) Manager.CustomTexts = File.ReadAllLines(HeaderPath);
            else File.WriteAllLines(HeaderPath, Manager.CustomTexts);

            Console.WriteLine($"RCH loaded headers:\n{File.ReadAllText(HeaderPath)}");

            Manager.Enabled = true;
        }
    }
}
