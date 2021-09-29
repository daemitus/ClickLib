using System;

using FFXIVClientStructs.FFXIV.Client.UI;

namespace ClickLib.Clicks
{
    /// <summary>
    /// Adddon SalvageDialog.
    /// </summary>
    public sealed unsafe class ClickSalvageDialog : ClickBase<AddonSalvageDialog>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClickSalvageDialog"/> class.
        /// </summary>
        /// <param name="addon">Addon pointer.</param>
        public ClickSalvageDialog(IntPtr addon = default)
            : base(addon)
        {
        }

        /// <inheritdoc/>
        protected override string AddonName => "SalvageDialog";

        /// <summary>
        /// Click the desynthesize button.
        /// </summary>
        [ClickName("desynthesize")]
        public void Desynthesize()
            => this.ClickButton(1, this.Type->DesynthesizeButton);

        /// <summary>
        /// Click the desynthesize checkbox button.
        /// </summary>
        [ClickName("desynthesize_checkbox")]
        public void CheckBox()
            => this.ClickCheckBox(3, this.Type->CheckBox);
    }
}
