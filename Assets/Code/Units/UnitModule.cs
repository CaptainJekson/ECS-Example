using Code.Units.BallUnit.Systems;
using Code.Units.Utility;
using Zenject;

namespace Code.Units
{
    public class UnitModule : Installer<UnitModule>
    {
        public override void InstallBindings()
        {
            Container.Bind<CreateBallsInitializer>().AsSingle();
            Container.Bind<BallsCollisionSystem>().AsSingle();
            Container.Bind<BallDestroySystem>().AsSingle();
            Container.Bind<BallsMoveSystem>().AsSingle();
            Container.Bind<CollisionPool>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<BallsSystemsExecutor>().AsSingle().NonLazy();
        }
    }
}