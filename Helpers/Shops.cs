using Terraria;

namespace Helpers
{
    public static class Shops
    {
        public static int DetectNextEmptySlot(Item[] items)
        {
            for (int i = 0; i < items.Length; i++)
            {
                Item item = items[i];
                if (item == null || item.IsAir) return i;
            }

            return -1; // Should be unreachable... Mod will crash if it reaches here but that means something is wrong.
        }
    }
}