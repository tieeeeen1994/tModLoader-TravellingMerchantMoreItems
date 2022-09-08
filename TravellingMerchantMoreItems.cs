using Terraria;
using Terraria.ModLoader;
using TravellingMerchantMoreItems.Configs;

namespace TravellingMerchantMoreItems
{
	public class TravellingMerchantMoreItems : Mod
	{
		public static ServerConfig ServerConfig => ModContent.GetInstance<ServerConfig>();

		public static bool AnyMechBossDowned => NPC.downedMechBoss1 || NPC.downedMechBoss2 || NPC.downedMechBoss3;
    }
}