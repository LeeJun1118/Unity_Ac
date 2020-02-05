using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPointGizmo : MonoBehaviour
{
    public Color col;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawSphere(this.transform.position, 0.2f);
    }
}
