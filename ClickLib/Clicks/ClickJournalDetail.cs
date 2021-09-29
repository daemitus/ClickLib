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
            => this.ClickButton(1, this.Type->AcceptButton);

        /// <summary>
        /// Click the decline button.
        /// </summary>
        [ClickName("journal_detail_decline")]
        public void Decline()
            => this.ClickButton(2, this.Type->DeclineButton);
    }
}
