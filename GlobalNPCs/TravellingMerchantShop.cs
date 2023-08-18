using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Helpers.Shops;

namespace TravellingMerchantMoreItems.GlobalNPCs
{
    public class TravellingMerchantShop : GlobalNPC
    {
        public override bool AppliesToEntity(NPC entity, bool lateInstantiation)
        {
            return entity.type == NPCID.TravellingMerchant;
        }

        public override void ModifyActiveShop(NPC npc, string shopName, Item[] items)
        {
            if (npc.type != NPCID.TravellingMerchant) return;

            AddItemWithChecks(items, ItemID.Stopwatch);
            AddItemWithChecks(items, ItemID.Stopwatch);
            AddItemWithChecks(items, ItemID.LifeformAnalyzer);
            AddItemWithChecks(items, ItemID.DPSMeter);
            AddItemWithChecks(items, ItemID.ActuationAccessory);
            AddItemWithChecks(items, ItemID.PortableCementMixer);
            AddItemWithChecks(items, ItemID.PaintSprayer);
            AddItemWithChecks(items, ItemID.ExtendoGrip);
            AddItemWithChecks(items, ItemID.BrickLayer);
            if (TravellingMerchantMoreItems.ServerConfig.ammoBoxAlwaysAvailable) AddItemWithChecks(items, ItemID.AmmoBox);
            if (TravellingMerchantMoreItems.ServerConfig.sittingDuckAlwaysAvailable) AddItemWithChecks(items, ItemID.SittingDucksFishingRod);
            if (TravellingMerchantMoreItems.ServerConfig.ultraBrightTorchAlwaysAvailable) AddItemWithChecks(items, ItemID.UltrabrightTorch);
            if (TravellingMerchantMoreItems.ServerConfig.functionalAccessoriesAlwaysAvailable)
            {
                AddItemWithChecks(items, ItemID.CelestialMagnet);
                AddItemWithChecks(items, ItemID.YellowCounterweight);
                AddItemWithChecks(items, ItemID.BlackCounterweight);
            }
            if (TravellingMerchantMoreItems.ServerConfig.functionalWeaponsAlwaysAvailable)
            {
                AddItemWithChecks(items, ItemID.Katana);
                if (NPC.downedBoss1) AddItemWithChecks(items, ItemID.Code1);
                if (TravellingMerchantMoreItems.AnyMechBossDowned) AddItemWithChecks(items, ItemID.Code2);
                if (WorldGen.shadowOrbSmashed) AddItemWithChecks(items, ItemID.Revolver);
                if (NPC.downedPlantBoss) AddItemWithChecks(items, ItemID.PulseBow);
                if (NPC.downedPlantBoss) AddItemWithChecks(items, ItemID.PulseBow);
                if (Main.hardMode)
                {
                    AddItemWithChecks(items, ItemID.ZapinatorOrange);
                    AddItemWithChecks(items, ItemID.BouncingShield);
                    AddItemWithChecks(items, ItemID.Gatligator);
                }
                else if (NPC.downedBoss1 || NPC.downedBoss2 || NPC.downedBoss3 || NPC.downedQueenBee) AddItemWithChecks(items, ItemID.ZapinatorGray);
            }
        }

        private void AddItemWithChecks(Item[] shop, int itemID)
        {
            foreach (Item shopItem in shop) if (shopItem != null && shopItem.type == itemID) return;

            Item newShopItem = new(itemID);
            if (TravellingMerchantMoreItems.ServerConfig.multiplyCost)
            {
                Main.LocalPlayer.GetItemExpectedPrice(newShopItem, out long _, out long newShopItemValue);
                newShopItem.shopCustomPrice = (int)newShopItemValue * TravellingMerchantMoreItems.ServerConfig.multiplyCostValue;
            }
            shop[DetectNextEmptySlot(shop)] = newShopItem;
        }
    }
}