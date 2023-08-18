using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Helpers.Shops;

namespace TravellingMerchantMoreItems.GlobalNPCs
{
    public class TinkererShop : GlobalNPC
    {
        public override bool AppliesToEntity(NPC entity, bool lateInstantiation)
        {
            return entity.type == NPCID.GoblinTinkerer;
        }

        public override void ModifyActiveShop(NPC npc, string shopName, Item[] items)
        {
            if (npc.type != NPCID.GoblinTinkerer) return;

            if (TravellingMerchantMoreItems.ServerConfig.tinkererSellsToolbox)
            {
                Main.LocalPlayer.GetItemExpectedPrice(new Item(ItemID.Toolbox), out long _, out long price);
                AddItemWithChecks(items, ItemID.Toolbox, (int)price * TravellingMerchantMoreItems.ServerConfig.multiplyCostValue);
            }
        }

        private void AddItemWithChecks(Item[] shop, int itemID, int? customCost = null)
        {
            foreach (Item shopItem in shop)
            {
                if (shopItem != null && shopItem.type == itemID) return;
            }

            Item newShopItem = new(itemID);
            newShopItem.shopCustomPrice = customCost;
            shop[DetectNextEmptySlot(shop)] = newShopItem;
        }
    }
}
