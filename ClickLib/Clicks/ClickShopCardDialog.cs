using FFXIVClientStructs.FFXIV.Client.UI;

namespace ClickLib.Clicks
{
    internal sealed class ClickShopCardDialog : ClickBase
    {
        protected override string Name => "ShopCardDialog";
        protected override string AddonName => "ShopCardDialog";

        public unsafe ClickShopCardDialog() : base()
        {
            // TODO: Set card quantity
            AvailableClicks["sell_triple_triad_card"] = (addon) => SendClick(addon, EventType.CHANGE, 0, ((AddonShopCardDialog*)addon)->AtkUnitBase.UldManager.NodeList[3]);
        }
    }
}
