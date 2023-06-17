using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Serialization;

public class ChangeText : MonoBehaviour
{   
    public TextMeshProUGUI ort;

    public TextMeshProUGUI title;

    public TextMeshProUGUI partner;

    public TextMeshProUGUI gefordertDurch;

    public TextMeshProUGUI distanzNachMainz;

    public Button openLinkButton;
    
    public void OpenLink()
    {
        Application.OpenURL(url);
    }
    public static double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
    {
        const double radius = 6371; // Earth's radius in kilometers

        double lat1Rad = ToRadians(lat1);
        double lon1Rad = ToRadians(lon1);
        double lat2Rad = ToRadians(lat2);
        double lon2Rad = ToRadians(lon2);

        double deltaLat = lat2Rad - lat1Rad;
        double deltaLon = lon2Rad - lon1Rad;

        double a = Math.Sin(deltaLat / 2) * Math.Sin(deltaLat / 2) +
                   Math.Cos(lat1Rad) * Math.Cos(lat2Rad) *
                   Math.Sin(deltaLon / 2) * Math.Sin(deltaLon / 2);

        double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

        double distance = radius * c;
        distance = Math.Round(distance, 2);;
        return distance;
    }
    public string url;

    private static double ToRadians(double degrees)
    {
        return degrees * Math.PI / 180;
    }
    
    
    string[,] zimbabweData = {
        {"Zimbabwe (Afrika)", "-17.783517", "31.053044", "The Past in the Present: The Zimbabwe Culture Archaeological Heritage in Western Zimbabwe", "University of Zimbabwe", "VolkswagenStiftung", "https://i3mainz.hs-mainz.de/projekte/zimbabwe/"}
    };

    string[,] hafenstadtAinosData = {
        {"Hafenstadt Ainos (Türkei)", "40.720885", "26.089775", "Dokumentationsarbeiten in der thrakischen Hafenstadt Ainos (Türkei)", "Leibniz-Zentrum für Archäologie (LEIZA)", "", "https://i3mainz.hs-mainz.de/projekte/dokumentationsarbeiten-ainos/"}
    };

    string[,] germollesData = {
        {"Château de Germolles (Frankreich)", "46.8058358", "4.7491426", "Monitoring an historischem Stück mittels Streifenlichtprojektor am Château de Germolles", "Sarl Germolles", "Sarl Germolles", "https://i3mainz.hs-mainz.de/projekte/germolles/"}
    };

    string[,] eskiKermenData = {
        {"Eski-Kermen und Mangup-Kale (Krim)", "44.6087861", "33.6042607", "Dreidimensionale Dokumentationsverfahren in der Archäologie und ihre Anwendung im Bergland der Krim / Ukraine", "Leibniz-Zentrum für Archäologie (LEIZA)", "", "https://i3mainz.hs-mainz.de/projekte/dokumentation-bergland-krim-ukraine/"}
    };

    string[,] monteBisenzioData = {
        {"Monte Bisenzio (Italien)", "42.5734443", "11.8803579", "Bisenzio. Multi-disziplinäre Erforschung eines bedeutenden etruskischen Zentrums von der jüngeren Bronzezeit bis in die Archaische Periode", "Leibniz-Zentrum für Archäologie (LEIZA)", "DFG", "https://i3mainz.hs-mainz.de/projekte/bisenzio/"}
    };

    string[,] qatnaData = {
        {"Qatna (Syrien)", "34.8892782", "36.5172377", "Mediale Verdeutlichung der Ergebnisse und Tätigkeiten im Kontext der archäologischen Ausgrabung zu Qatna", "Universität Tübingen", "DFG", "https://i3mainz.hs-mainz.de/projekte/mediale-verdeutlichung-qatna/"}
    };
    
    // Start is called before the first frame update
    void Start()
    {
        string location = PlayerPrefs.GetString("infoPointer");
        if (location == null)
        {
            location = "Zimbabwe";
        }
        string[,] data = new string[,] { };
        switch (location)
        {
            case "Zimbabwe":
                data = zimbabweData;
                // Perform specific operations with zimbabweData
                break;

            case "Türkei":
                data = hafenstadtAinosData;
                // Perform specific operations with hafenstadtAinosData
                break;

            case "France":
                data = germollesData;
                // Perform specific operations with germollesData
                break;

            case "Krim":
                data = eskiKermenData;
                // Perform specific operations with eskiKermenData
                break;

            case "Italien":
                data = monteBisenzioData;
                // Perform specific operations with monteBisenzioData
                break;

            case "Syrien":
                data = qatnaData;
                // Perform specific operations with qatnaData
                break;

            default:
                // Handle the case when the "Ort" value is not recognized
                break;
        }


        
        ort.text = data[0,0];
        title.text = data[0, 3];
        partner.text = "Partner:\n"+ data[0, 4];
        gefordertDurch.text ="Gefördert Durch " +data[0, 5];
        print(double.Parse(data[0, 2]));
       // print(CalculateDistance(49.9929, 8.2473, double.Parse(data[0, 2]), double.Parse(data[0, 3])));
       String dis= String.Format("{0}",CalculateDistance(49.9929, 8.2473, double.Parse(data[0, 1] ),double.Parse(data[0, 2] )));
       
       distanzNachMainz.text = dis+" Km entfernung nach Mainz";
       url = data[0,6];
       openLinkButton.onClick.AddListener(OpenLink);
       openLinkButton.GetComponentInChildren<TextMeshProUGUI>().text = data[0, 6];
    }

    

    
    

    // Update is called once per frame

}
