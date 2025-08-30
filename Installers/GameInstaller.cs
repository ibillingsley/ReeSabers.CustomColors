using ReeSabers.CustomColors.AffinityPatches;
using Zenject;

namespace ReeSabers.CustomColors.Installers
{
	internal class GameInstaller : Installer
	{
		public override void InstallBindings()
		{
			Container.BindInterfacesTo<ReeSabersPatches>().AsSingle();
		}
	}
}
