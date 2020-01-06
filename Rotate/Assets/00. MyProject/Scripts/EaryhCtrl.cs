using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EaryhCtrl : MonoBehaviour
{
	//** [Tooltip("")] = 엔진에서 설명을 볼 수 있다.

	[Tooltip("회전을 시킬지 말지 확인한다.")]
	public bool SpinCheck;

	[Tooltip("회전 속도")]
	public float Speed = 10f;

	void Update()
	{
		//** SpinCheck 가  true 라면...
		if (SpinCheck)
			transform.Rotate(Vector3.up, Speed * Time.deltaTime);
	}
}
