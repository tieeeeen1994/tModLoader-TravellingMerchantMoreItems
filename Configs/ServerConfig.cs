using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace TravellingMerchantMoreItems.Configs
{
    public class ServerConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Label("Ammo Box always available")]
        [Tooltip("Allows the Ammo Box to always be available.")]
        [DefaultValue(false)]
        public bool ammoBoxAlwaysAvailable;

        [Label("Sitting Duck always available")]
        [Tooltip("Allows the Sitting Duck to always be available.")]
        [DefaultValue(false)]
        public bool sittingDuckAlwaysAvailable;

        [Label("Ultrabright Torch always available")]
        [Tooltip("Allows the Ultrabright Torch to always be available.")]
        [DefaultValue(false)]
        public bool ultraBrightTorchAlwaysAvailable;

        [Label("Functional accesories always available")]
        [Tooltip("Allows functional acessories to always be available.\n" +
                 "Ingredients for Architect Gizmo Pack and Cell Phone are always available even if this config is off.")]
        [DefaultValue(false)]
        public bool functionalAccessoriesAlwaysAvailable;

        [Label("Functional weapons always available")]
        [Tooltip("Allows functional weapons to always be available.")]
        [DefaultValue(false)]
        public bool functionalWeaponsAlwaysAvailable;

        [Label("Multiply cost for added items")]
        [Tooltip("Items that will be made available by the mod will have their cost multiplied.\n" +
                 "However, if the vanilla shop decides to add the item in question, they will be sold at normal price.")]
        [DefaultValue(true)]
        public bool multiplyCost;

        [Label("Multiplied constant value")]
        [Tooltip("The value in which the items made available by the mod will be multiplied with the cost.")]
        [DefaultValue(3)]
        [Range(1, 100)]
        public int multiplyCostValue;

        [Label("Merchant sells Music Box instead")]
        [Tooltip("The Merchant (not Travelling) will sell the Music Box instead of the Wizard.")]
        [DefaultValue(false)]
        public bool merchantSellsMusicBox;

        [Label("Merchant also sells Ultrabright Torch")]
        [Tooltip("The Merchant will also sell Ultrabright Torches for triple the cost.\n" +
                 "This config is affected by the triple cost setting.")]
        [DefaultValue(false)]
        public bool merchantSellsUltraBrightTorch;

        [Label("Goblin Tinkerer sells Toolbox")]
        [Tooltip("The Goblin Tinkerer will sell the Toolbox.")]
        [DefaultValue(false)]
        public bool tinkererSellsToolbox;
    }
}
