using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PullUserInfo : MonoBehaviour
{
   public static string patientID;
   public static string instructorID;
   public static string instructorName;


   public void ReadPatInput(string p) {
       patientID = p;
       Debug.Log(patientID);
   }

   public void ReadIIDInput(string i) {
       instructorID = i;
       Debug.Log(instructorID);
       
   }

   public void ReadINameInput(string inam) {
       instructorName = inam;
       Debug.Log(instructorName);
   }


}
