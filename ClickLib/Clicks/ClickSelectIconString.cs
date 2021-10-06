using System;

using FFXIVClientStructs.FFXIV.Client.UI;

namespace ClickLib.Clicks
{
    /// <summary>
    /// Addon SelectString.
    /// </summary>
    public sealed unsafe class ClickSelectIconString : ClickBase<AddonSelectIconString>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClickSelectIconString"/> class.
        /// </summary>
        /// <param name="addon">Addon pointer.</param>
        public ClickSelectIconString(IntPtr addon = default)
            : base(addon)
        {
        }

        /// <inheritdoc/>
        protected override string AddonName => "SelectIconString";

        /// <summary>
        /// Select the item at the given index.
        /// </summary>
        /// <param name="index">Index to select.</param>
        public void SelectItem(ushort index)
            => this.ClickList(index, this.Type->PopupMenu.List);

        /// <summary>
        /// Click the item in index 1.
        /// </summary>
        [ClickName("select_icon_string1")]
        public void SelectItem1() => this.SelectItem(0);

        /// <summary>
        /// Click the item in index 2.
        /// </summary>
        [ClickName("select_icon_string2")]
        public void SelectItem2() => this.SelectItem(1);

        /// <summary>
        /// Click the item in index 3.
        /// </summary>
        [ClickName("select_icon_string3")]
        public void SelectItem3() => this.SelectItem(2);

        /// <summary>
        /// Click the item in index 4.
        /// </summary>
        [ClickName("select_icon_string4")]
        public void SelectItem4() => this.SelectItem(3);

        /// <summary>
        /// Click the item in index 5.
        /// </summary>
        [ClickName("select_icon_string5")]
        public void SelectItem5() => this.SelectItem(4);

        /// <summary>
        /// Click the item in index 6.
        /// </summary>
        [ClickName("select_icon_string6")]
        public void SelectItem6() => this.SelectItem(5);

        /// <summary>
        /// Click the item in index 7.
        /// </summary>
        [ClickName("select_icon_string7")]
        public void SelectItem7() => this.SelectItem(6);

        /// <summary>
        /// Click the item in index 8.
        /// </summary>
        [ClickName("select_icon_string8")]
        public void SelectItem8() => this.SelectItem(7);
    }
}
