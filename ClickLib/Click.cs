using Dalamud.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClickLib
{
    public static class Click
    {
        private static List<ClickBase> Clickables { get; } = new List<ClickBase>();

        private static bool SetupComplete = false;

        public static void Initialize(DalamudPluginInterface pluginInterface)
        {
            if (!SetupComplete)
            {
                SetupComplete = true;

                var types = typeof(ClickBase).Assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(ClickBase)));
                foreach (var type in types)
                {
                    var ctor = type.GetConstructor(new Type[] { typeof(DalamudPluginInterface) });
                    var clickable = (ClickBase)ctor.Invoke(new object[] { pluginInterface });
                    Clickables.Add(clickable);
                }
            }
        }

        public static void SendClick(string name) => SendClick(name, default);

        public static void SendClick(string name, IntPtr addon)
        {
            if (!SetupComplete)
                throw new InvalidClickException("Click has not been initialized yet");

            foreach (var clickable in Clickables)
            {
                try
                {
                    if (clickable.Click(name, addon))
                        return;
                }
                catch (InvalidClickException ex)
                {
                    throw new InvalidClickException($"Error while performing {name} click", ex);
                }
            }

            throw new ClickNotFoundError("Invalid click");
        }
    }
}
