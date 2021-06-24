using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PushUserInfo : MonoBehaviour
{   
    public Text patientID;
    public Text insID;
    public Text insName;

    public void getPatientID() {
        string patID = PullUserInfo.patientID;
        patientID.text = patID.ToString();
    }

    public void getInstructorID() {
        string iID = PullUserInfo.instructorID;
        insID.text = iID.ToString();
    }

    public void getInstructorName() {
        string iName = PullUserInfo.instructorName;
        insName.text = iName.ToString();
    }
    void Start() {

        getPatientID();
        getInstructorID();
        getInstructorName();
    }
}
