using UnityEngine;
using UnityEngine.UI;

public class GUISelector : MonoBehaviour
{

    public RectTransform rectTransform = null;

    void Awake() {
        rectTransform = (RectTransform)transform;
    }

    void Update()
    {
        
    }

    public void Select(RectTransform selected) {
        rectTransform.anchorMin = selected.anchorMin;
        rectTransform.anchorMax = selected.anchorMax;
        rectTransform.offsetMin = selected.offsetMin;
        rectTransform.offsetMax = selected.offsetMax;
    }
}
