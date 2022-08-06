using Code.TestWindow.Components;
using Code.TestWindow.Mono;
using Code.TestWindow.Mono.MainCanvas;
using Code.UI.Configs;
using Morpeh;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Code.TestWindow.Systems
{
    public class TestWindowCreateSystem : ISystem
    {
        public World World { get; set; }

        private Filter _filter;
        private UiReferencesConfig _uiReferencesConfig;
        private MainCanvasMono _mainCanvasMono;

        public TestWindowCreateSystem(UiReferencesConfig uiReferencesConfig, MainCanvasMono mainCanvasMono)
        {
            _uiReferencesConfig = uiReferencesConfig;
            _mainCanvasMono = mainCanvasMono;
        }

        public void OnAwake()
        {
            _filter = World.Filter.With<TestWindowComponent>().With<TestWindowCreateComponent>();

            var entity = World.CreateEntity();
            entity.SetComponent(new TestWindowComponent());
            entity.SetComponent(new TestWindowCreateComponent());
        }

        public void OnUpdate(float deltaTime)
        {
            //Логика создания окна

            foreach (var entity in _filter)
            {
                Addressables.LoadAssetAsync<GameObject>(_uiReferencesConfig.TestWindow).Completed += handle =>
                {
                    if (entity.IsNullOrDisposed()) //На случай если entity удалиться раньше чем произойдёт загрузка из бандлов
                    {
                        Object.Destroy(handle.Result);
                        return;
                    }
                    
                    var gameObject = Object.Instantiate(handle.Result, _mainCanvasMono.transform);
                    var testWindow = gameObject.GetComponent<TestWindowMono>();

                    entity.SetComponent(new TestWindowDataComponent
                    {
                        gameObject = gameObject,
                        provider = testWindow,
                    });
                    entity.SetComponent(new TestWindowInitializeComponent());

                    Debug.Log("Test Window loaded");
                };

                entity.RemoveComponent<TestWindowCreateComponent>();
            }
        }

        public void Dispose()
        {
            _filter = null;
            _uiReferencesConfig = null;
            _mainCanvasMono = null;
        }
    }
}