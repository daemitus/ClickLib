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
            => this.ClickRadioButton(6, this.Type->FieldcraftButton);

        /// <summary>
        /// Click the tradecraft button.
        /// </summary>
        [ClickName("guild_leve_tradecraft")]
        public void Tradecraft()
            => this.ClickRadioButton(7, this.Type->TradecraftButton);

        /// <summary>
        /// Click the carpenter button.
        /// </summary>
        [ClickName("guild_leve_carpenter")]
        public void Carpenter()
            => this.ClickRadioButton(9, this.Type->CarpenterButton);

        /// <summary>
        /// Click the blacksmith button.
        /// </summary>
        [ClickName("guild_leve_blacksmith")]
        public void Blacksmith()
            => this.ClickRadioButton(10, this.Type->BlacksmithButton);

        /// <summary>
        /// Click the armorer button.
        /// </summary>
        [ClickName("guild_leve_armorer")]
        public void Armorer()
            => this.ClickRadioButton(11, this.Type->ArmorerButton);

        /// <summary>
        /// Click the goldsmith button.
        /// </summary>
        [ClickName("guild_leve_goldsmith")]
        public void Goldsmith()
            => this.ClickRadioButton(12, this.Type->GoldsmithButton);

        /// <summary>
        /// Click the leatherworker button.
        /// </summary>
        [ClickName("guild_leve_leatherworker")]
        public void Leatherworker()
            => this.ClickRadioButton(13, this.Type->LeatherworkerButton);

        /// <summary>
        /// Click the weaver button.
        /// </summary>
        [ClickName("guild_leve_weaver")]
        public void Weaver()
            => this.ClickRadioButton(14, this.Type->WeaverButton);

        /// <summary>
        /// Click the alchemist button.
        /// </summary>
        [ClickName("guild_leve_alchemist")]
        public void Alchemist()
            => this.ClickRadioButton(15, this.Type->AlchemistButton);

        /// <summary>
        /// Click the culinarian button.
        /// </summary>
        [ClickName("guild_leve_culinarian")]
        public void Culinarian()
            => this.ClickRadioButton(16, this.Type->CulinarianButton);

        /// <summary>
        /// Click the miner button.
        /// </summary>
        [ClickName("guild_leve_miner")]
        public void Miner()
            => this.ClickRadioButton(9, this.Type->MinerButton);

        /// <summary>
        /// Click the botanist button.
        /// </summary>
        [ClickName("guild_leve_botanist")]
        public void Botanist()
            => this.ClickRadioButton(10, this.Type->BotanistButton);

        /// <summary>
        /// Click the fisher button.
        /// </summary>
        [ClickName("guild_leve_fisher")]
        public void Fisher()
            => this.ClickRadioButton(11, this.Type->FisherButton);
    }
}
