using System;

using FFXIVClientStructs.FFXIV.Client.UI;

namespace ClickLib.Clicks
{
    /// <summary>
    /// Addon MaterializeDialog.
    /// </summary>
    public sealed unsafe class ClickMaterializeDialog : ClickBase<AddonMaterializeDialog>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClickMaterializeDialog"/> class.
        /// </summary>
        /// <param name="addon">Addon pointer.</param>
        public ClickMaterializeDialog(IntPtr addon = default)
            : base(addon)
        {
        }

        /// <inheritdoc/>
        protected override string AddonName => "MaterializeDialog";

        /// <summary>
        /// Click the deliver button.
        /// </summary>
        [ClickName("materialize")]
        public void Materialize()
            => this.ClickButton(0, this.Type->YesButton);
    }
}
