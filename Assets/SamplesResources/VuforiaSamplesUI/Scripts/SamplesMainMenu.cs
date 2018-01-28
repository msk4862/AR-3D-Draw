/*===============================================================================
Copyright (c) 2016-2017 PTC Inc. All Rights Reserved.

Vuforia is a trademark of PTC Inc., registered in the United States and other 
countries.
===============================================================================*/
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class SamplesMainMenu : MonoBehaviour
{

    #region PUBLIC_MEMBERS

    public enum MenuItem
    {
        ImageTargets,
        VuMark,
        CylinderTargets,
        MultiTargets,
        UserDefinedTargets,
        ObjectReco,
        CloudReco,
        VirtualButtons,
    }

    public Canvas AboutCanvas;
    public Text AboutTitle;
    public Text AboutDescription;

    public static bool isAboutScreenVisible;

    // initialize static enum with one of the items
    public static MenuItem menuItem = MenuItem.ImageTargets;

    public const string MenuScene = "1-Menu";
    public const string LoadingScene = "2-Loading";

    SamplesAboutScreenInfo aboutScreenInfo;

    #endregion // PUBLIC_MEMBERS

    #region MONOBEHAVIOUR_METHODS

    void Start()
    {
        // reset about screen state variable to false when returning from AR scene
        isAboutScreenVisible = false;

        if (aboutScreenInfo == null)
        {
            // initialize if null
            aboutScreenInfo = new SamplesAboutScreenInfo();
        }
    }

    #endregion // MONOBEHAVIOUR_METHODS

    #region PUBLIC_METHODS

    public static string GetSceneToLoad()
    {
        // called by SamplesLoadingScreen to load selected AR scene
        return "3-" + menuItem.ToString();
    }

    public static void LoadScene(string scene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
    }

    public void BackToMenu()
    {
        // called to return to Menu from About screen
        AboutCanvas.sortingOrder = 0;
        isAboutScreenVisible = false;
    }

    public void LoadAboutScene(string itemSelected)
    {
        UpdateConfiguration(itemSelected);

        // This method called from list of Sample App menu buttons
        switch (itemSelected)
        {

            case ("ImageTargets"):
                menuItem = MenuItem.ImageTargets;
                break;
            case ("VuMark"):
                menuItem = MenuItem.VuMark;
                break;
            case ("CylinderTargets"):
                menuItem = MenuItem.CylinderTargets;
                break;
            case ("MultiTargets"):
                menuItem = MenuItem.MultiTargets;
                break;
            case ("UserDefinedTargets"):
                menuItem = MenuItem.UserDefinedTargets;
                break;
            case ("ObjectReco"):
                menuItem = MenuItem.ObjectReco;
                break;
            case ("CloudReco"):
                menuItem = MenuItem.CloudReco;
                break;
            case ("VirtualButtons"):
                menuItem = MenuItem.VirtualButtons;
                break;
        }

        AboutTitle.text = aboutScreenInfo.GetTitle(menuItem.ToString());
        AboutDescription.text = aboutScreenInfo.GetDescription(menuItem.ToString());

        AboutCanvas.transform.parent.transform.position = Vector3.zero; // move canvas into position
        AboutCanvas.sortingOrder = 2; // bring canvas in front of main menu
        isAboutScreenVisible = true;

    }

    public void UpdateConfiguration(string scene)
    {

        var config = VuforiaConfiguration.Instance;
        var dbConfig = config.DatabaseLoad;

        // all settings which are changed for a scene, have to be reset here
        // because any change is persistent throughout the whole application
        dbConfig.DataSetsToLoad = dbConfig.DataSetsToActivate = new string[0];
        config.Vuforia.MaxSimultaneousImageTargets = 4;

        switch (scene)
        {
            case ("ImageTargets"):
            case ("MultiTargets"):
            case ("VirtualButtons"):
            case ("CylinderTargets"):
                dbConfig.DataSetsToLoad = dbConfig.DataSetsToActivate = new[] { "VuforiaMars_Images" };
                break;
            case ("ObjectReco"):
                dbConfig.DataSetsToLoad = dbConfig.DataSetsToActivate = new[] { "VuforiaMars_Object_OT" };
                break;
            case ("VuMark"):
                dbConfig.DataSetsToLoad = dbConfig.DataSetsToActivate = new[] { "VuforiaMars_VuMark" };
                config.Vuforia.MaxSimultaneousImageTargets = 10;
                break;
        }
    }

    #endregion // PUBLIC_METHODS

}
