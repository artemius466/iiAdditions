
# iiAdditions

Mod, that adds a plugin support for [ii's Stupid Menu](https://github.com/iiDk-the-actual/iis.Stupid.Menu)

## Installation

### Dependencies
 - [ii's Stupid Menu](https://github.com/iiDk-the-actual/iis.Stupid.Menu)
### Installation

 - Go to releases page and download latest dll file
 - Place downloaded file into your "Plugins" folder
 - Done, now you can download plugins!

## How to create plugins

Here is an example on how to add function into plugins category:

```csharp
/*
 * Example of plugin for ii's Stupid Menu
*/

namespace YourPluginName
{
    [BepInDependency("Artemius466.iiAdditions", "1.0.0")]
    [BepInPlugin("cool.example.plugin", "Example plugin for iiAdditions", "1.0.0")]
    public class ExamplePlugin : BaseUnityPlugin
    {
        private void Start() => iiAdditions.Events.MenuInitialized += InitButtons;

        private void InitButtons(object sender, EventArgs e)
        {
            iiAdditions.PluginManager.AddFunction("Example Function", false, ExampleFunction, "Example tooltip!");
        }

        private void ExampleFunction()
        {
            iiMenu.Notifications.NotifiLib.SendNotification("Wow! It's working!");
        }
    }
}

```

You can use gun lib:

```csharp
var GunData = iiAdditions.PluginManager.Gun();
if (GunData != null) 
{
    RaycastHit GunRay = GunData.Ray;
    GameObject GunPointer = GunData.NewPointer;
    // Do stuff
}
```

Gun lib with lock on player:
```csharp
var GunData = iiAdditions.PluginManager.GunLockOn();
if (GunData != null) 
{
    RaycastHit GunRay = GunData.Ray;
    GameObject GunPointer = GunData.NewPointer;
    VRRig GunRig = GunData.lockOnRig;
    // Do stuff
}
```
