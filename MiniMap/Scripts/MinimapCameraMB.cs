using UnityEngine;
using static UnityEditor.PlayerSettings;

[RequireComponent (typeof(Camera))]
public class MinimapCameraMB : MonoBehaviour
{
    [SerializeField] bool m_EnableBigMinimap = true;
    [SerializeField] Camera m_MinimapCamera;
    [SerializeField] Transform m_Target;
    [SerializeField] RectTransform m_MiniMap01;
    [SerializeField] RectTransform m_MiniMap02;
    [SerializeField] RectTransform m_CharacterIcon;

    [SerializeField] float cameraHeight = 18f;

    [SerializeField] MinimapScriptable m_Minimap01Scriptable;
    [SerializeField] MinimapScriptable m_Minimap02Scriptable;

    void Start()
    {
                
    }

    private void LateUpdate()
    {
        // Toggle Minimap on M key event press.
        if (Input.GetKeyDown(KeyCode.M))
        {
            // ToggleMinimap();
        }

        // For smaller map.
        if (!m_EnableBigMinimap)
        {
            this.transform.position = m_Target.position + new Vector3(m_Minimap02Scriptable.CameraPosition.x, m_Minimap02Scriptable.CameraHeight, m_Minimap02Scriptable.CameraPosition.z);
        }
        else
        {
            // Position the Arrow according to the Player's position
            var pos = m_MinimapCamera.WorldToScreenPoint(m_Target.position);   
            m_CharacterIcon.transform.position = pos;
        }
            m_CharacterIcon.rotation = Quaternion.Euler(0, 0, -1 * m_Target.rotation.eulerAngles.y);
    }

    /// <summary>
    /// Toggle minimap from small to big.
    /// </summary>
    public void ToggleMinimap()
    {
        switch (m_EnableBigMinimap)
        {
            case true:
                // Enable smaller canvas & Disable bigger canvas.
                m_MiniMap01.gameObject.SetActive(false);
                m_MiniMap02.gameObject.SetActive(true);
                m_MinimapCamera.orthographicSize = m_Minimap02Scriptable.CameraProjectionSize;
                m_CharacterIcon.transform.SetParent(m_MiniMap02.transform);
                m_CharacterIcon.anchoredPosition = Vector2.zero;
                m_EnableBigMinimap = false;
                break;
            case false:
                // Enable bigger canvas & Disable smaller canvas.
                m_MiniMap01.gameObject.SetActive(true);
                m_MiniMap02.gameObject.SetActive(false);
                m_MinimapCamera.orthographicSize = m_Minimap01Scriptable.CameraProjectionSize;
                m_CharacterIcon.transform.SetParent(m_MiniMap01.transform);
                // Update Camera Position.
                this.transform.position = new Vector3(m_Minimap01Scriptable.CameraPosition.x, m_Minimap01Scriptable.CameraHeight, m_Minimap01Scriptable.CameraPosition.z);
                m_EnableBigMinimap = true;
                break;
        }
        
    }
}
