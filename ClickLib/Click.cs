using System;
using System.Collections.Generic;
using System.Linq;

namespace ClickLib
{
    public static class Click
    {
        private static List<ClickBase> Clickables { get; } = new List<ClickBase>();

        private static bool SetupComplete = false;

        public static void Initialize()
        {
            if (!SetupComplete)
            {
                SetupComplete = true;

                FFXIVClientStructs.Resolver.Initialize();

                var types = typeof(ClickBase).Assembly.GetTypes()
                    .Where(t => t.IsSubclassOf(typeof(ClickBase)));

                foreach (var type in types)
                {
                    var clickable = (ClickBase)Activator.CreateInstance(type);
                    Clickables.Add(clickable);
                }
            }
        }

        public static bool TrySendClick(string name) => TrySendClick(name, default);

        public static bool TrySendClick(string name, IntPtr addon)
        {
            try
            {
                SendClick(name, addon);
                return true;
            }
            catch
            {
                return false;
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
