using System;

using FFXIVClientStructs.FFXIV.Client.UI;

namespace ClickLib.Clicks
{
    /// <summary>
    /// Addon MaterializeDialog.
    /// </summary>
    public sealed unsafe class ClickMaterializeDialog : ClickAddonBase<AddonMaterializeDialog>
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

        public static implicit operator ClickMaterializeDialog(IntPtr addon) => new(addon);

        /// <summary>
        /// Instantiate this click using the given addon.
        /// </summary>
        /// <param name="addon">Addon to reference.</param>
        /// <returns>A click instance.</returns>
        public static ClickMaterializeDialog Using(IntPtr addon) => new(addon);

        /// <summary>
        /// Click the deliver button.
        /// </summary>
        [ClickName("materialize")]
        public void Materialize()
        {
            ClickAddonButton(&this.Addon->AtkUnitBase, this.Addon->YesButton, 0);
        }
    }
}
