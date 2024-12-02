using iiMenu.Menu;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/*
 * Plugin Manager to... 
 * ..create buttons? (and guns!)
*/

namespace iiAdditions
{
    public class PluginManager
    {
        // Add button to plugins category
        // TODO: "Add categories" function
        public static void AddFunction(string text = "Unnamed function", bool isToggleable = false, Action method = null, string toolTip = "This plugin doesn't have a tooltip :/", Action enableMethod = null, Action disableMethod = null) => Plugin.AddButton(text, isToggleable, method, toolTip, enableMethod, disableMethod);

        // Ez access to guns
        public static (RaycastHit? Ray, GameObject NewPointer)? Gun()
        {
            (RaycastHit Ray, GameObject NewPointer)? output;

            if (Main.GetGunInput(false))
            {
                output = Main.RenderGun();

                if (Main.GetGunInput(true)) return output;
            }

            return null;
        }


        // Ez access to guns (with lock on players)
        private static bool lockingOn;

        public static (RaycastHit? Ray, GameObject NewPointer, VRRig lockOnRig)? GunLockOn()
        {
            (RaycastHit Ray, GameObject NewPointer) output1;
            (RaycastHit? Ray, GameObject? NewPointer, VRRig? lockOnRig) output = (null, null, null);

            if (Main.GetGunInput(false))
            {
                output1 = Main.RenderGun();

                if (Main.GetGunInput(true))
                {
                    output.lockOnRig = output1.Ray.collider.GetComponentInParent<VRRig>();
                    output.Ray = output1.Ray;
                    output.NewPointer = output1.NewPointer;
                    Main.whoCopy = output1.Ray.collider.GetComponentInParent<VRRig>();
                    Main.isCopying = true;

                    return output;
                }
            } else
            {
                output.lockOnRig = null;
                Main.whoCopy = null;
                Main.isCopying = false;
            }

            return null;
        }
    }
}
