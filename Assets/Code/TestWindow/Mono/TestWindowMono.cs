using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.TestWindow.Mono
{
    public class TestWindowMono : MonoBehaviour
    {
        [SerializeField] public TextMeshProUGUI messageText;
        [SerializeField] public Button sendButton;
        [SerializeField] public Button[] closeButtons;
    }
}
