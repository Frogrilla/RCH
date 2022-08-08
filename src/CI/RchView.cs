﻿using System;
using System.Collections.Generic;
using System.Text;
using ComputerInterface;
using ComputerInterface.ViewLib;
using UnityEngine;

namespace RCH.CI
{
    internal class RchView : ComputerView
    {
        internal string HighlightDynamic(string text)
        {
            foreach(string key in Manager.DynamicDict.Keys)
            {
                string highlightedKey;
                highlightedKey = key.Replace("{", "<color=#F2BB05>{<color=#F9E900>");
                highlightedKey = highlightedKey.Replace("}", "</color>}</color>");

                text = text.Replace(key, highlightedKey);
            }

            return text;
        }
        public override void OnShow(object[] args)
        {
            base.OnShow(args);
            DrawScreen();
        }
        private void DrawScreen()
        {
            SetText(str =>
            {
                str.BeginCenter();
                str.MakeBar('-', SCREEN_WIDTH, 0, "FFFFFF10").AppendLine();
                str.AppendClr("Room Code Hider", "FF0066").AppendLine();
                str.Append("By <color=#38FF8D>Frogrilla</color>").AppendLine();
                str.MakeBar('-', SCREEN_WIDTH, 0, "FFFFFF10").AppendLine();
                str.EndAlign();
                str.Append($"Current Header:\n{HighlightDynamic(Manager.CustomTexts[Manager.Index])}").AppendLine();
                str.AppendClr((Manager.Enabled ? "\nEnabled" : "\nDisabled"), (Manager.Enabled ? "#01FF55" : "#FF0033")).AppendLine();
            });
        }
        public override void OnKeyPressed(EKeyboardKey key)
        {
            switch (key)
            {
                case EKeyboardKey.Right:
                    Manager.Index++;
                    Manager.ForceUpdate();
                    break;
                case EKeyboardKey.Left:
                    Manager.Index--;
                    Manager.ForceUpdate();
                    break;
                case EKeyboardKey.Enter:
                    Manager.Enabled ^= true;
                    break;
                case EKeyboardKey.Back:
                    ReturnToMainMenu();
                    break;
            }
            DrawScreen();
        }
    }
}
