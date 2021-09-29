using System;

using FFXIVClientStructs.FFXIV.Client.UI;

namespace ClickLib.Clicks
{
    /// <summary>
    /// Addon Talk.
    /// </summary>
    public sealed class ClickTalk : ClickBase<AddonTalk>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClickTalk"/> class.
        /// </summary>
        /// <param name="addon">Addon pointer.</param>
        public ClickTalk(IntPtr addon = default)
            : base(addon)
        {
        }

        /// <inheritdoc/>
        protected override string AddonName => "Talk";

        /// <summary>
        /// Click the talk dialog.
        /// </summary>
        [ClickName("talk")]
        public unsafe void Click()
            => this.ClickStage(0, this.Type->AtkStage);
    }
}
