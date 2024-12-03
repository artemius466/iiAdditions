using System;
using System.Collections.Generic;
using System.Text;

/*
 * Events, so plugins will know, when menu is loaded and etc
*/

namespace iiAdditions.Events
{
    public class Events
    {
        public static Events instance;

        public static event EventHandler MenuInitialized;

        public void TriggerMenuInitialized()
        {
            MenuInitialized?.Invoke(this, EventArgs.Empty);
        }
    }
}