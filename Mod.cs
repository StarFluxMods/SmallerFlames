using KitchenLib;
using KitchenMods;
using System.Reflection;
using HarmonyLib;
using Kitchen;
using UnityEngine;

namespace SmallerFlames
{
    public class Mod : BaseMod, IModSystem
    {
        public const string MOD_GUID = "com.starfluxgames.smallerflames";
        public const string MOD_NAME = "Smaller Flames";
        public const string MOD_VERSION = "0.1.1";
        public const string MOD_AUTHOR = "StarFluxGames";
        public const string MOD_GAMEVERSION = ">=1.2.0";

        public Mod() : base(MOD_GUID, MOD_NAME, MOD_AUTHOR, MOD_VERSION, MOD_GAMEVERSION, Assembly.GetExecutingAssembly()) { }

        protected override void OnInitialise()
        {
            LogWarning($"{MOD_GUID} v{MOD_VERSION} in use!");
        }
        #region Logging
        public static void LogInfo(string _log) { Debug.Log($"[{MOD_NAME}] " + _log); }
        public static void LogWarning(string _log) { Debug.LogWarning($"[{MOD_NAME}] " + _log); }
        public static void LogError(string _log) { Debug.LogError($"[{MOD_NAME}] " + _log); }
        public static void LogInfo(object _log) { LogInfo(_log.ToString()); }
        public static void LogWarning(object _log) { LogWarning(_log.ToString()); }
        public static void LogError(object _log) { LogError(_log.ToString()); }
        #endregion
    }
    
    [HarmonyPatch(typeof(ApplianceView), "UpdateData")]

    public class ApplianceView_Patch
    {
        static void Postfix(ApplianceView __instance, ApplianceView.ViewData view_data)
        {
            GameObject Fire = __instance.transform.Find("VFX Manager").Find("Fire").gameObject;
            if (Fire != null)
            {
                Fire.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
                Fire.transform.localPosition = new Vector3(0f, 0.6f, 0f);
            }
        }
    }
}
