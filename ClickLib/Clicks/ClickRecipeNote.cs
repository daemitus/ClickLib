using FFXIVClientStructs.FFXIV.Client.UI;

namespace ClickLib.Clicks
{
    internal sealed class ClickRecipeNote : ClickBase
    {
        protected override string Name => "RecipeBook";
        protected override string AddonName => "RecipeNote";

        public unsafe ClickRecipeNote() : base()
        {
            AvailableClicks["synthesize"] = (addon) => SendClick(addon, EventType.CHANGE, 13, ((AddonRecipeNote*)addon)->SynthesizeButton->AtkComponentBase.OwnerNode);
            AvailableClicks["trial_synthesis"] = (addon) => SendClick(addon, EventType.CHANGE, 15, ((AddonRecipeNote*)addon)->TrialSynthesisButton->AtkComponentBase.OwnerNode);
        }
    }
}
