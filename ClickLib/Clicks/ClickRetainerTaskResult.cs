using FFXIVClientStructs.FFXIV.Client.UI;

namespace ClickLib.Clicks
{
    internal sealed class ClickRetainerTaskResult : ClickBase
    {
        protected override string Name => "RetainerTaskResult";
        protected override string AddonName => "RetainerTaskResult";

        public unsafe ClickRetainerTaskResult() : base()
        {
            AvailableClicks["retainer_venture_result_confirm"] = (addon) => SendClick(addon, EventType.CHANGE, 2, ((AddonRetainerTaskResult*)addon)->ConfirmButton->AtkComponentBase.OwnerNode);
            AvailableClicks["retainer_venture_result_reassign"] = (addon) => SendClick(addon, EventType.CHANGE, 3, ((AddonRetainerTaskResult*)addon)->ReassignButton->AtkComponentBase.OwnerNode);
        }
    }
}
