using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizationManager2D : MonoBehaviour
{
   enum AppearanceDetails
    {
        FACES,
        COLOURS

    }

    [SerializeField] private GameObject[] faceModels;
    [SerializeField] private Transform headAnchor;
    GameObject activeFace;
    int faceIndex = 0;

    [SerializeField] private Color32[] colourModels;
    [SerializeField] private GameObject[] BodyParts;
    Color32 activeColour;
    int colourIndex = 0;






    public void FaceModeUp()
    {
        if (faceIndex < faceModels.Length - 1)
            faceIndex++;
        else
            faceIndex = 0;

        ApplyModification(AppearanceDetails.FACES, faceIndex);

    }
    public void FaceModeDown()
    {
        if (faceIndex > 0)
            faceIndex--;
        else
            faceIndex = faceModels.Length - 1;

        ApplyModification(AppearanceDetails.FACES, faceIndex);

    }

    public void ColourModeUp()
    {
        if (colourIndex < colourModels.Length - 1)
            colourIndex++;
        else
            colourIndex = 0;

        ApplyModification(AppearanceDetails.COLOURS, colourIndex);

    }
    public void ColourModeDown()
    {
        if (colourIndex > 0)
            colourIndex--;
        else
            colourIndex = colourModels.Length - 1;

        ApplyModification(AppearanceDetails.COLOURS, colourIndex);

    }

    void ApplyModification(AppearanceDetails detail, int id)
    {
        switch(detail)
        {
            case AppearanceDetails.FACES:
                if (activeFace != null)
                    GameObject.Destroy(activeFace);
                activeFace = GameObject.Instantiate(faceModels[id]);
                activeFace.transform.SetParent(headAnchor);
                activeFace.transform.ResetTransform();
                break;
            case AppearanceDetails.COLOURS:
               
                    foreach(GameObject part in BodyParts)
                    {
                        activeColour = colourModels[id];
                        part.GetComponent<SpriteRenderer>().color = activeColour; 
                    }
                break;
        }
    }
}
