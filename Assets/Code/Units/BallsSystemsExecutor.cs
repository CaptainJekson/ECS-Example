using Code.Units.BallUnit.Systems;
using Morpeh;

namespace Code.Units
{
    public sealed class BallsSystemsExecutor : Executor
    {
        public BallsSystemsExecutor(World world, CreateBallsInitializer createBallsInitializer,
            BallsCollisionSystem ballsCollisionSystem, BallDestroySystem ballDestroySystem,
            BallsMoveSystem ballsMoveSystem) : base(world)
        {
            _initializers.AddInitializer(createBallsInitializer);         
                                                  
            _updateSystems.AddSystem(ballsCollisionSystem);   
            _updateSystems.AddSystem(ballDestroySystem);      
                                                  
            _fixedUpdateSystems.AddSystem(ballsMoveSystem);   
        }
    }
}