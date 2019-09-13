using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Plant : MonoBehaviour
{
    [SerializeField]
    private PlantData info; // pass the scriptable object through to the Plant.cs
   
    SetPlantInfo spi;  // info is a custom class that contains
    // the ability create a new scriptable object 
    // SPI is a custom class that contains references to
    // GameObjects plantInfoPanel, plantIcon
    // Text plantName, threatLevel 
    // Methods OpenPlantPanel {takes the plantinfopanel and sets it active}
    // "" ClosePlantPanel {opposite of above}

    private void Start() {
        // find the Canvas component and set the reference to spi
        spi = GameObject.FindWithTag("PlantInfo").GetComponent<SetPlantInfo>();
        Physics.queriesHitTriggers = true;
    }

    void OnMouseDown()
    {
        spi.OpenPlantPanel();
        spi.planeName.text =  info.Name; //what's in plantdata?
        spi.threatLevel.text = info.Threat.ToString();
        spi.plantIcon.GetComponent<RawImage>().texture = info.Icon;  //requires namespace UnityEngine.UI
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Player" && info.Threat == PlantData.THREAT.High ){
            PlayerController.dead = true;
        }
    }

}
