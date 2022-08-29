using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TravellingMerchantMoreItems.GlobalNPCs
{
    public class TinkererShop : GlobalNPC
    {
        public override bool AppliesToEntity(NPC entity, bool lateInstantiation)
        {
            return entity.type == NPCID.GoblinTinkerer;
        }

        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            if (!TravellingMerchantMoreItems.ServerConfig.merchantSellsMusicBox || type != NPCID.GoblinTinkerer) return;

            Main.LocalPlayer.GetItemExpectedPrice(new Item(ItemID.Toolbox), out int _, out int price);
            AddItemWithChecks(shop.item, ref nextSlot, ItemID.Toolbox, price * 3);
        }

        private void AddItemWithChecks(Item[] shop, ref int nextSlot, int itemID, int? customCost = null)
        {
            foreach (Item shopItem in shop)
            {
                if (shopItem.type == itemID) return;
            }

            Item newShopItem = new Item(itemID);
            newShopItem.shopCustomPrice = customCost;
            shop[nextSlot++] = newShopItem;
        }
    }
}
