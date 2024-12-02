using System;

/*
 * "Kill me, please!" - logs class
*/

namespace iiAdditions
{
    internal static class Logs
    {
        public static void Log(string message) => Console.WriteLine($"{PluginInfo.GUID}: {message}");
    }
}
