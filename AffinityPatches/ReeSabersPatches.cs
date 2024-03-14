using ReeSabers.Sabers;
using ReeSabers.UI;
using SiraUtil.Affinity;
using System;
using UnityEngine;

namespace ReeSabers.CustomColors.AffinityPatches
{
	public class ReeSabersPatches : IAffinity
	{
		[AffinityPrefix]
		[AffinityPatch(typeof(ColorController), "Update")]
		public bool BlurSaberPatch(ColorController __instance)
		{
			if (__instance._isDirty && __instance._settings.type == ColorTransformType.NotesColor)
			{
				Color.RGBToHSV((__instance._saberType == SaberType.SaberA) ? PluginConfig.LeftNotesColor.Value : PluginConfig.RightNotesColor.Value, out var H, out var S, out var V);
				__instance.HsbTransform.SetValue(new HsbTransform(ColorTransformType.HueShift, H, S, V, __instance._settings.fakeGlowMultiplier), __instance);
				__instance._isDirty = false;
				return false;
			}
			return true;
		}
	}
}
