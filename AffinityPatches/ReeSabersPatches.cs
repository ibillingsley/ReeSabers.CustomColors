using SiraUtil.Affinity;

namespace ReeSabers.CustomColors.AffinityPatches
{
	public class ReeSabersPatches : IAffinity
	{
		[AffinityPrefix]
		[AffinityPatch(typeof(HsbTransform), "HsbTransform", AffinityMethodType.Constructor, null, typeof(ColorTransformType), typeof(float), typeof(float), typeof(float), typeof(float))]
		public void HsbTransformPatch(ref ColorTransformType type)
		{
			if (type == ColorTransformType.NotesColor)
				type = ColorTransformType.HueShift;
		}
	}
}
