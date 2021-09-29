using System;

using FFXIVClientStructs.FFXIV.Client.UI;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace ClickLib.Clicks
{
    /// <summary>
    /// Addon MateriaRetrieveDialog.
    /// </summary>
    public sealed unsafe class ClickMateriaRetrieveDialog : ClickBase<AddonMateriaRetrieveDialog>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClickMateriaRetrieveDialog"/> class.
        /// </summary>
        /// <param name="addon">Addon pointer.</param>
        public ClickMateriaRetrieveDialog(IntPtr addon = default)
            : base(addon)
        {
        }

        /// <inheritdoc/>
        protected override string AddonName => "MateriaRetrieveDialog";

        /// <summary>
        /// Click the begin button.
        /// </summary>
        [ClickName("retrieve_materia_begin")]
        public void Begin()
            => this.ClickButton(0, (AtkComponentButton*)this.Type->AtkUnitBase.UldManager.NodeList[4]);

        /// <summary>
        /// Click the return button.
        /// </summary>
        [ClickName("retrieve_materia_return")]
        public void Return()
            => this.ClickButton(1, (AtkComponentButton*)this.Type->AtkUnitBase.UldManager.NodeList[3]);
    }
}
