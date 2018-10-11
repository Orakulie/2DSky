using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Planet : MonoBehaviour {
    public GameObject[] SonneMehr;
    public float Distance,Distance2,Distance3;
    public float Grad;
    public Text Grad_Anzeige,Mater;
    public bool TempAnz;
    public GameObject Raumstation;
    public bool GUI;
    public int Materialien;
    public int Materialien1;
    public string Param;
    public string Planet_Name;
    public string MaterialienVorhanden;

    public static string ZuLadenderPlanet;
    public static bool Lade = false;


    public Dictionary<string, int> Materials = new Dictionary<string, int>();


    //public float Speed;
	// Use this for initialization






        //Materialien:
        //Holz
        //Eisen
        //Gold
        //Aluminium
        //Öl















	void Start () {
        
        //if (GameObject.Find("Planetensystem").GetComponent<Generierung>().LadenPub == false)
        //{
        if (Lade == true)
        {
            Debug.Log("Laden");
            Planet_Name = ZuLadenderPlanet;
            string[] array = PlayerPrefs.GetString(ZuLadenderPlanet).Split(',');
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    if(i != 3 && array[2] != ",")
                    AddItems(array[i], 500);
                }
                catch
                {
                  
                    Debug.Log("FEHLER!");
                }
            }
            //AddItems(PlayerPrefs.GetString(ZuLadenderPlanet),500);
            //Debug.Log(PlayerPrefs.GetString(ZuLadenderPlanet));
            Text();

        }
      if (Lade== false)
        {
        //    Planet_Name = "Planet: " + Random.Range(1, 99999);

           



            for (int i = 0; i < 3; i++)
            {

                Materialien1 = Random.Range(1, 6);
                if (Materialien1 == 1)
                {
                    AddItems("Holz", 500);
                }
                if (Materialien1 == 2)
                {
                    AddItems("Eisen", 500);
                }
                if (Materialien1 == 3)
                {
                    AddItems("Gold", 500);
                }
                if (Materialien1 == 4)
                {
                    AddItems("Aluminium", 500);
                }
                if (Materialien1 == 5)
                {
                    AddItems("Öl", 500);
                }




            }
            Text();
        }
       // }
        //   Debug.Log(Materials.Values);
        //foreach(int value in Materials.Values)
        //   {
        //       Debug.Log(value);
        //   }
        //foreach (string value2 in Materials.Keys)
        //{
        //    Debug.Log(value2);
        //}
        //foreach (int value2 in Materials.Values)
        //{
        //    Debug.Log(value2);
        //}

    }
	
	// Update is called once per frame
	void Update () {

        SonneMehr = GameObject.FindGameObjectsWithTag("Sonne");
        if (SonneMehr.Length == 1)
        {
            Distance = Vector3.Distance(SonneMehr[0].transform.position, transform.position);
            Grad = Distance * (-1) + 35;

        }
        if (SonneMehr.Length == 2)
        {
            Distance = Vector3.Distance(SonneMehr[0].transform.position, transform.position);
            Distance2 = Vector3.Distance(SonneMehr[1].transform.position, transform.position);
            Grad = (Distance * (-1) + 30) + (Distance2 * (-1) + 30);
        }
        Grad_Anzeige.text = Mathf.Round(Grad) + "°C";
        SonneMehr = GameObject.FindGameObjectsWithTag("Sonne");
        if(TempAnz == false)
        {
            Temp();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameObject.Find("Main Camera").transform.position = new Vector3(0, 0, -39.96f);
            Grad_Anzeige.GetComponent<Text>().enabled = false;
            Mater.GetComponent<Text>().enabled = false;
        }
        //if (SonneMehr.Length == 1)
        //{
        //    transform.RotateAround(SonneMehr[0].transform.position, new Vector3(0.0f, 0.0f, 0.1f), 20 * Time.deltaTime * Speed);
        //}
    }
    public void Temp()
    {
    //  Debug.Log(SonneMehr.Length);
       
      
        if (GameObject.Find("Mond(Clone)"))
        {
            Distance3 = Vector3.Distance(GameObject.Find("Mond(Clone)").transform.position, transform.position);
            Grad += Distance3;
        }
       
        TempAnz = true;
    }
 

    public void AddItems(string itemName, int Menge)
    {
        
        if (Materials.ContainsKey(itemName))
        {
      
            Materials[itemName] = Materials[itemName] + Menge;

        }
        if(!Materials.ContainsKey(itemName))
        {
     
            Materials.Add(itemName, Menge);
        }
        ////if (Materials.TryGetValue(itemName, out old))
        ////{
        ////    Menge += old;
        ////    Materials[itemName] = Menge;
        ////}
        //if (Materials.TryGetValue(itemName, out old))
        //{
        //    Menge += old;
        //   Materials[itemName] = Menge;

        //}
        
    }
    public void Text()
    {
       // Debug.Log(Materials.Count);
        foreach (string Mat in Materials.Keys)
        {
           MaterialienVorhanden += Mat + ",";
            Mater.text += Mat + "\n";
            Param += Mat + "," + Materials[Mat] + ",";
        }
        // GameObject.Find("Planetensystem").SendMessage("save", Param);
      
    }
    public void Zoom()
    {
        Mater.GetComponent<Text>().enabled = true;
        Grad_Anzeige.GetComponent<Text>().enabled = true;
    }
    public void ZoomOut()
    {
        GameObject.Find("Main Camera").transform.position = new Vector3(0, 0, -39.96f);
        Grad_Anzeige.GetComponent<Text>().enabled = false;
        Mater.GetComponent<Text>().enabled = false;
    }
    public void Out()
        {
        //GameObject.Find("Main Camera").transform.position = new Vector3(0, 0, -39.96f);
        Grad_Anzeige.GetComponent<Text>().enabled = false;
        Mater.GetComponent<Text>().enabled = false;

    }
    public void Save(string Planet)
    {

        Lade = true;
       
        ZuLadenderPlanet = "Planet: " + Planet;
    }
    public void Neu()
    {
        Lade = false;
       
    }
    public void Name(int Nummer)
    {
        Planet_Name = "Planet: " + Nummer;
        PlayerPrefs.SetString(Planet_Name, MaterialienVorhanden);
    }
    public int GetItem(string itemName)
    {
        int returnValue = Materials[itemName];
        return returnValue;
    }
}



