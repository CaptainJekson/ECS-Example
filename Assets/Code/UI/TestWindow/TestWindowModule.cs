using Code.UI.Configs;
using Zenject;

namespace Code.UI.TestWindow
{
    public class TestWindowModule : Installer<TestWindowModule>
    {
        public override void InstallBindings()
        {
            Container.Bind<UiReferencesConfig>().FromScriptableObjectResource("Configs/UI/UiReferencesConfig").AsSingle();
            
            Container.BindInterfacesAndSelfTo<TestWindowExecutor>().AsSingle().NonLazy();
        }
    }
}