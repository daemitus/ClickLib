using System;

using FFXIVClientStructs.FFXIV.Client.UI;

namespace ClickLib.Clicks
{
    /// <summary>
    /// Addon GrandCompanySupplyReward.
    /// </summary>
    public sealed unsafe class ClickGrandCompanySupplyReward : ClickBase<AddonGrandCompanySupplyReward>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClickGrandCompanySupplyReward"/> class.
        /// </summary>
        /// <param name="addon">Addon pointer.</param>
        public ClickGrandCompanySupplyReward(IntPtr addon = default)
            : base(addon)
        {
        }

        /// <inheritdoc/>
        protected override string AddonName => "GrandCompanySupplyReward";

        /// <summary>
        /// Click the deliver button.
        /// </summary>
        [ClickName("grand_company_expert_delivery_deliver")]
        public void Deliver()
            => this.ClickButton(0, this.Type->DeliverButton);

        /// <summary>
        /// Click the cancel button.
        /// </summary>
        [ClickName("grand_company_expert_delivery_cancel")]
        public void Cancel()
            => this.ClickButton(1, this.Type->CancelButton);
    }
}
