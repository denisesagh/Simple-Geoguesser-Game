using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour
{   
    public TextMeshProUGUI ort;

    public TextMeshProUGUI title;

    public TextMeshProUGUI partner;

    public TextMeshProUGUI gefordertDurch;
    
    
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
        string location = PlayerPrefs.GetString("location");
        if (location == null)
        {
            location = "Zimbabwe";
        }
        string[,] data = new string[,] { };
        print(location);
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
        partner.text = data[0, 4];
        gefordertDurch.text = data[0, 5];
    }

    // Update is called once per frame

}
