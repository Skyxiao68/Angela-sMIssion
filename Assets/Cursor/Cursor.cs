//Cursor image change and script learn on Bilibili by  [Unity�̳�][ָ��]Unity���л�ָ�룬�任�����ʽ https://www.bilibili.com/video/BV1oh411P7FW/?spm_id_from=333.337.search-card.all.click&vd_source=735fcdc7dec66ac9bffaf8eac1a52072


using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [Header("Cursor Settings")]
    public Texture2D defaultCursor;
    public Texture2D interactCursor;
    public Texture2D attackCursor;
    public Vector2 hotspot = Vector2.zero; 

    void Start()
    {
        SetCursor(defaultCursor);

       
        Cursor.visible = true;
    }

    public void SetCursor(Texture2D cursorTexture)
    {
        Cursor.SetCursor(cursorTexture, hotspot, CursorMode.Auto);
    }

    // Example usage:
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            SetCursor(attackCursor);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            SetCursor(interactCursor);
        }
    }

    
    void OnDestroy()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}