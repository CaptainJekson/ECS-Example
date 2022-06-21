using UnityEngine;

namespace Code.Installer
{
    public class GameExecutor : MonoBehaviour
    {
        private RootSystems _systems;
        
        private void Start()
        {
            _systems = new RootSystems(Contexts.sharedInstance);
            _systems.Initialize();
        }

        private void Update()
        {
            _systems.Execute();
        }
    }
}