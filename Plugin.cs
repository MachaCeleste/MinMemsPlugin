using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;

namespace MinMemsPlugin;

[BepInPlugin("com.machaceleste.minmemsplugin", MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    internal static new ManualLogSource Logger;

    public static ConfigEntry<int> minMems;

    private void Awake()
    {
        minMems = Config.Bind("Main", "Min Mems", 2, new ConfigDescription("Sets the min number of memory addresses per library, must be set before singleplayer launches, default: 2", new AcceptableValueRange<int>(1, 5)));

        Logger = base.Logger;
        Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
        var harmony = new Harmony("com.machaceleste.minmemsplugin");
        harmony.PatchAll();
    }
}