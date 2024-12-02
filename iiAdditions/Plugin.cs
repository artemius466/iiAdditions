using BepInEx;
using iiMenu.Classes;
using static iiMenu.Menu.Main;
using static iiMenu.Menu.Buttons;
using HarmonyLib;
using System.Linq;
using iiMenu.Mods;
using System.Collections.Generic;
using System;

/*
                  _ _   _       _     _ _ _   _                 
                (_|_) /_\   __| | __| (_) |_(_) ___  _ __  ___ 
                | | |//_\\ / _` |/ _` | | __| |/ _ \| '_ \/ __|
                | | /  _  \ (_| | (_| | | |_| | (_) | | | \__ \
                |_|_\_/ \_/\__,_|\__,_|_|\__|_|\___/|_| |_|___/
    *cool text, don't delete*
    
    Library to create plugins for ii's Stupid Menu!
*/

namespace iiAdditions
{
    [BepInDependency("org.iidk.gorillatag.iimenu", "5.0.0")]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        private static List<ButtonInfo> plugins = new List<ButtonInfo>()
        {
            new ButtonInfo { buttonText = "Exit Plugins", method = Settings.ReturnToMain, isTogglable = false, toolTip = "Returns you to main" }
        };


        private bool LoadedCategory;
        internal static BaseUnityPlugin instance;
        private const int lastButtonArray = 31;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                Events.instance = new Events();
            }
        }

        private void EnablePluginsCategory()
        {
            buttonsType = lastButtonArray;
            pageNumber = 0;
        }


        private void Update()
        {
            if (HasLoaded && !LoadedCategory) Init();
        }
        
        private void Init()
        {
            ButtonInfo sigma = new ButtonInfo { buttonText = "Plugins", method = EnablePluginsCategory, isTogglable = false, toolTip = "Opens the plugins" };
            buttons[0] = buttons[0].AddItem<ButtonInfo>(sigma).ToArray();

            buttons = buttons.AddItem<ButtonInfo[]>(plugins.ToArray()).ToArray();

            Events.instance.TriggerMenuInitialized();

            LoadedCategory = true;
        }

        internal static void AddButton(string text, bool isToggleable, Action method, string toolTip, Action enableMethod, Action disableMethod)
        {
            if (HasLoaded)
            {
                plugins.Add(new ButtonInfo { buttonText = text, isTogglable = isToggleable, method = method, toolTip = toolTip, enableMethod = enableMethod, disableMethod = disableMethod });

                buttons[lastButtonArray] = plugins.ToArray();
            } else
            {
                Logs.Log("ERROR! Could not add a button! ii's Stupid Menu not loaded yet!");
            }
        }
    }

    internal class PluginInfo
    {
        public const string
            GUID = "Artemius466.iiAdditions",
            Name = "iiAdditions",
            Version = "1.0.0";
    }
}

/*
 * Example of plugin for ii's Stupid Menu
*/

//namespace YourPluginName
//{
//    [BepInDependency("Artemius466.iiAdditions", "1.0.0")]
//    [BepInPlugin("cool.example.plugin", "Example plugin for iiAdditions", "1.0.0")]
//    public class ExamplePlugin : BaseUnityPlugin
//    {
//        private void Start() => iiAdditions.Events.MenuInitialized += InitButtons;

//        private void InitButtons(object sender, EventArgs e)
//        {
//            iiAdditions.PluginManager.AddFunction("Example Function", false, ExampleFunction, "Example tooltip!");
//        }

//        private void ExampleFunction()
//        {
//            iiMenu.Notifications.NotifiLib.SendNotification("Wow! It's working!");
//        }
//    }
//}
