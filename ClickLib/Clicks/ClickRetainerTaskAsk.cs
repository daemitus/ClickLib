using FFXIVClientStructs.FFXIV.Client.UI;

namespace ClickLib.Clicks
{
    internal sealed class ClickRetainerTaskAsk : ClickBase
    {
        protected override string Name => "RetainerTaskAsk";
        protected override string AddonName => "RetainerTaskAsk";

        public unsafe ClickRetainerTaskAsk() : base()
        {
            AvailableClicks["retainer_venture_ask_assign"] = (addon) => SendClick(addon, EventType.CHANGE, 1, ((AddonRetainerTaskAsk*)addon)->AssignButton->AtkComponentBase.OwnerNode);
            AvailableClicks["retainer_venture_ask_return"] = (addon) => SendClick(addon, EventType.CHANGE, 2, ((AddonRetainerTaskAsk*)addon)->ReturnButton->AtkComponentBase.OwnerNode);
        }
    }
}
