using UnityEngine;
using System.Collections;

public class Sonne : MonoBehaviour {
    public GameObject Planet;
    //public GameObject[] SonneG;
    public float Speed;
    public bool Mond;
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
       
       
          
            transform.RotateAround(Planet.transform.position, new Vector3(0.0f, 0.0f, 0.1f), 20 * Time.deltaTime * Speed);
   
        //if(SonneG.Length > 1)
        //{
        //    transform.RotateAround(Planet.transform.position, new Vector3(0.0f, 0.0f, 0.1f), 20 * Time.deltaTime * Speed);
        //}

    }
    //void OnCollisionEnter(Collision coll)
    //{
    //    Debug.Log("Yeah!2");
    //    if (coll.gameObject.tag == "Sonne" )
    //    {
    //        GameObject.Find("Planetensystem").SendMessage("Neu",this.gameObject);
            
    //    }
    //    if (coll.gameObject.name == "Planet")
    //    {
    //        GameObject.Find("Planetensystem").SendMessage("Neu", this.gameObject);

    //    }


    }

