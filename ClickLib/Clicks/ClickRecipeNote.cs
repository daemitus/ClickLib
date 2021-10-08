using System;

using FFXIVClientStructs.FFXIV.Client.UI;

namespace ClickLib.Clicks
{
    /// <summary>
    /// Addon RecipeNote.
    /// </summary>
    public sealed unsafe class ClickRecipeNote : ClickBase<AddonRecipeNote>
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

        /// <summary>
        /// Click the synthesize button.
        /// </summary>
        [ClickName("synthesize")]
        public void Synthesize()
        {
            ClickAddonButton(&this.Addon->AtkUnitBase, this.Addon->SynthesizeButton, 13);
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
