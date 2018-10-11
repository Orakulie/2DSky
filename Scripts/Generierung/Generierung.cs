using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Generierung : MonoBehaviour {
    public GameObject Sonne, Mond,Planet;
    public Vector3 SonneCoord;
    public Vector3[] SonneCoordMehr;
    private GameObject Platzhalter;
    public int AnzahlSonne, AnzahlMond;
    public string PlanetenSystem;
    public int i2;
    int Xpos = 0;
    public Text Planetensystem_Name;
    public bool OnG = false,Label = true,label2 = false;
    public static int ZuLadendesSystem;
    public static bool Laden;
    public GUIStyle style;
    public float DisSonne;
    public string Parameter;
    public bool Laden2;
    public GameObject Raumstation;
    private Raumstation Rs;
    public bool fliegen;
    // Use this for initialization
    void Start()
    {
        Rs = Raumstation.GetComponent<Raumstation>();
            Laden2 = Laden;
        //  Debug.Log(PlayerPrefs.GetString("1"));

        Planet = GameObject.Find("Planet");
        if (Laden == true)
        {
            string[] array = PlayerPrefs.GetString("" + ZuLadendesSystem).Split(',');
            float X;
            float.TryParse(array[1], out X);
            SonneCoord.x = X;
            float Y;
            float.TryParse(array[2], out Y);
            SonneCoord.y = Y;
            PlanetenSystem = array[0];
            Platzhalter = Instantiate(Sonne);
            Platzhalter.transform.position = SonneCoord;
            Platzhalter = Instantiate(Mond);
            Platzhalter.transform.position = new Vector3(SonneCoord.x * (-1), SonneCoord.y * (-1));
            try {
                if (array[5] == "true")
                {
                    Destroy(GameObject.FindGameObjectWithTag("Sonne"));
                    Destroy(GameObject.Find("Mond(Clone)"));

                    float.TryParse(array[1], out X);
                    SonneCoordMehr[0].x = X;
                    float.TryParse(array[2], out Y);
                    SonneCoordMehr[0].y = Y;
                    float.TryParse(array[3], out X);
                    SonneCoordMehr[1].x = X;
                    float.TryParse(array[4], out Y);
                    SonneCoordMehr[1].y = Y;
                    AnzahlSonne = 2;
                    for (int i = 0; i < AnzahlSonne; i++)
                    {
                        Platzhalter = Instantiate(Sonne);
                        Platzhalter.transform.position = SonneCoordMehr[i];
                        Platzhalter = Instantiate(Mond);
                        Platzhalter.transform.position = new Vector3(SonneCoordMehr[i].x * (-1), SonneCoordMehr[i].y * (-1));
                        PlanetenSystem = array[0];
                    }


                }
            }
            catch
            {
                Debug.Log("Nur eine Sonne ist vorhanden!");
            }
        }


        if (Laden == false)
        {
          

            
                int Name = Random.Range(1, 99999);
                PlanetenSystem = "Planetary system no.:" + Name;
                Planet.SendMessage("Name", Name);
          
 
            AnzahlSonne = Random.Range(1, 3);
            AnzahlMond = Random.Range(1, 3);

            if (AnzahlSonne > 1)
            {
                for (int i = 0; i < AnzahlSonne; i++)
                {
                    Platzhalter = Instantiate(Sonne);
                    SonneCoordMehr[i] = new Vector3(Random.Range(-20.5f, 20.5f), Random.Range(10.5f, -10.5f));
                    back:
                    //while (SonneCoordMehr[i].x > -8)
                    //{
                    //    SonneCoordMehr[i].x = Random.Range(-20.5f, 20.5f);
                    //}
                    //while (SonneCoordMehr[i].x < 8)
                    //{
                    //    SonneCoordMehr[i].x = Random.Range(-20.5f, 20.5f);
                    //}
                    if (Vector3.Distance(SonneCoordMehr[i], Planet.transform.position) < 4)
                    {
                        SonneCoordMehr[i] = new Vector3(Random.Range(-20.5f, 20.5f), Random.Range(10.5f, -10.5f));
                        goto back;
                    }
                    for (int ye = 0; ye < GameObject.FindGameObjectsWithTag("Sonne").Length; ye++)
                    {
                        if (Vector3.Distance(SonneCoordMehr[i], GameObject.FindGameObjectsWithTag("Sonne")[ye].transform.position) < 3)
                        {
                            DisSonne = Vector3.Distance(SonneCoordMehr[i], GameObject.FindGameObjectsWithTag("Sonne")[ye].transform.position);
                       //Debug.Log(DisSonne);
                            SonneCoordMehr[i] = new Vector3(Random.Range(-20.5f, 20.5f), Random.Range(10.5f, -10.5f));
                            Platzhalter.transform.position = SonneCoordMehr[i];
                            goto back;
                        }
                    }
                    Platzhalter.transform.position = SonneCoordMehr[i];
                }
            }


            if (AnzahlSonne == 1)
            {
                Platzhalter = Instantiate(Sonne);
                SonneCoord = new Vector3(Random.Range(-20.5f, 20.5f), Random.Range(10.5f, -10.5f));



                //while (SonneCoord.x > -8)
                //{
                //    SonneCoord.x = Random.Range(-20.5f, 20.5f);
                //}
                //while (SonneCoord.x < 8)
                //{
                //    SonneCoord.x = Random.Range(-20.5f, 20.5f);
                //}
                oben1:
                if (Vector3.Distance(SonneCoord, Planet.transform.position) < 4)
                {
                    SonneCoord = new Vector3(Random.Range(-20.5f, 20.5f), Random.Range(10.5f, -10.5f));
                    goto oben1;
                }
                Platzhalter.transform.position = SonneCoord;
            }




            //     }

            //    for (int i = 0; i < AnzahlMond; i++)
            //    {
            if (AnzahlSonne == 1 )
            {
                Platzhalter = Instantiate(Mond);
                //    if(AnzahlSonne == 1)
                Platzhalter.transform.position = new Vector3(SonneCoord.x * (-1), SonneCoord.y * (-1));
            }
           
                if (AnzahlSonne > 1)
                {
                    for (int i = 0; i < AnzahlSonne; i++)
                    {
                        Platzhalter = Instantiate(Mond);
                        Platzhalter.transform.position = new Vector3(SonneCoordMehr[i].x * (-1), SonneCoordMehr[i].y * (-1));
                    }
                }
                //    if (AnzahlSonne > 1)
                //  Platzhalter.transform.position = new Vector3(Random.Range(-10.5f, 10.5f), Random.Range(-5.5f, 5.5f));
                //      }
                //Platzhalter = Instantiate(Planet);
                //Platzhalter.transform.position = new Vector3(0, 0);


            }

        
    }

    // Update is called once per frame
    void Update() {




        if(Input.GetKeyDown(KeyCode.E) && fliegen == true && Rs.GetItem("Öl") > 30)
        {
            Laden = false;
            Planet.SendMessage("Neu");
            Rs.RemoveItems("Öl", 30);
            Application.LoadLevel(0);
        }





        Planetensystem_Name.text = PlanetenSystem;






        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.DeleteAll();
        }



        if (Input.GetKeyDown(KeyCode.T) && fliegen == true && Rs.GetItem("Öl") > 30)
        {
            
            OnG = true;
           

        }
        if (Input.GetKeyUp(KeyCode.T))
        {
            OnG = false;
        }


        //if(Input.GetKeyDown(KeyCode.Alpha1))
        //       {
        //           for (int i = 0; true; i++)
        //           {
        //               string HasKey;
        //               HasKey = i.ToString();
        //               if (PlayerPrefs.HasKey(HasKey) == true)
        //               {
        //                   string[] array = PlayerPrefs.GetString(HasKey).Split(',');
        //                   PlanetenSystem = array[0];
        //                   float X;
        //                   float.TryParse(array[1], out X);
        //                   SonneCoord.x = X;
        //                   float Y;
        //                   float.TryParse(array[2], out Y);
        //                   SonneCoord.y = Y;

        //                   GameObject.Find("Sonne(Clone)").transform.position = SonneCoord;
        //                   GameObject.Find("Mond(Clone)").transform.position = new Vector3(SonneCoord.x * (-1), SonneCoord.y * (-1));
        //                   break;
        //               }
        //           }
        //       }

    }
    public void hangar()
    {
        fliegen = true;
    }
    void OnGUI()
    {
        if(label2)
        {
            GUI.Label(new Rect(0,0, 300, 20), "Neue Raumstation freigeschaltet!",style);
        }
        int Anzahl = 0;
        bool go = true;

        for (int i = 0; go == true; i++)
        {
            if (PlayerPrefs.HasKey(i.ToString()) == true)
            {
                Anzahl++;
            }
            if (PlayerPrefs.HasKey(i.ToString()) == false)
            {

                go = false;
                break;
            }
        }

        for (int i = 0; i < Anzahl; i++)
        {



            string[] array = PlayerPrefs.GetString("" + i).Split(',');
            if(array[0] == PlanetenSystem)
            {
                goto weiter;
            }
           
            {
                
            }
        }
        if (Label == true)
        {
            for (int y = 0; true; y++)
            {
                string HasKey;
                HasKey = y.ToString();
                if (PlayerPrefs.HasKey(HasKey) == false && PlayerPrefs.GetString(HasKey) != PlanetenSystem)
                {
                    if(AnzahlSonne == 1)
                    PlayerPrefs.SetString(HasKey, PlanetenSystem + "," + SonneCoord.x + "," + SonneCoord.y);
                    if(AnzahlSonne == 2)
                    PlayerPrefs.SetString(HasKey, PlanetenSystem + "," + SonneCoordMehr[0].x + "," + SonneCoordMehr[0].y +","+ SonneCoordMehr[1].x + "," + SonneCoordMehr[1].y +"," +"true");
                    break;
                }
            }
            Debug.Log("Yeah!");
         
            label2 = true;
           StartCoroutine(LabelZ());
        }
        weiter:
          
        if (OnG == true)
        {           
            for (int i = 0; i < Anzahl; i++)
            {

      

                string[] array = PlayerPrefs.GetString("" + i).Split(',');
                if (GUI.Button(new Rect(Xpos, 10 + (i * 40), 400, 30), array[0]))
                {
                    ZuLadendesSystem = i;
                    Laden = true;
                    string[] array2 = array[0].Split(':');
                    Planet.SendMessage("Save", array2[1]);
                    Rs.RemoveItems("Öl", 30);
                    Application.LoadLevel(0);
                    //float X;
                    //float.TryParse(array[1], out X);
                    //SonneCoord.x = X;
                    //float Y;
                    //float.TryParse(array[2], out Y);
                    //SonneCoord.y = Y;
                    //PlanetenSystem = array[0];
                    //GameObject.Find("Sonne(Clone)").transform.position = SonneCoord;
                    //GameObject.Find("Mond(Clone)").transform.position = new Vector3(SonneCoord.x * (-1), SonneCoord.y * (-1));

                }

         }
        }
    }
    IEnumerator LabelZ()
    {
       yield return new WaitForSeconds(1.5f);
        Label = false;
        label2 = false;
    }
    //public void Neu(GameObject SonneObj)
    //{
    //    SonneObj.transform.position = new Vector3(Random.Range(-15.5f, 15.5f), Random.Range(-10.5f, 10.5f));
    //}

    public void save(string Param)
    {
        Debug.Log(Param);
    }
    }
