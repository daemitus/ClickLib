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
            => this.ClickButton(0, this.Type->HandOverButton);

        /// <summary>
        /// Click the cancel button.
        /// </summary>
        [ClickName("request_cancel")]
        public void Cancel()
            => this.ClickButton(1, this.Type->CancelButton);
    }
}
