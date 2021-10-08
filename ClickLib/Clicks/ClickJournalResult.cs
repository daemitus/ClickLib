using System;

using FFXIVClientStructs.FFXIV.Client.UI;

namespace ClickLib.Clicks
{
    /// <summary>
    /// Addon JournalResult.
    /// </summary>
    public sealed unsafe class ClickJournalResult : ClickBase<AddonJournalResult>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClickJournalResult"/> class.
        /// </summary>
        /// <param name="addon">Addon pointer.</param>
        public ClickJournalResult(IntPtr addon = default)
            : base(addon)
        {
        }

        /// <inheritdoc/>
        protected override string AddonName => "JournalResult";

        /// <summary>
        /// Click the complete button.
        /// </summary>
        [ClickName("journal_result_complete")]
        public void Complete()
        {
            ClickAddonButton(&this.Addon->AtkUnitBase, this.Addon->CompleteButton, 1);
        }

        /// <summary>
        /// Click the decline button.
        /// </summary>
        [ClickName("journal_result_decline")]
        public void Decline()
        {
            ClickAddonButton(&this.Addon->AtkUnitBase, this.Addon->DeclineButton, 2);
        }
    }
}
