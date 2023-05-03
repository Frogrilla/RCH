using BepInEx;
using Bepinject;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;
using Utilla;

namespace RCH
{
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class RchPlugin : BaseUnityPlugin
    {
        // Initialisation of RCH manager and computer interface view
        void Start()
        {
            try { Zenjector.Install<CI.MainInstaller>().OnProject(); }
            catch { Console.WriteLine("RchView not installed"); }

            string HeaderPath = Path.Combine(Path.GetDirectoryName(typeof(RchPlugin).Assembly.Location), "Custom Headers.txt");
            if (File.Exists(HeaderPath)) Manager.CustomTexts = File.ReadAllLines(HeaderPath);
            else File.WriteAllLines(HeaderPath, Manager.CustomTexts);

            Console.WriteLine($"RCH loaded headers:\n{File.ReadAllText(HeaderPath)}");
            Console.WriteLine($"RCH current header: (index: {Manager.Index})\n{Manager.CustomTexts[Manager.Index]}");

            Manager.Enabled = true;
        }

        // Keyboard shortcuts to control RCH
        void Update()
        {
            try
            {
                if (Keyboard.current.enterKey.wasPressedThisFrame)
                {
                    Manager.Enabled ^= true;
                }
                else if (Keyboard.current.leftBracketKey.wasPressedThisFrame)
                {
                    Manager.Index++;
                }
                else if (Keyboard.current.rightBracketKey.wasPressedThisFrame)
                {
                    Manager.Index--;
                }
            }
            catch(Exception e)
            {
                print(e);
            }
        }
    }
}
