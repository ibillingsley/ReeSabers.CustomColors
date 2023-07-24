using ReeSabers.CustomColors.AffinityPatches;
using Zenject;

namespace ReeSabers.CustomColors.Installers
{
	internal class ReeSabersCustomColorsGameInstaller : Installer
	{
		public override void InstallBindings()
		{
			Container.BindInterfacesTo<ReeSabersPatches>().AsSingle();
		}
	}
}
