using UnityEngine;
using System.Collections;

public class GalaxyRotator : MonoBehaviour {

	[Range(0.0f, 10.0f)]
	public float speed;
	private Transform trans;

	void Start () {
		trans = GetComponent<Transform>();
	}
	
	void Update () {
		trans.transform.rotation = new Quaternion(0, 0, speed * Time.deltaTime, 1);
	}
}
