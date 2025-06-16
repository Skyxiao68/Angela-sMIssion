//Cursor image change and script learn on Bilibili by  [Unity教程][指针]Unity中切换指针，变换鼠标样式 https://www.bilibili.com/video/BV1oh411P7FW/?spm_id_from=333.337.search-card.all.click&vd_source=735fcdc7dec66ac9bffaf8eac1a52072


using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [Header("Cursor Settings")]
    public Texture2D defaultCursor;
    public Texture2D interactCursor;
    public Texture2D attackCursor;
    public Vector2 hotspot = Vector2.zero;

    [Header("Cursor Size")]
    [Range(0.5f, 3f)] public float cursorSize = 1f;
    public bool maintainAspectRatio = true;

   
    private Texture2D activeCursor;
    private Texture2D scaledCursor;

    void Start()
    {
        SetCursor(defaultCursor);
        Cursor.visible = true;
    }

    void Update()
    {
        // Handle cursor changes
        if (Input.GetMouseButtonDown(1)) 
        {
            SetCursor(attackCursor);
        }
        else if (Input.GetKeyDown(KeyCode.E)) 
        {
            SetCursor(interactCursor);
        }
        else if (Input.GetMouseButtonDown(0)) 
        {
            SetCursor(defaultCursor);
        }
    }

    public void SetCursor(Texture2D cursorTexture)
    {
        
        if (cursorTexture == activeCursor) return;

        activeCursor = cursorTexture;

      
        if (Mathf.Approximately(cursorSize, 1f))
        {
           
            Cursor.SetCursor(activeCursor, hotspot, CursorMode.Auto);
        }
        else
        {
           
            scaledCursor = ScaleTexture(activeCursor, cursorSize, maintainAspectRatio);
            Cursor.SetCursor(scaledCursor, CalculateScaledHotspot(), CursorMode.Auto);
        }
    }

   
    private Texture2D ScaleTexture(Texture2D source, float scale, bool keepAspect)
    {
        int newWidth = Mathf.RoundToInt(source.width * scale);
        int newHeight = keepAspect ? Mathf.RoundToInt(source.height * scale) :
            Mathf.RoundToInt(source.height * scale);

      
        Texture2D scaledTex = new Texture2D(newWidth, newHeight, TextureFormat.RGBA32, false);

        
        for (int y = 0; y < newHeight; y++)
        {
            for (int x = 0; x < newWidth; x++)
            {
                float xNorm = (float)x / newWidth;
                float yNorm = (float)y / newHeight;
                Color pixel = source.GetPixelBilinear(xNorm, yNorm);
                scaledTex.SetPixel(x, y, pixel);
            }
        }

        scaledTex.Apply();
        return scaledTex;
    }

   
    private Vector2 CalculateScaledHotspot()
    {
        return new Vector2(
            hotspot.x * cursorSize,
            hotspot.y * cursorSize
        );
    }

   
    public void SetCursorSize(float newSize)
    {
        cursorSize = Mathf.Clamp(newSize, 0.5f, 3f);
        SetCursor(activeCursor); 
    }

    void OnDestroy()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);

        
        if (scaledCursor != null)
        {
            Destroy(scaledCursor);
        }
    }
}