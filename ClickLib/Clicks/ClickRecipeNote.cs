using System;

using FFXIVClientStructs.FFXIV.Client.UI;

namespace ClickLib.Clicks
{
    /// <summary>
    /// Addon RecipeNote.
    /// </summary>
    public sealed unsafe class ClickRecipeNote : ClickAddonBase<AddonRecipeNote>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClickRecipeNote"/> class.
        /// </summary>
        /// <param name="addon">Addon pointer.</param>
        public ClickRecipeNote(IntPtr addon = default)
            : base(addon)
        {
        }

        /// <inheritdoc/>
        protected override string AddonName => "RecipeNote";

        public static implicit operator ClickRecipeNote(IntPtr addon) => new(addon);

        /// <summary>
        /// Instantiate this click using the given addon.
        /// </summary>
        /// <param name="addon">Addon to reference.</param>
        /// <returns>A click instance.</returns>
        public static ClickRecipeNote Using(IntPtr addon) => new(addon);

        /// <summary>
        /// Click the synthesize button.
        /// </summary>
        [ClickName("synthesize")]
        public void Synthesize()
        {
            ClickAddonButton(&this.Addon->AtkUnitBase, this.Addon->SynthesizeButton, 13);
        }

        /// <summary>
        /// Click the quick synthesis button.
        /// </summary>
        [ClickName("quick_synthesis")]
        public void QuickSynthesis()
        {
            ClickAddonButton(&this.Addon->AtkUnitBase, this.Addon->QuickSynthesisButton, 14);
        }

        /// <summary>
        /// Click the trial synthesis button.
        /// </summary>
        [ClickName("trial_synthesis")]
        public void TrialSynthesis()
        {
            ClickAddonButton(&this.Addon->AtkUnitBase, this.Addon->TrialSynthesisButton, 15);
        }
    }
}
