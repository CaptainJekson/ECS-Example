using System;
using Morpeh;
using UnityEngine;
using Zenject;

namespace Code
{
    public abstract class Executor : IInitializable, ITickable, IFixedTickable, ILateTickable, IDisposable
    {
        private readonly World _world;
        protected readonly SystemsGroup _initializers;
        protected readonly SystemsGroup _updateSystems;
        protected readonly SystemsGroup _fixedUpdateSystems;
        protected readonly SystemsGroup _lateUpdateSystems;

        protected Executor(World world)
        {
            _world = world;
            
            _initializers = _world.CreateSystemsGroup();
            _updateSystems = _world.CreateSystemsGroup();
            _fixedUpdateSystems = _world.CreateSystemsGroup();
            _lateUpdateSystems = _world.CreateSystemsGroup();
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