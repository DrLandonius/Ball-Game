using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour
{

	public GameObject target;
	public Vector3 offset;

	public void MyInitializeMethod(PlayerController player)
	{
		target = player.gameObject;
	}

	void Start ()
	{
		offset = transform.position;
	}


	void LateUpdate ()
	{
		transform.position = target.transform.position + offset;
	}

}
