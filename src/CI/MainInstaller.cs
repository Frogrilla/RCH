using ComputerInterface.Interfaces;
using Zenject;

namespace RCH.CI
{
    internal class MainInstaller : Installer
    {
        public override void InstallBindings()
        {
            base.Container.Bind<IComputerModEntry>().To<RchEntry>().AsSingle();
        }
    }
}
