using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using NavMeshPlus.Extensions;

namespace NavMeshPlus.Components
{
    [ExecuteInEditMode]
    [DefaultExecutionOrder(-101)]
    [AddComponentMenu("Navigation/Navigation Link", 33)]
    [HelpURL("https://github.com/Unity-Technologies/NavMeshPlus#documentation-draft")]
    public class NavMeshLink : MonoBehaviour
    {
        [SerializeField]
        int m_AgentTypeID;
        public int agentTypeID { get => m_AgentTypeID; set { m_AgentTypeID = value; UpdateLink(); } }

        [SerializeField]
        Vector3 m_StartPoint = new Vector3(0.0f, 0.0f, -2.5f);
        public Vector3 startPoint { get => m_StartPoint; set { m_StartPoint = value; UpdateLink(); } }

        [SerializeField]
        Vector3 m_EndPoint = new Vector3(0.0f, 0.0f, 2.5f);
        public Vector3 endPoint { get => m_EndPoint; set { m_EndPoint = value; UpdateLink(); } }

        [SerializeField]
        float m_Width;
        public float width { get => m_Width; set { m_Width = value; UpdateLink(); } }

        [SerializeField]
        int m_CostModifier = -1;
        public int costModifier { get => m_CostModifier; set { m_CostModifier = value; UpdateLink(); } }

        [SerializeField]
        bool m_Bidirectional = true;
        public bool bidirectional { get => m_Bidirectional; set { m_Bidirectional = value; UpdateLink(); } }

        [SerializeField]
        bool m_AutoUpdatePosition;
        public bool autoUpdate { get => m_AutoUpdatePosition; set => SetAutoUpdate(value); }

        [SerializeField]
        int m_Area;
        public int area { get => m_Area; set { m_Area = value; UpdateLink(); } }

        NavMeshLinkInstance m_LinkInstance = new NavMeshLinkInstance();

        Vector3 m_LastPosition = Vector3.zero;
        Quaternion m_LastRotation = Quaternion.identity;

        static readonly List<NavMeshLink> s_Tracked = new List<NavMeshLink>();

        void OnEnable()
        {
            AddLink();
            if (m_AutoUpdatePosition && m_LinkInstance.valid)
                AddTracking(this);
        }

        void OnDisable()
        {
            RemoveTracking(this);
            m_LinkInstance.Remove();
        }

        public void UpdateLink()
        {
            m_LinkInstance.Remove();
            AddLink();
        }

        static void AddTracking(NavMeshLink link)
        {
#if UNITY_EDITOR
            if (s_Tracked.Contains(link))
            {
                Debug.LogError("Link is already tracked: " + link, link);
                return;
            }
#endif

            if (s_Tracked.Count == 0)
                NavMesh.onPreUpdate += UpdateTrackedInstances;

            s_Tracked.Add(link);
        }

        static void RemoveTracking(NavMeshLink link)
        {
            if (s_Tracked.Remove(link) && s_Tracked.Count == 0)
                NavMesh.onPreUpdate -= UpdateTrackedInstances;
        }

        void SetAutoUpdate(bool value)
        {
            if (m_AutoUpdatePosition == value)
                return;

            m_AutoUpdatePosition = value;
            if (value)
                AddTracking(this);
            else
                RemoveTracking(this);
        }

        void AddLink()
        {
#if UNITY_EDITOR
            if (m_LinkInstance.valid)
            {
                Debug.LogError("Link is already added: " + this, this);
                return;
            }
#endif

            var link = new NavMeshLinkData
            {
                startPosition = m_StartPoint,
                endPosition = m_EndPoint,
                width = m_Width,
                costModifier = m_CostModifier,
                bidirectional = m_Bidirectional,
                area = m_Area,
                agentTypeID = m_AgentTypeID
            };

            m_LinkInstance = NavMesh.AddLink(link, transform.position, transform.rotation);
            if (m_LinkInstance.valid)
                m_LinkInstance.owner = this;

            m_LastPosition = transform.position;
            m_LastRotation = transform.rotation;
        }

        bool HasTransformChanged()
        {
            return m_LastPosition != transform.position ||
                   m_LastRotation != transform.rotation;
        }

        void OnDidApplyAnimationProperties()
        {
            UpdateLink();
        }

        static void UpdateTrackedInstances()
        {
            // Create copy to avoid modification during iteration
            var trackedCopy = new List<NavMeshLink>(s_Tracked);
            foreach (var instance in trackedCopy)
            {
                if (instance != null && instance.HasTransformChanged())
                    instance.UpdateLink();
            }
        }

#if UNITY_EDITOR
        void OnValidate()
        {
            m_Width = Mathf.Max(0.0f, m_Width);

            if (!m_LinkInstance.valid)
                return;

            UpdateLink();

            if (!m_AutoUpdatePosition)
            {
                RemoveTracking(this);
            }
            else if (!s_Tracked.Contains(this))
            {
                AddTracking(this);
            }
        }
#endif
    }
}