using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using TMPro;

public class FirebaseManger : MonoBehaviour
{   public TMP_InputField Find;
    public TMP_InputField username;
    public TMP_Dropdown soilcolour;
    public TMP_Dropdown soilcomposition;
    public TMP_Dropdown dateofind;
    public TMP_Dropdown matoffind;
    public TMP_InputField descoffind;
    public TMP_InputField locationinfo;
    
    public TMP_InputField additionalinfo;

    private string userID;
    private DatabaseReference dbReference;
   string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
   public string randomstring;
   
    void Start()
    {
        userID = username.text;
        dbReference = FirebaseDatabase.DefaultInstance.RootReference;
    }
    
    public void radnomsstringmaker()
    {for(int i = 0; i < 8; i++ )
    {randomstring += characters[Random.Range(0, characters.Length)];}}

    public void clearstring()
    {randomstring = "";
    Find.text = "";
    soilcolour.value = 0;
    soilcomposition.value =0;
    dateofind.value = 0;
    matoffind.value = 0;
    descoffind.text = "";
    locationinfo.text = "";}
    
    
    public void CreateFind()
    {
        Findsmanager newFind = new Findsmanager(Find.text);
        string json = JsonUtility.ToJson(newFind); 

        dbReference.Child("users").Child(userID).SetRawJsonValueAsync(json);

    }

    public void Pushfinddata()
    {
        UserManager findinfo = new UserManager(soilcolour.value,soilcomposition.value,dateofind.value,matoffind.value,descoffind.text,locationinfo.text,additionalinfo.text);
        string json2 = JsonUtility.ToJson(findinfo);
    
        dbReference.Child("Users").Child(userID).Child(username.text).Child(Find.text).Child(randomstring).SetRawJsonValueAsync(json2);
    }
    
}
