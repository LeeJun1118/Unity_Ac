using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPointGizmo : MonoBehaviour
{
	public Color col;// = new Color(0.0f, 0.0f, 0.0f, 255f);

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		//Gizmos.color = col;
		Gizmos.DrawSphere(this.transform.position, 0.2f);
	}
}
