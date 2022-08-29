using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TravellingMerchantMoreItems.GlobalNPCs
{
    public class TravellingMerchantShop : GlobalNPC
    {
        public override bool AppliesToEntity(NPC entity, bool lateInstantiation)
        {
            return entity.type == NPCID.TravellingMerchant;
        }

        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            if (type != NPCID.TravellingMerchant) return;

            AddItemWithChecks(shop.item, ref nextSlot, ItemID.Stopwatch);
            AddItemWithChecks(shop.item, ref nextSlot, ItemID.LifeformAnalyzer);
            AddItemWithChecks(shop.item, ref nextSlot, ItemID.DPSMeter);
            AddItemWithChecks(shop.item, ref nextSlot, ItemID.ActuationAccessory);
            AddItemWithChecks(shop.item, ref nextSlot, ItemID.PortableCementMixer);
            AddItemWithChecks(shop.item, ref nextSlot, ItemID.PaintSprayer);
            AddItemWithChecks(shop.item, ref nextSlot, ItemID.ExtendoGrip);
            AddItemWithChecks(shop.item, ref nextSlot, ItemID.BrickLayer);
            if (TravellingMerchantMoreItems.ServerConfig.ammoBoxAlwaysAvailable) AddItemWithChecks(shop.item, ref nextSlot, ItemID.AmmoBox);
            if (TravellingMerchantMoreItems.ServerConfig.celestialMagnetAlwaysAvailable) AddItemWithChecks(shop.item, ref nextSlot, ItemID.CelestialMagnet);
        }

        private void AddItemWithChecks(Item[] shop, ref int nextSlot, int itemID)
        {
            foreach (Item shopItem in shop) if (shopItem.type == itemID) return;

            Item newShopItem = new Item(itemID);
            if (TravellingMerchantMoreItems.ServerConfig.tripleCost)
            {
                Main.LocalPlayer.GetItemExpectedPrice(newShopItem, out int _, out int newShopItemValue);
                newShopItem.shopCustomPrice = newShopItemValue * 3;
            }
            shop[nextSlot++] = newShopItem;
        }
    }
}