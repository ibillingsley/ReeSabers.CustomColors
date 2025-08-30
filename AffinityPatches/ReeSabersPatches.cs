using SiraUtil.Affinity;
using UnityEngine;

namespace ReeSabers.CustomColors.AffinityPatches
{
	public class ReeSabersPatches : IAffinity
	{
		[AffinityPrefix]
		[AffinityPatch(typeof(ColorController), nameof(ColorController.Update))]
		public bool ColorControllerPatch(ColorController __instance)
		{
			if (__instance._isDirty && __instance._settings.type == ColorTransformType.NotesColor)
			{
				Color.RGBToHSV(ColorController.GetNotesColor(__instance._saberType, __instance._settings.colorSource), out var H, out var S, out var V);
				__instance.HsbTransform.SetValue(new HsbTransform(ColorTransformType.HueShift, H, S, V, __instance._settings.fakeGlowMultiplier), __instance);
				__instance._isDirty = false;
				return false;
			}
			return true;
		}
	}
}
