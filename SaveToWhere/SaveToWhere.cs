using HarmonyLib;
using System;
using FrooxEngine;
using System.Collections.Generic;
using ResoniteModLoader;
using Elements.Core;

namespace SaveToWhere
{
    public class SaveToWhere : ResoniteMod
    {
        public override string Name => "SaveToWhere";
        public override string Author => "kka429";
        public override string Version => "2.0.0";
        public override string Link => "https://github.com/rassi0429/Reso-SaveToWhere"; // this line is optional and can be omitted

        public override void OnEngineInit()
        {
            Harmony harmony = new Harmony("dev.kokoa.savetowhere");
            harmony.PatchAll();
        }

        [HarmonyPatch(typeof(Elements.Core.LocaleHelper), "AsLocaleKey", new Type[] { typeof(string), typeof(bool), typeof(Dictionary<string, object>) })]
        class Patch
        {
            static void Postfix(ref LocaleString __result, string str)
            {
                if(str == "Interaction.SaveToInventory")
                {                 
                    __result = "Save To : \n /" + InventoryBrowser.CurrentUserspaceInventory?.CurrentPath.Replace("\\","/");
                }
            }
        }
    }
}