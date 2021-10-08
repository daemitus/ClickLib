using System;

using FFXIVClientStructs.FFXIV.Client.UI;

namespace ClickLib.Clicks
{
    /// <summary>
    /// Addon JournalDetail.
    /// </summary>
    public sealed unsafe class ClickJournalDetail : ClickBase<AddonJournalDetail>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClickJournalDetail"/> class.
        /// </summary>
        /// <param name="addon">Addon pointer.</param>
        public ClickJournalDetail(IntPtr addon = default)
            : base(addon)
        {
        }

        /// <inheritdoc/>
        protected override string AddonName => "JournalDetail";

        /// <summary>
        /// Click the accept button.
        /// </summary>
        [ClickName("journal_detail_accept")]
        public void Accept()
        {
            ClickAddonButton(&this.Addon->AtkUnitBase, this.Addon->AcceptButton, 1);
        }

        /// <summary>
        /// Click the decline button.
        /// </summary>
        [ClickName("journal_detail_decline")]
        public void Decline()
        {
            ClickAddonButton(&this.Addon->AtkUnitBase, this.Addon->DeclineButton, 2);
        }
    }
}
