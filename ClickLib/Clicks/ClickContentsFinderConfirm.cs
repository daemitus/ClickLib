using System;

using FFXIVClientStructs.FFXIV.Client.UI;

namespace ClickLib.Clicks
{
    /// <summary>
    /// Addon ContentsFinderConfirm.
    /// </summary>
    public sealed unsafe class ClickContentsFinderConfirm : ClickBase<AddonContentsFinderConfirm>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClickContentsFinderConfirm"/> class.
        /// </summary>
        /// <param name="addon">Addon pointer.</param>
        public ClickContentsFinderConfirm(IntPtr addon = default)
            : base(addon)
        {
        }

        /// <inheritdoc/>
        protected override string AddonName => "ContentsFinderConfirm";

        /// <summary>
        /// Click the commence button.
        /// </summary>
        [ClickName("contentsfinderconfirm_commence")]
        public void Collect()
        {
            ClickAddonButton(&this.Addon->AtkUnitBase, this.Addon->CommenceButton, 0x7);
        }
    }
}