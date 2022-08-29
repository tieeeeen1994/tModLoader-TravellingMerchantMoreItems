using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TravellingMerchantMoreItems.GlobalNPCs
{
    public class WizardShop : GlobalNPC
    {
        public override bool AppliesToEntity(NPC entity, bool lateInstantiation)
        {
            return entity.type == NPCID.Wizard;
        }

        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            if (!TravellingMerchantMoreItems.ServerConfig.merchantSellsMusicBox || type != NPCID.Wizard) return;

            RemoveItemWithChecks(shop.item, ItemID.MusicBox);
        }

        private void RemoveItemWithChecks(Item[] shop, int itemID)
        {
            int? removedItemIndex = null;

            for (int i = 0; i < shop.Length; i++)
            {
                if (shop[i].type == itemID)
                {
                    removedItemIndex = i;
                    break;
                }
            }

            if (removedItemIndex == null) return;
            else
            {
                for (int i = (int)removedItemIndex; i < shop.Length - 1; i++) shop[i] = shop[i + 1];
                shop[^1] = new Item(ItemID.None);
            }
        }
    }
}
