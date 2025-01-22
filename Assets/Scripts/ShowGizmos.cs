using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowGizmos : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Bestimmt die Farbe der Gitmos")] private Color gizmoColor = Color.white;

#if UNITY_EDITOR
    /// <summary>
    /// Triggerbox anzeigen
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    } // End private void OnDrawGizmos()
#endif


}
