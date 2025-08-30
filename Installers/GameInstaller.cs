using ReeSabers.NotesColorShift.AffinityPatches;
using Zenject;

namespace ReeSabers.NotesColorShift.Installers
{
	internal class GameInstaller : Installer
	{
		public override void InstallBindings()
		{
			Container.BindInterfacesTo<ReeSabersPatches>().AsSingle();
		}
	}
}
