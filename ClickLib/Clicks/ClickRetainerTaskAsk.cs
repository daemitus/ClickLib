using System;

using FFXIVClientStructs.FFXIV.Client.UI;

namespace ClickLib.Clicks
{
    /// <summary>
    /// Addon RetainerTaskAsk.
    /// </summary>
    public sealed unsafe class ClickRetainerTaskAsk : ClickBase<AddonRetainerTaskAsk>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClickRetainerTaskAsk"/> class.
        /// </summary>
        /// <param name="addon">Addon pointer.</param>
        public ClickRetainerTaskAsk(IntPtr addon = default)
            : base(addon)
        {
        }

        /// <inheritdoc/>
        protected override string AddonName => "RetainerTaskAsk";

        /// <summary>
        /// Click the assign button.
        /// </summary>
        [ClickName("retainer_venture_ask_assign")]
        public void Assign()
            => this.ClickButton(1, this.Type->AssignButton);

        /// <summary>
        /// Click the return button.
        /// </summary>
        [ClickName("retainer_venture_ask_return")]
        public void Return()
            => this.ClickButton(2, this.Type->ReturnButton);
    }
}
