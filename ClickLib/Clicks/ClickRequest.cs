using System;

using FFXIVClientStructs.FFXIV.Client.UI;

namespace ClickLib.Clicks
{
    /// <summary>
    /// Addon Request.
    /// </summary>
    public sealed unsafe class ClickRequest : ClickBase<AddonRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClickRequest"/> class.
        /// </summary>
        /// <param name="addon">Addon pointer.</param>
        public ClickRequest(IntPtr addon = default)
            : base(addon)
        {
        }

        /// <inheritdoc/>
        protected override string AddonName => "Request";

        /// <summary>
        /// Click the hand over button.
        /// </summary>
        [ClickName("request_hand_over")]
        public void HandOver()
        {
            ClickAddonButton(&this.Addon->AtkUnitBase, this.Addon->HandOverButton, 0);
        }

        /// <summary>
        /// Click the cancel button.
        /// </summary>
        [ClickName("request_cancel")]
        public void Cancel()
        {
            ClickAddonButton(&this.Addon->AtkUnitBase, this.Addon->CancelButton, 1);
        }
    }
}
