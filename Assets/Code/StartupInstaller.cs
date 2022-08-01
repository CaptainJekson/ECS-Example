using Code.UI;
using Code.UI.TestWindow;
using Code.Units;
using Morpeh;
using Zenject;

namespace Code
{
    public class StartupInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            var world = World.Default;
            
            Container.BindInstance(world);
            
            UnitModule.Install(Container);
            TestWindowModule.Install(Container);
            UiModule.Install(Container);
        }
    }
}
