using Harmony;
using RimWorld;
using System;
using System.Reflection;
using UnityEngine;
using Verse;

namespace MapSizes
{
	[StaticConstructorOnStartup]
	class ModEntry
	{
		static ModEntry()
		{
			Log.Message("MoreMapSizes loaded");

			Type type = typeof(Dialog_AdvancedGameConfig);
			FieldInfo field = type.GetField("MapSizes", BindingFlags.NonPublic | BindingFlags.Static);

			int[] newSizes = new int[] { 25, 50, 75, 100, 125, 150, 175, 200, 225, 250, 275, 300, 325, 350, 375, 400, 425, 450, 475, 500, 525, 550, 575,
				600, 625, 650, 675, 700, 725, 750, 775, 800, 825, 850, 875, 900, 925, 950, 975, 1000, 1025, 1050, 1075, 1100, 1125, 1150, 1175, 2000 };

			field.SetValue(null, newSizes);

			HarmonyInstance harmony = HarmonyInstance.Create("Ilyaki.MoreMapSizes");
			harmony.Patch(type.GetMethod("get_InitialSize"), new HarmonyMethod(typeof(ModEntry), "Get_InitialSize_Patcher"));
		}

		public static bool Get_InitialSize_Patcher(ref Vector2 __result)
		{
			//Default is 700, 500
			__result =  new Vector2(1115, 500);
			return false;
		}
	}
}
