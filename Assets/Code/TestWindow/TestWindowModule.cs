using Code.TestWindow.Systems;
using Code.UI.Configs;
using Zenject;

namespace Code.TestWindow
{
    public class TestWindowModule : Installer<TestWindowModule>
    {
        public override void InstallBindings()
        {
            Container.Bind<UiReferencesConfig>().FromScriptableObjectResource("Configs/UI/UiReferencesConfig")
                .AsSingle();

            Container.Bind<TestWindowCreateSystem>().AsSingle();
            Container.Bind<TestWindowInitializeSystem>().AsSingle();
            Container.Bind<TestWindowInitializeFinishedSystem>().AsSingle();
            Container.Bind<TestWindowSendPressedSystem>().AsSingle();
            Container.Bind<TestWindowCloseSystem>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<TestWindowExecutor>().AsSingle().NonLazy();
        }
    }
}