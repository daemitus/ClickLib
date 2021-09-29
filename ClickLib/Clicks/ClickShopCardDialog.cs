using System;

using FFXIVClientStructs.FFXIV.Client.UI;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace ClickLib.Clicks
{
    /// <summary>
    /// Addon ShopCardDialog.
    /// </summary>
    public sealed unsafe class ClickShopCardDialog : ClickBase<AddonShopCardDialog>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClickShopCardDialog"/> class.
        /// </summary>
        /// <param name="addon">Addon pointer.</param>
        public ClickShopCardDialog(IntPtr addon = default)
            : base(addon)
        {
        }

        /// <inheritdoc/>
        protected override string AddonName => "ShopCardDialog";

        /// <summary>
        /// Click the sell button.
        /// </summary>
        [ClickName("sell_triple_triad_card")]
        public unsafe void Sell()
            => this.ClickButton(0, (AtkComponentButton*)this.Type->AtkUnitBase.UldManager.NodeList[3]);
    }
}
