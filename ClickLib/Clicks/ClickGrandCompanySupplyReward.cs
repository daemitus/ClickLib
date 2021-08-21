using FFXIVClientStructs.FFXIV.Client.UI;

namespace ClickLib.Clicks
{
    internal sealed class ClickGrandCompanySupplyReward : ClickBase
    {
        protected override string Name => "GrandCompanySupplyReward";
        protected override string AddonName => "GrandCompanySupplyReward";

        public unsafe ClickGrandCompanySupplyReward() : base()
        {
            AvailableClicks["grand_company_expert_delivery_deliver"] = (addon) => SendClick(addon, EventType.CHANGE, 0, ((AddonGrandCompanySupplyReward*)addon)->DeliverButton->AtkComponentBase.OwnerNode);
            AvailableClicks["grand_company_expert_delivery_cancel"] = (addon) => SendClick(addon, EventType.CHANGE, 1, ((AddonGrandCompanySupplyReward*)addon)->CancelButton->AtkComponentBase.OwnerNode);
        }
    }
}
