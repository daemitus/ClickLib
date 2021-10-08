using System;

using FFXIVClientStructs.FFXIV.Client.UI;

namespace ClickLib.Clicks
{
    /// <summary>
    /// Addon GuildLeve.
    /// </summary>
    public sealed unsafe class ClickGuildLeve : ClickBase<AddonGuildLeve>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClickGuildLeve"/> class.
        /// </summary>
        /// <param name="addon">Addon pointer.</param>
        public ClickGuildLeve(IntPtr addon = default)
            : base(addon)
        {
        }

        /// <inheritdoc/>
        protected override string AddonName => "GuildLeve";

        /// <summary>
        /// Click the fieldcraft button.
        /// </summary>
        [ClickName("guild_leve_fieldcraft")]
        public void Fieldcraft()
        {
            ClickAddonRadioButton(&this.Addon->AtkUnitBase, this.Addon->FieldcraftButton, 6);
        }

        /// <summary>
        /// Click the tradecraft button.
        /// </summary>
        [ClickName("guild_leve_tradecraft")]
        public void Tradecraft()
        {
            ClickAddonRadioButton(&this.Addon->AtkUnitBase, this.Addon->TradecraftButton, 7);
        }

        /// <summary>
        /// Click the carpenter button.
        /// </summary>
        [ClickName("guild_leve_carpenter")]
        public void Carpenter()
        {
            ClickAddonRadioButton(&this.Addon->AtkUnitBase, this.Addon->CarpenterButton, 9);
        }

        /// <summary>
        /// Click the blacksmith button.
        /// </summary>
        [ClickName("guild_leve_blacksmith")]
        public void Blacksmith()
        {
            ClickAddonRadioButton(&this.Addon->AtkUnitBase, this.Addon->BlacksmithButton, 10);
        }

        /// <summary>
        /// Click the armorer button.
        /// </summary>
        [ClickName("guild_leve_armorer")]
        public void Armorer()
        {
            ClickAddonRadioButton(&this.Addon->AtkUnitBase, this.Addon->ArmorerButton, 11);
        }

        /// <summary>
        /// Click the goldsmith button.
        /// </summary>
        [ClickName("guild_leve_goldsmith")]
        public void Goldsmith()
        {
            ClickAddonRadioButton(&this.Addon->AtkUnitBase, this.Addon->GoldsmithButton, 12);
        }

        /// <summary>
        /// Click the leatherworker button.
        /// </summary>
        [ClickName("guild_leve_leatherworker")]
        public void Leatherworker()
        {
            ClickAddonRadioButton(&this.Addon->AtkUnitBase, this.Addon->LeatherworkerButton, 13);
        }

        /// <summary>
        /// Click the weaver button.
        /// </summary>
        [ClickName("guild_leve_weaver")]
        public void Weaver()
        {
            ClickAddonRadioButton(&this.Addon->AtkUnitBase, this.Addon->WeaverButton, 14);
        }

        /// <summary>
        /// Click the alchemist button.
        /// </summary>
        [ClickName("guild_leve_alchemist")]
        public void Alchemist()
        {
            ClickAddonRadioButton(&this.Addon->AtkUnitBase, this.Addon->AlchemistButton, 15);
        }

        /// <summary>
        /// Click the culinarian button.
        /// </summary>
        [ClickName("guild_leve_culinarian")]
        public void Culinarian()
        {
            ClickAddonRadioButton(&this.Addon->AtkUnitBase, this.Addon->CulinarianButton, 16);
        }

        /// <summary>
        /// Click the miner button.
        /// </summary>
        [ClickName("guild_leve_miner")]
        public void Miner()
        {
            ClickAddonRadioButton(&this.Addon->AtkUnitBase, this.Addon->MinerButton, 9);
        }

        /// <summary>
        /// Click the botanist button.
        /// </summary>
        [ClickName("guild_leve_botanist")]
        public void Botanist()
        {
            ClickAddonRadioButton(&this.Addon->AtkUnitBase, this.Addon->BotanistButton, 10);
        }

        /// <summary>
        /// Click the fisher button.
        /// </summary>
        [ClickName("guild_leve_fisher")]
        public void Fisher()
        {
            ClickAddonRadioButton(&this.Addon->AtkUnitBase, this.Addon->FisherButton, 11);
        }
    }
}
