using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.TestWindow.Mono
{
    public class TestWindowMono : MonoBehaviour
    {
        [SerializeField] public TextMeshProUGUI messageText;
        [SerializeField] public Button sendButton;
        [SerializeField] public Button[] closeButtons;
    }
}
