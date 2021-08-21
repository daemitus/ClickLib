using FFXIVClientStructs.FFXIV.Client.UI;

namespace ClickLib.Clicks
{
    internal sealed class ClickSelectYesNo : ClickBase
    {
        protected override string Name => "SelectYesno";
        protected override string AddonName => "SelectYesno";

        public unsafe ClickSelectYesNo() : base()
        {
            AvailableClicks["select_yes"] = (addon) => SendClick(addon, EventType.CHANGE, 0, ((AddonSelectYesno*)addon)->YesButton->AtkComponentBase.OwnerNode);
            AvailableClicks["select_no"] = (addon) => SendClick(addon, EventType.CHANGE, 1, ((AddonSelectYesno*)addon)->NoButton->AtkComponentBase.OwnerNode);
            
            // This doesn't actually work. However toggling the button's ResNode flags (1 << 5) makes it clickable.
            // AvailableClicks["select_checkbox"] = (addon) => SendClick(addon, EventType.CHANGE, 3, ((AddonSelectYesno*)addon)->ConfirmCheckBox->AtkComponentButton.AtkComponentBase.OwnerNode);
        }
    }
}
