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

            AddItemWithChecks(shop.item, ref nextSlot, ItemID.MusicBox);
        }

        private void AddItemWithChecks(Item[] shop, ref int nextSlot, int itemID)
        {
            foreach (Item shopItem in shop)
            {
                if (shopItem.type == itemID) return;
            }

            shop[nextSlot++] = new Item(itemID);
        }
    }
}
