using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TravellingMerchantMoreItems.GlobalNPCs
{
    public class MarchantShop : GlobalNPC
    {
        public override bool AppliesToEntity(NPC entity, bool lateInstantiation)
        {
            return entity.type == NPCID.Merchant;
        }

        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            if (!TravellingMerchantMoreItems.ServerConfig.merchantSellsMusicBox || type != NPCID.Merchant) return;

            AddItemWithChecks(shop.item, ref nextSlot, ItemID.MusicBox, false);
            if (TravellingMerchantMoreItems.ServerConfig.merchantSellsUltraBrightTorch) AddItemWithChecks(shop.item, ref nextSlot, ItemID.UltrabrightTorch, true);
        }

        private void AddItemWithChecks(Item[] shop, ref int nextSlot, int itemID, bool multiplyCost)
        {
            foreach (Item shopItem in shop) if (shopItem.type == itemID) return;

            Item newShopItem = new Item(itemID);
            if (TravellingMerchantMoreItems.ServerConfig.multiplyCost && multiplyCost)
            {
                Main.LocalPlayer.GetItemExpectedPrice(newShopItem, out int _, out int newShopItemValue);
                newShopItem.shopCustomPrice = newShopItemValue * TravellingMerchantMoreItems.ServerConfig.multiplyCostValue;
            }
            shop[nextSlot++] = newShopItem;
        }
    }
}
