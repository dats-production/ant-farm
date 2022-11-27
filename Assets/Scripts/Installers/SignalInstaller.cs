using Signals;
using Zenject;

namespace Installers
{
    public class SignalInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.DeclareSignal<SignalSelect>();
            Container.DeclareSignal<SignalGather>();
            Container.DeclareSignal<SignalSetPosition>();
        }
    }
}