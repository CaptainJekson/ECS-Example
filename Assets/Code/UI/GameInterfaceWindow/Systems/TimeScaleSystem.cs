using System.Globalization;
using Code.UI.GameInterfaceWindow.EventComponents;
using Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Code.UI.GameInterfaceWindow.Systems
{
    public sealed class TimeScaleSystem : ISystem
    {
        private Filter _filterTimeIncrease;
        private Filter _filterTimeDecrease;
        
        public World World { get; set; }
        
        public void OnAwake()
        {
            _filterTimeIncrease = World.Filter.With<TimeIncreaseEvent>().With<Components.GameInterfaceWindow>();
            _filterTimeDecrease = World.Filter.With<TimeDecreaseEvent>().With<Components.GameInterfaceWindow>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filterTimeIncrease)
            {
                ref var window = ref entity.GetComponent<Components.GameInterfaceWindow>();
                Time.timeScale += window.stepTimeScale;
                window.timeScaleText.text = Time.timeScale.ToString(CultureInfo.InvariantCulture);
                entity.RemoveComponent<TimeIncreaseEvent>();
            }
            
            foreach (var entity in _filterTimeDecrease)
            {
                ref var window = ref entity.GetComponent<Components.GameInterfaceWindow>();
                if (Time.timeScale - window.stepTimeScale > 0)
                {
                    Time.timeScale -= window.stepTimeScale;
                }
                window.timeScaleText.text = Time.timeScale.ToString(CultureInfo.InvariantCulture);
                entity.RemoveComponent<TimeDecreaseEvent>();
            }
        }

        public void Dispose()
        {
            _filterTimeIncrease = null;
            _filterTimeDecrease = null;
        }
    }
}