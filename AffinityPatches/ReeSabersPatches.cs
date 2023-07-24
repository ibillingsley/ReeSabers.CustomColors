using ReeSabers.Sabers;
using ReeSabers.UI;
using SiraUtil.Affinity;
using System;
using UnityEngine;

namespace ReeSabers.CustomColors.AffinityPatches
{
	public class ReeSabersPatches : IAffinity
	{
		private ColorManager _colorManager;
		public ReeSabersPatches(ColorManager colorManager)
		{
			Plugin.Log.Info("Hi");
			_colorManager = colorManager;
		}

		[AffinityPrefix]
		[AffinityPatch(typeof(ColorController), "Update")]
		public bool BlurSaberPatch(ColorController __instance, ColorController.Settings ____settings)
		{
			var saberType = __instance.transform.parent.parent.parent.gameObject.name == "RightSaber" ? SaberType.SaberB : SaberType.SaberA;
			var color = _colorManager.ColorForSaberType(saberType);
			float h = 0f;
			float s = 0f;
			float v = 0f; //TODO: Find a way to apply this. Currently setting brightness above 0 makes it glow a ton ):
			RGBToHSV(color, out h, out s, out v);
			var rad = (h * Mathf.Deg2Rad) / 6.28319f;
			__instance.HsbTransform.SetValue(new HsbTransform(rad, s, 0f, ColorTransformType.HueOverride), __instance);
			return false;
		}

		public static void RGBToHSV(Color rgb, out float hOut, out float sOut, out float vOut)
		{
			double delta, min;
			double h = 0, s, v;

			min = Math.Min(Math.Min(rgb.r, rgb.g), rgb.b);
			v = Math.Max(Math.Max(rgb.r, rgb.g), rgb.b);
			delta = v - min;

			if (v == 0.0)
				s = 0;
			else
				s = delta / v;

			if (s == 0)
				h = 0.0;

			else
			{
				if (rgb.r == v)
					h = (rgb.g - rgb.b) / delta;
				else if (rgb.g == v)
					h = 2 + (rgb.b - rgb.r) / delta;
				else if (rgb.b == v)
					h = 4 + (rgb.r - rgb.g) / delta;

				h *= 60;

				if (h < 0.0)
					h = h + 360;
			}

			hOut = (float)h;
			sOut = (float)s;
			vOut = (float)(v/255f);
		}
	}
}