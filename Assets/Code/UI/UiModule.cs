using Code.UI.GameInterfaceWindow.Systems;
using Zenject;

namespace Code.UI
{
    public class UiModule : Installer<UiModule>
    {
        public override void InstallBindings()
        {
            Container.Bind<ShowCounterSystem>().AsSingle();
            Container.Bind<TimeScaleSystem>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<UiSystemsExecutor>().AsSingle().NonLazy();
        }
    }
}