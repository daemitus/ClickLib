using FFXIVClientStructs.FFXIV.Client.UI;

namespace ClickLib.Clicks
{
    internal sealed class ClickMaterializeDialog : ClickBase
    {
        protected override string Name => "MaterializeDialog";
        protected override string AddonName => "MaterializeDialog";

        public unsafe ClickMaterializeDialog() : base()
        {
            AvailableClicks["materialize"] = (addon) => SendClick(addon, EventType.CHANGE, 0, ((AddonMaterializeDialog*)addon)->YesButton->AtkComponentBase.OwnerNode);
        }
    }
}
