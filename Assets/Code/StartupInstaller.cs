using Code.CommonClear;
using Code.TestWindow.Mono.MainCanvas;
using Code.UI;
using Code.Units;
using Morpeh;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;
using TestWindowModule = Code.TestWindow.TestWindowModule;

namespace Code
{
    public class StartupInstaller : MonoInstaller
    {
        [SerializeField] private MainCanvasMono _mainCanvasMono;
        
        public override void InstallBindings()
        {
            var world = World.Default;
            
            Container.BindInstance(world);

            Container.Bind<MainCanvasMono>().FromComponentInNewPrefab(_mainCanvasMono).AsSingle();
            
            UnitModule.Install(Container);
            UiModule.Install(Container);
            TestWindowModule.Install(Container);
            CommonClearModule.Install(Container);
        }
    }
}
