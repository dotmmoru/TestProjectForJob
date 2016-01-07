using UnityEngine;
using System.Collections;

public class DestroyBYBoundary : MonoBehaviour {

	void OnTriggerExit(Collider col)
	{
		Destroy (col.gameObject);

	}
}
