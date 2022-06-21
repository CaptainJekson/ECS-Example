using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Mono
{
    public class GameInterfaceWindow : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _redCountText;
        [SerializeField] private TextMeshProUGUI _greenCountText;
        [SerializeField] private TextMeshProUGUI _timeScaleText;
        [SerializeField] private Button _increaseTimeButton;
        [SerializeField] private Button _decreaseTimeButton;
    }
}