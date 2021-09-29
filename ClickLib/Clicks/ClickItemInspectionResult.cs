using System;

using FFXIVClientStructs.FFXIV.Client.UI;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace ClickLib.Clicks
{
    /// <summary>
    /// Addon ItemInspectionResult.
    /// </summary>
    public sealed unsafe class ClickItemInspectionResult : ClickBase<AddonItemInspectionResult>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClickItemInspectionResult"/> class.
        /// </summary>
        /// <param name="addon">Addon pointer.</param>
        public ClickItemInspectionResult(IntPtr addon = default)
            : base(addon)
        {
        }

        /// <inheritdoc/>
        protected override string AddonName => "ItemInspectionResult";

        /// <summary>
        /// Click the next button.
        /// </summary>
        [ClickName("item_inspection_result_next")]
        public void Next()
            => this.ClickButton(0, (AtkComponentButton*)this.Type->AtkUnitBase.UldManager.NodeList[2]);

        /// <summary>
        /// Click the close button.
        /// </summary>
        [ClickName("item_inspection_result_close")]
        public void Close()
            => this.ClickButton(0xFFFFFFFF, (AtkComponentButton*)this.Type->AtkUnitBase.UldManager.NodeList[3]);
    }
}
