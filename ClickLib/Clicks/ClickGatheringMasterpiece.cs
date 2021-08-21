using FFXIVClientStructs.FFXIV.Client.UI;

namespace ClickLib.Clicks
{
    internal class ClickGatheringMasterpiece : ClickBase
    {
        protected override string Name => "Collectables";
        protected override string AddonName => "GatheringMasterpiece";

        public unsafe ClickGatheringMasterpiece() : base()
        {
            AvailableClicks["collect"] = (addon) => SendClick(addon, EventType.ICON_TEXT_ROLL_OUT, 112, ((AddonGatheringMasterpiece*)addon)->CollectDragDrop->AtkComponentBase.OwnerNode);
        }
    }
}
