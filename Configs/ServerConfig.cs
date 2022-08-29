﻿using System.ComponentModel;
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

        [Label("Celestial Magnet always available")]
        [Tooltip("Allows the Celestial Magnet to always be available.")]
        [DefaultValue(false)]
        public bool celestialMagnetAlwaysAvailable;

        [Label("Triple cost for added items")]
        [Tooltip("Items that will be made available by the mod will have their cost tripled.\n" +
                 "However, if the vanilla shop decides to add the item in question, they will be sold at normal price.")]
        [DefaultValue(true)]
        public bool tripleCost;

        [Label("Merchant sells Music Box instead")]
        [Tooltip("The Merchant (not Travelling) will sell the Music Box instead of the Wizard.")]
        [DefaultValue(false)]
        public bool merchantSellsMusicBox;

        [Label("Goblin Tinkerer sells Toolbox")]
        [Tooltip("The Goblin Tinkerer will sell the Toolbox.")]
        [DefaultValue(false)]
        public bool tinkererSellsToolbox;
    }
}