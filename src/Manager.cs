using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using HarmonyLib;
using UnityEngine;
using Photon.Pun;

namespace RCH
{
    [HarmonyPatch(typeof(GorillaScoreBoard))]
    [HarmonyPatch("GetBeginningString")]
    internal static class Manager
    {
        internal static Dictionary<string, string> DynamicDict = new Dictionary<string, string>()
        {
            { "{name}",     "out" },
            { "{region}",   "out" },
            { "{mode}",     "out" },
            { "{public}",   "out" },
            { "{count}",    "out" },
            { "{max}",      "out"}    
        };
        internal static string[] CustomTexts = new string[]
        {
            "{count}/{max}    {public} {mode}: {name}", "{count}/{max}    ROOM HIDDEN", "{name}", "HIDDEN"
        };
        private static int index = 0;
        internal static int Index
        {
            get => index;
            set
            {
                if (value < 0) index = CustomTexts.Length - 1;
                else index = value % CustomTexts.Length;
            }
        }
        private static bool enabled = true;
        internal static bool Enabled
        {
            get => enabled;
            set
            {
                if (value) HarmonyPatches.ApplyHarmonyPatches();
                else HarmonyPatches.RemoveHarmonyPatches();

                enabled = value;
                if (PhotonNetwork.InRoom) Manager.ForceUpdate();
            }
        }
        internal static string GenDynamicText(string text)
        {
            foreach(string key in DynamicDict.Keys) text = text.Replace(key, DynamicDict[key]);
            return text;
        }
        internal static void UpdateDict()
        {
            DynamicDict["{name}"]   = PhotonNetwork.CurrentRoom.Name;
            DynamicDict["{region}"] = PhotonNetwork.CloudRegion.Replace("/*","").ToUpper();
            DynamicDict["{mode}"]   = GorillaGameManager.instance.GameMode();
            DynamicDict["{public}"] = PhotonNetwork.CurrentRoom.IsVisible ? "PUBLIC" : "PRIVATE";
            DynamicDict["{count}"]  = PhotonNetwork.CurrentRoom.PlayerCount.ToString();
            DynamicDict["{max}"]    = PhotonNetwork.CurrentRoom.MaxPlayers.ToString();
        }
        internal static void ForceUpdate()
        {
            Console.WriteLine("Forcing scoreboard updates");
            foreach(GorillaScoreBoard board in Resources.FindObjectsOfTypeAll<GorillaScoreBoard>())
            {
                board.RedrawPlayerLines();
                Console.WriteLine($"{board.name} updated");
            }
        }
        internal static bool Prefix(ref string __result)
        {
            UpdateDict();
            __result = GenDynamicText(CustomTexts[Index]) + "\n   PLAYER      COLOR   MUTE   REPORT";
            return !Enabled;
        }
    }
}
