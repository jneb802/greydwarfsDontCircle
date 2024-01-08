using BepInEx;
using HarmonyLib;
using Jotunn.Entities;
using Jotunn.Managers;
using Jotunn.Utils;
using UnityEngine;

namespace Greydwarfsdontdircle
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    internal class Greydwarfsdontdircle : BaseUnityPlugin
    {
        public const string PluginGUID = "com.github.jneb802.Greydwarfsdontdircle";
        public const string PluginName = "Greydwarfs Dont Circle";
        public const string PluginVersion = "1.0.1";

        private void Awake()
        {
            Jotunn.Logger.LogInfo("Greydwarfs Dont Circle has loaded");

            // Initialize Harmony
            var harmony = new Harmony(PluginGUID);
            harmony.PatchAll();
        }
    }

    // Ensure this is within the same namespace as your main plugin class
    [HarmonyPatch(typeof(MonsterAI))]
    public static class MonsterAIPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch("Awake")]
        public static void AwakePostfix(MonsterAI __instance)
        {
            var monsterName = __instance.gameObject.name;

            // Check if the instance is one of the specified monsters
            if (monsterName.Contains("Greydwarf") || monsterName.Contains("Greyling"))

            {
                __instance.m_circleTargetInterval = 0f;
                __instance.m_circleTargetDuration = 0f;
                __instance.m_circleTargetDistance = 0f;
            }
        }
    }
}