using Code.CommonClear.Systems;
using Zenject;

namespace Code.CommonClear
{
    public class CommonClearModule : Installer<CommonClearModule>
    {
        public override void InstallBindings()
        {
            Container.Bind<DestroyEntitySystem>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<CommonClearExecutor>().AsSingle().NonLazy();
        }
    }
}