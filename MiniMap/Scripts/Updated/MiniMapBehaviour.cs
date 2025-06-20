using UnityEngine;


namespace Map
{
    [RequireComponent (typeof(Camera))]
    public class MiniMapBehaviour : MapBehaviour
    {
        [SerializeField] float m_CameraHeight = 18;
        [SerializeField] MinimapScriptable m_MinimapScriptable;

        private void LateUpdate()
        {
            this.transform.position = base.m_Target.position + new Vector3(m_MinimapScriptable.CameraPosition.x, 
                m_MinimapScriptable.CameraHeight, 
                m_MinimapScriptable.CameraPosition.z);

            base.m_TargetIcon.rotation = Quaternion.Euler(0, 0, -1 * base.m_Target.rotation.eulerAngles.y);
        }
    }
}

