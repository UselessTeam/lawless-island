using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUISelectable : MonoBehaviour
{
    public int xMin, xMax, y;

    public bool IsIn(int x, int y) {
        if(xMin <= x && x <= xMax && this.y == y) {
            return true;
        }
        return false;
    }
}
