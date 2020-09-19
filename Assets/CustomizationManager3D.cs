using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizationManager3D : MonoBehaviour
{
    enum AppearanceDetails
    {
        HATS,
        COLOURTYPE,
        NECKLESS,
        HANDS,
        BACK
    }

    [SerializeField] private Transform headAnchor;
    [SerializeField] private GameObject[] hatsModels;
    GameObject activeHat;
    int hatIndex = 0;
    [SerializeField] private Transform necklessAnchor;
    [SerializeField] private GameObject[] necklessModels;
    GameObject activeNeckless;
    int necklessIndex = 0;


    [SerializeField] private PointList colores = new PointList();
    [SerializeField] private Material[] materialsPenguin;
    [SerializeField] private List<Material[]> materialsPenguinSet;
    GameObject activeColourType;
    int colourTypeIndex = 0;

    private void Start()
    {
        ChangeColourType();
        materialsPenguinSet = new List<Material[]>();
    }


    public void HatModeUp()
    {
        if (hatIndex < hatsModels.Length - 1)
            hatIndex++;
        else
            hatIndex = 0;

        ApplyModification(AppearanceDetails.HATS, hatIndex);

    }
    public void HatModeDown()
    {
        if (hatIndex > 0)
            hatIndex--;
        else
            hatIndex = hatsModels.Length - 1;

        ApplyModification(AppearanceDetails.HATS, hatIndex);

    }
    public void ColorSetUp()
    {
        if (colourTypeIndex < colores.list.Count - 1)
            colourTypeIndex++;
        else
            colourTypeIndex = 0;

        ApplyModification(AppearanceDetails.COLOURTYPE, colourTypeIndex);

    }
    public void ColorSetDown()
    {
        if (colourTypeIndex > 0)
            colourTypeIndex--;
        else
            colourTypeIndex = colores.list.Count - 1;

        ApplyModification(AppearanceDetails.COLOURTYPE, colourTypeIndex);

    }

    public void NecklessSetUp()
    {
        if (necklessIndex < necklessModels.Length - 1)
            necklessIndex++;
        else
            necklessIndex = 0;

        ApplyModification(AppearanceDetails.NECKLESS, necklessIndex);

    }
    public void NecklessSetDown()
    {
        if (necklessIndex > 0)
            necklessIndex--;
        else
            necklessIndex = necklessModels.Length - 1;

        ApplyModification(AppearanceDetails.NECKLESS, necklessIndex);

    }




    void ChangeColourType()
    {
        try
        {
            for (int i = 0; i < colores.list.Count; i++)
            {

                materialsPenguinSet.Add(materialsPenguin);

            }

            for (int i = 0; i < materialsPenguinSet.Count; i++)
            {
                for (int j = 0; j < materialsPenguinSet[i].Length; j++)
                {
                    materialsPenguinSet[i][j].color = colores.list[i].list[j];
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogWarning(e.Message);
        }
    }

    void ApplyModification(AppearanceDetails detail, int id)
    {
        switch (detail)
        {
            case AppearanceDetails.HATS:
                if (activeHat != null)
                    GameObject.Destroy(activeHat);
                activeHat = GameObject.Instantiate(hatsModels[id]);
                activeHat.transform.SetParent(headAnchor);
                activeHat.transform.HatsResetTransform();
                break;
            case AppearanceDetails.COLOURTYPE:
                for(int i = 0; i < materialsPenguin.Length; i++)
                {
                    materialsPenguin[i].color = colores.list[colourTypeIndex].list[i];
                }
                break;
            case AppearanceDetails.NECKLESS:
                if (activeNeckless != null)
                    GameObject.Destroy(activeNeckless);
                activeNeckless = GameObject.Instantiate(necklessModels[id]);
                activeNeckless.transform.SetParent(necklessAnchor);
                activeNeckless.transform.HatsResetTransform();

                break;
           


        }
    }
}
