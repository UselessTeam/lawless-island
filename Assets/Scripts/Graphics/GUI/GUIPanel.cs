using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIPanel : MonoBehaviour
{
    private int xMin, xMax, y;
    private int? targetX, targetY;
    [SerializeField]
    private GUISelector selector = null;
    [SerializeField]
    private RectTransform subpanel = null;
    [SerializeField]
    private GameObject selectablePrefab = null;
    private GUISelectable at = null;

    public int width, height;
    public List<GUISelectable> selectables = new List<GUISelectable>();

    void Start()
    {
        for(int x = 0; x < width; x ++) {
            GameObject selectableGameObject = Instantiate(selectablePrefab, subpanel);
            RectTransform rect = (RectTransform)selectableGameObject.transform;
            rect.anchorMin = new Vector2((float)(x) / width, rect.anchorMin.y);
            rect.anchorMax = new Vector2((x + 1f) / width, rect.anchorMax.y);
            rect.offsetMin = new Vector2(12, 12);
            rect.offsetMax = new Vector2(-12, -12);
            GUISelectable selectable = selectableGameObject.GetComponent<GUISelectable>();
            selectable.xMin = x;
            selectable.xMax = x;
            selectable.y = 0;
            selectables.Add(selectable);
        }
        MoveSelector(selectables[0]);
    }

    void Update() {
        if(Input.GetButtonDown("Left")) {
            targetX = xMin - 1;
        }
        if(Input.GetButtonDown("Right")) {
            targetX = xMax + 1;
        }
        if(Input.GetButtonDown("Up")) {
            targetY--;
        }
        if(Input.GetButtonDown("Down")) {
            targetY++;
        }
        if(targetX != null || targetY != null) {
            Reposition();
        }
    }

    void Reposition() {
        int x = targetX.HasValue ? (width + targetX.Value) % width : xMin;
        int y = targetY.HasValue ? (height + targetY.Value) % height : this.y;
        foreach(GUISelectable selectable in selectables) {
            if(selectable.IsIn(x, y)) {
                if(targetX != null) {
                    xMin = selectable.xMin;
                    xMax = selectable.xMax;
                }
                if(targetY != null) {
                    y = selectable.y;
                }
                MoveSelector(selectable);
                break;
            }
        }
        targetX = null;
        targetY = null;
    }

    void MoveSelector(GUISelectable selectable) {
        selector.Select((RectTransform)selectable.transform);
    }
}
