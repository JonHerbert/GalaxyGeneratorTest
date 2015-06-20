using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GalaxyGenerator : MonoBehaviour {

	//creating stars
	public int numberOfSolarSystems;

	private List<GameObject> starPositions = new List<GameObject>();
	private GameObject newStar;

	//creating arms for the galaxy
	public int numberOfArms = 5;
	private float armSeperationDistance;
	public float armOffsetMax = 0.5f;
	public float rotationFactor = 0.5f;

	public float angleMaxRandValue = 1.0f;
	public float armOffsetMaxRandValue = 1.0f;
	public float distanceMaxRandValue = 5.0f;
	public float distancePowMaxValue = 1.25f;

	void Start () {
		newStar = GetComponent<GameObject>();
		CreateStars();
		InitializeStars ();
	}

	void CreateStars () {
		for (int i = 0; i < numberOfSolarSystems; i ++) {
			newStar = Instantiate(Resources.Load("SolarSystem")) as GameObject;
			starPositions.Add(newStar);
		}
	}

	void InitializeStars () {
		for(int i = 0; i < starPositions.Count; i++) {
			// Choose a distance from the center of the galaxy.
			float distance = Random.Range(0.0f, distanceMaxRandValue);
			distance = Mathf.Pow(distance, distancePowMaxValue); // 0 = closer to center, 1 = realistic, 1+ further from center
			
			// Choose an angle between 0 and 2 * PI.
			float angle = Random.Range(0.0f, angleMaxRandValue) * 2 * Mathf.PI;
			float armOffset = Random.Range(0.0f, armOffsetMaxRandValue) * armOffsetMax;
			armOffset = armOffset - armOffsetMax / 2;
			armOffset = armOffset * (10 / distance); // number to divide distance needs to be close to/same as the distance Max value in declaration

			float squaredArmOffset = Mathf.Pow(armOffset, 2);
			if(armOffset < 0) {
				squaredArmOffset = squaredArmOffset * -1;
			}
			armOffset = squaredArmOffset;

			float rotation = distance * rotationFactor;

			armSeperationDistance = 2 * Mathf.PI / numberOfArms;
			angle = (int)(angle / armSeperationDistance) * armSeperationDistance + armOffset + rotation;

			// Translate from polar to cartesian coords.
			float xPos = Mathf.Cos(angle) * distance;
			float yPos = Mathf.Sin(angle) * distance;

			starPositions[i].transform.position = new Vector3(xPos, yPos, 0);
		}
	}
}
