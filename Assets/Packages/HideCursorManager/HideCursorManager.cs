using UnityEngine;

public class HideCursorManager : SingletonMonoBehaviour<HideCursorManager>
{
    #region Field

    public float showAmountPx = 1;

    public float hideTimeSec = 2;

    private float lastMoveTime;

    private Vector3 lastMousePosition;

    #endregion Field

    #region Method

    protected virtual void Start()
    {
        this.lastMoveTime = Time.timeSinceLevelLoad;
    }

    protected virtual void Update()
    {
        Vector3 move = Input.mousePosition - this.lastMousePosition;
        this.lastMousePosition = Input.mousePosition;

        if (move.magnitude > this.showAmountPx)
        {
            this.lastMoveTime = Time.timeSinceLevelLoad;
        }

        Cursor.visible = Time.timeSinceLevelLoad - this.lastMoveTime < this.hideTimeSec;
    }

    protected virtual void OnDisable()
    {
        Cursor.visible = true;
    }

    #endregion Method
}