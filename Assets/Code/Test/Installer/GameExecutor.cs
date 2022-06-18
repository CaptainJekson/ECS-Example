using System;
using UnityEngine;

namespace Code.Test.Installer
{
    public class GameExecutor : MonoBehaviour
    {
        private RootSystems _systems;
        //private LogHealthSystem _logHealthSystem;
        
        private void Start()
        {
            _systems = new RootSystems(Contexts.sharedInstance);
            _systems.Initialize();
            
            // var context = Contexts.sharedInstance;
            // var entity = context.game.CreateEntity();
            // entity.AddHealth(100);
            //
            // _logHealthSystem = new LogHealthSystem(context);
            // //_logHealthSystem.Execute();
        }

        private void Update()
        {
            //_logHealthSystem.Execute();
            _systems.Execute();
        }
    }
}