using UnityEngine;

public class MouseController : MonoBehaviour
{
    public bool isCursorVisible = true;

    private void Start()
    {
        // Mostrar el cursor al inicio
        ShowCursor();
    }

    private void ShowCursor()
    {
        if (isCursorVisible)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            isCursorVisible = true;
        } else {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            isCursorVisible = false;
        }
    }

}