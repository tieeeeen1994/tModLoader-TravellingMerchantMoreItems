using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Helpers.Shops;

namespace TravellingMerchantMoreItems.GlobalNPCs
{
    public class MarchantShop : GlobalNPC
    {
        public override bool AppliesToEntity(NPC entity, bool lateInstantiation)
        {
            return entity.type == NPCID.Merchant;
        }

        public override void ModifyActiveShop(NPC npc, string shopName, Item[] items)
        {
            if (npc.type != NPCID.Merchant) return;

            if (TravellingMerchantMoreItems.ServerConfig.merchantSellsMusicBox) AddItemWithChecks(items, ItemID.MusicBox, false);
            if (TravellingMerchantMoreItems.ServerConfig.merchantSellsUltraBrightTorch) AddItemWithChecks(items, ItemID.UltrabrightTorch, true);
        }

        private void AddItemWithChecks(Item[] shop, int itemID, bool multiplyCost)
        {
            foreach (Item shopItem in shop) if (shopItem.type == itemID) return;

            Item newShopItem = new(itemID);
            if (TravellingMerchantMoreItems.ServerConfig.multiplyCost && multiplyCost)
            {
                Main.LocalPlayer.GetItemExpectedPrice(newShopItem, out long _, out long newShopItemValue);
                newShopItem.shopCustomPrice = (int)newShopItemValue * TravellingMerchantMoreItems.ServerConfig.multiplyCostValue;
            }
            shop[DetectNextEmptySlot(shop)] = newShopItem;
        }
    }
}
