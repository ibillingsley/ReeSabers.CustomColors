using IPA;
using ReeSabers.NotesColorShift.Installers;
using SiraUtil.Zenject;
using IPALogger = IPA.Logging.Logger;

namespace ReeSabers.NotesColorShift
{
	[Plugin(RuntimeOptions.SingleStartInit)]
	public class Plugin
	{
		internal static Plugin Instance { get; private set; }
		internal static IPALogger Log { get; private set; }

		[Init]
		public Plugin(IPALogger logger, Zenjector zenjector)
		{
			Instance = this;
			Log = logger;
			zenjector.Install<GameInstaller>(Location.Player);
			zenjector.Install<GameInstaller>(Location.Menu);
		}
	}
}
