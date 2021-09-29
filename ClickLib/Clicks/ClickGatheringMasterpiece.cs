using System;

using FFXIVClientStructs.FFXIV.Client.UI;

namespace ClickLib.Clicks
{
    /// <summary>
    /// Addon GatheringMasterpiece.
    /// </summary>
    public sealed unsafe class ClickGatheringMasterpiece : ClickBase<AddonGatheringMasterpiece>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClickGatheringMasterpiece"/> class.
        /// </summary>
        /// <param name="addon">Addon pointer.</param>
        public ClickGatheringMasterpiece(IntPtr addon = default)
            : base(addon)
        {
        }

        /// <inheritdoc/>
        protected override string AddonName => "GatheringMasterpiece";

        /// <summary>
        /// Click the collect button.
        /// </summary>
        [ClickName("collect")]
        public void Collect()
            => this.ClickDragDrop(112, this.Type->CollectDragDrop);
    }
}
