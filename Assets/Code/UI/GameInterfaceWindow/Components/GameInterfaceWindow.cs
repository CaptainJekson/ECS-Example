using Morpeh;
using TMPro;
using Unity.IL2CPP.CompilerServices;
using UnityEngine.UI;

namespace Code.UI.GameInterfaceWindow.Components
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [System.Serializable]
    public struct GameInterfaceWindow : IComponent
    {
        public TextMeshProUGUI redCountText;    
        public TextMeshProUGUI greenCountText;
        public TextMeshProUGUI timeScaleText;
        public float stepTimeScale;
        public Button increaseTimeButton;
        public Button decreaseTimeButton;
    }
}