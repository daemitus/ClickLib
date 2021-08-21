using FFXIVClientStructs.FFXIV.Client.UI;

namespace ClickLib.Clicks
{
    internal sealed class ClickTalk : ClickBase
    {
        protected override string Name => "Talk";
        protected override string AddonName => "Talk";

        public unsafe ClickTalk() : base()
        {
            AvailableClicks["talk"] = (addon) => SendClick(addon, EventType.INPUT, 0, ((AddonTalk*)addon)->AtkStage);
        }
    }
}
