using UnityEngine;
using System.Collections;

public class Licht : MonoBehaviour {
   public GameObject Planet;


	// Use this for initialization
	void Start () {
     
    }
	
	// Update is called once per frame
	void Update () {
      
        Planet = GameObject.Find("Planet");
       transform.LookAt(Planet.transform);       
    }
}
