using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Raumstation : MonoBehaviour {
   
    public float speed;
    public GameObject Planet;
    public string Inventory;
    public Text InventoryAnzeige, InventoryValuesAnzeige;
  public  int counter = 0, counter2 = 1;
    private string[] Names;
    private int[] Values;
    public Planet PS;
    public GameObject HangarG,OelRaf;
    public Dictionary<string, int> Inventar = new Dictionary<string, int>();
    public bool OelRaff, Hangar;

    void Start() {
        PS = Planet.GetComponent<Planet>();
        if(PlayerPrefs.GetString("ÖlRaff") == "true")
        {
            OelRaff = true;
            OelRaf.SetActive(true);
            StartCoroutine(OelRaffe());
        }
        if (PlayerPrefs.GetString("Hangar") == "true")
        {
            Hangar = true;
            HangarG.GetComponent<MeshRenderer>().enabled = true;
            GameObject.Find("Planetensystem").GetComponent<Generierung>().hangar();
        }

        Values = new int[5];
        Names = new string[5];


        if (PlayerPrefs.HasKey("NeuStart") == true)
        {
            Laden(true);
        }


        if (PlayerPrefs.HasKey("NeuStart") == false)
        {
        
            Debug.Log("NEUSTART!");
            PlayerPrefs.SetInt("NeuStart", 1);
           
                AddItems("Holz", 500);
           
                AddItems("Eisen", 500);
          
                AddItems("Gold", 500);
           
                AddItems("Aluminium", 500);
          
                AddItems("Öl", 500);
           for(int i = 0; i < 5; i ++)
            {
                Values[i] = 500;

            }
           foreach(string Name in Inventar.Keys)
            {
                Names[counter] = Name;
                counter += 1;
            }

        }
        Reload();
        
    }
    void Laden(bool laden)
    {
        Debug.Log("LADEN");
        //Debug.Log(PlayerPrefs.GetString("Inventar"));

        string[] items = PlayerPrefs.GetString("Inventar").Split(',');
        counter = 0;
        counter2 = 1;
        Values = new int[5];
        Names = new string[5];

        for (int i = 0; i < 5; i++)
        {

            // Debug.Log(items[counter]);
            Names[i] = items[counter];

            counter += 2;


        }
        for (int i = 0; i < 5; i++)
        {
            int par = 0;
            int.TryParse(items[counter2], out par);
            // Debug.Log(items[i]);
            Values[i] = par;
            counter2 += 2;
        }
        if (laden == true)
        {
            for (int i = 0; i < 5; i++)
            {
                AddItems(Names[i], Values[i]);
                //   Debug.Log(Names[i] + Values[i]);
            }
        }
        Reload();
    }
    // Update is called once per frame
    void Update()
    {
      
       
       // GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, GetComponent<SkinnedMeshRenderer>().GetBlendShapeWeight(0) * 0.99f);




        if (GameObject.Find("Main Camera").transform.position == new Vector3(0, 1.27f, -10.11f))
        {
            Planet.SendMessage("Zoom");
        }

    }
    void OnGUI()
    {
        if (GameObject.Find("Main Camera").transform.position == new Vector3(0, 1.27f, -10.11f))
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 300, Screen.height / 2 - 75, 150, 50), "Ölraffinerie bauen"))
            {
                try
                {
                    if (PS.GetItem("Öl") > 1)
                    {
                        if (GetItem("Eisen") > 199)
                        {
                            OelRaff = true;
                            RemoveItems("Eisen", 200);
                            PlayerPrefs.SetString("ÖlRaff", "true");
                            PS.ZoomOut();
                            OelRaf.SetActive(true);
                            Laden(false);

                            StartCoroutine(OelRaffe());


                        }
                    }
                }
                catch
                {
                    Debug.Log("KEIN ÖL VORHANDEN!");
                }
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 300, Screen.height / 2 - 0, 150, 50), "Hangar bauen"))
            {
                if (GetItem("Eisen") >= 300)
                {
                    RemoveItems("Eisen", 300);
                    if (GetItem("Holz") >= 100)
                    {
                        RemoveItems("Holz", 100);
                        Hangar = true;
                        PlayerPrefs.SetString("Hangar", "true");
                        PS.ZoomOut();
                        GameObject.Find("Planetensystem").GetComponent<Generierung>().hangar();
                        HangarG.GetComponent<MeshRenderer>().enabled = true;
                        Laden(false);
                    }
                } }
                if (GUI.Button(new Rect(Screen.width / 2 + 150, Screen.height / 2 - 75, 150, 50), "Eisenmine bauen"))
                {

                }
                if (GUI.Button(new Rect(Screen.width / 2 + 150, Screen.height / 2 - 0, 150, 50), "Goldmine bauen"))
                {

                }
                if (GUI.Button(new Rect(Screen.width / 2 -  300, Screen.height / 2 + 75, 150, 50), "Alumininiummine bauen"))
                {

                }
                if (GUI.Button(new Rect(Screen.width / 2 + 150, Screen.height / 2 + 75, 150, 50), "Fällerei bauen"))
                {

                }

            
        }
    }

   IEnumerator OelRaffe()
    
    {
        if (OelRaff == true)
        {
            OelRaf.SetActive(true);
            yield return new WaitForSeconds(5);
            AddItems("Öl", 5);
             Laden(false);
            StartCoroutine(OelRaffe());
        }
      

    }

        void OnMouseOver()
         {
            GameObject.Find("Main Camera").transform.position = Vector3.MoveTowards(GameObject.Find("Main Camera").transform.position, new Vector3(0, 1.27f, -10.11f), speed * Time.deltaTime);

        }
     //   void OnMouseExit()
     //{
     //       Planet.SendMessage("Out");
     //       while (GameObject.Find("Main Camera").transform.position != new Vector3(0, 0, -39.96f))
     //           GameObject.Find("Main Camera").transform.position = Vector3.MoveTowards(GameObject.Find("Main Camera").transform.position, new Vector3(0, 0, -39.96f), speed * Time.deltaTime);
     //   }
    public void AddItems(string itemName, int Menge)
    {

        if (Inventar.ContainsKey(itemName))
        {
            
            Inventar[itemName] = Inventar[itemName] + Menge;

        }
        if (!Inventar.ContainsKey(itemName))
        {
           
            Inventar.Add(itemName, Menge);
        }
        Reload();
    }
    public void RemoveItems(string itemName, int Menge)
    {
        if (Inventar.ContainsKey(itemName))
        {

            Inventar[itemName] = Inventar[itemName] - Menge;

        }
        Reload();
    }
    public int GetItem(string itemName)
    {
        int returnValue = Inventar[itemName];
        return returnValue;
    }



    public void Reload()
    {
        Inventory = "";
        InventoryAnzeige.text = "";
        InventoryValuesAnzeige.text = "";


       
        foreach (string Items in Inventar.Keys)
        {
            Inventory += Items + "," + Inventar[Items] + ",";
        }
        for (int i = 0; i < 5; i++)
        {
            InventoryAnzeige.text +=  Names[i] + "\n";
            InventoryValuesAnzeige.text += Values[i] + "x\n";
        }
        PlayerPrefs.SetString("Inventar", Inventory);
      
    }

}
