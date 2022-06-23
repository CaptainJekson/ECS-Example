using System;
using Code.Units.BallUnit.Systems;
using Morpeh;
using UnityEngine;
using Zenject;

namespace Code.Units
{
    public class BallsSystemsExecutor : IInitializable, ITickable, IFixedTickable, ILateTickable, IDisposable
    {
        private readonly World _world;
        private readonly SystemsGroup _initializers;
        private readonly SystemsGroup _updateSystems;
        private readonly SystemsGroup _fixedUpdateSystems;
        private readonly SystemsGroup _lateUpdateSystems;
        
        public BallsSystemsExecutor(World world, CreateBallsInitializer сreateBallsInitializer, 
            BallsCollisionSystem ballsCollisionSystem, BallDestroySystem ballDestroySystem, BallsMoveSystem ballsMoveSystem)
        {
            _world = world;
            
            _initializers = _world.CreateSystemsGroup();
            _updateSystems = _world.CreateSystemsGroup();
            _fixedUpdateSystems = _world.CreateSystemsGroup();
            _lateUpdateSystems = _world.CreateSystemsGroup();

            _initializers.AddInitializer(сreateBallsInitializer);

            _updateSystems.AddSystem(ballsCollisionSystem);
            _updateSystems.AddSystem(ballDestroySystem);
            
            _fixedUpdateSystems.AddSystem(ballsMoveSystem);
        }
        
        public void Initialize()
        {
            _initializers.Initialize();
            _updateSystems.Initialize();
            _fixedUpdateSystems.Initialize();
            _lateUpdateSystems.Initialize();
        }
        
        public void Tick()
        {
            _updateSystems.Update(Time.deltaTime);
        }

        public void FixedTick()
        {
            _fixedUpdateSystems.FixedUpdate(Time.fixedDeltaTime);
        }

        public void LateTick()
        {
            _lateUpdateSystems.LateUpdate(Time.deltaTime);
        }
        
        public void Dispose()
        {
            _initializers.Dispose();
            _updateSystems.Dispose();
            _fixedUpdateSystems.Dispose();
            _lateUpdateSystems.Dispose();
        }
    }
}