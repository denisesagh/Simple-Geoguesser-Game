using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeoGuessGameStartScript : MonoBehaviour
{
  
    public Material[] skyboxMaterial;

    private void Start()
    {
        print("Game started");
        SelectRandomImage();
   
    }

    private void SelectRandomImage()
    {
        if (skyboxMaterial.Length > 0)
        {
            int randomIndex = Random.Range(0, skyboxMaterial.Length);
            print("Index: " + randomIndex);

            switch (randomIndex)
            {
                case 0:
                    PlayerPrefs.SetString("location", "Türkei");
                    break;
                case 1:
                    PlayerPrefs.SetString("location", "France");
                    break;
                case 2:
                    PlayerPrefs.SetString("location", "Italien");
                    break;
                case 3:
                    PlayerPrefs.SetString("location", "Krim");
                    break;
                case 4:
                    PlayerPrefs.SetString("location", "Syrien");
                    break;
                case 5:
                    PlayerPrefs.SetString("location", "Zimbabwe");
                    break;
            }

            Material selectedImage = skyboxMaterial[randomIndex];

            if (skyboxMaterial != null)
            {

                RenderSettings.skybox = selectedImage;
                print("Picture set");
            }
            else
            {
                Debug.LogError("Skybox-Material ist nicht zugewiesen. Bitte weisen Sie es im Unity-Editor zu.");
            }
        }
        else
        {
            Debug.LogError("Es wurden keine 360-Grad-Bilder zugewiesen. Bitte fügen Sie sie im Unity-Editor hinzu.");
        }
    }


}