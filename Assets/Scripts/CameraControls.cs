using UnityEngine;
using System.Collections;

public class CameraControls : MonoBehaviour
{
	public float step;
	public float dist;
	public IEnumerator PanCamera(Transform target)
	{
		Vector3 endPoint = new Vector3 (target.position.x, target.position.y, target.position.z - dist);
		while(Vector3.Distance(transform.position, endPoint)>1)
		{
			transform.position = Vector3.Lerp(transform.position, endPoint, step*Time.smoothDeltaTime);
			transform.LookAt(target);
			yield return null;
		}
		yield return true;
	}
}
