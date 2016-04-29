using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine.UI;
public class Dialoginator : MonoBehaviour {

    public TextAsset textfile = null;
    public string[] textlines = null;
    public Text thetextbox = null;
    public Text thetextheader = null;
    public int currentline = 0;
    public GameObject textbox = null;
    public Image[] portraits=new Image[5];
    // Use this for initialization
    void Start()
    {
        textlines=CSVReader.SplitCsvLine(textfile.text);
        List<string> templines=new List<string>();
        foreach (string line in textlines)
        {
            if(line.Length>0)
            templines.Add(line);
        }
        textlines = templines.ToArray();
    }
	// Update is called once per frame
	void Update () {
        bool enddialog = currentline < textlines.Length-1;
        if (thetextbox != null && thetextheader != null)
        {
            thetextbox.text = textlines[currentline];

        if(thetextbox.text.Length<=3)
        {
            switch(thetextbox.text)
            {
                case "W":
                    thetextbox.text = textlines[++currentline];
                    thetextheader.text = "Wallow";
                    portraits[0].enabled = true;
                    portraits[1].enabled = false;
                    portraits[2].enabled = false;
                    portraits[3].enabled = false;
                    portraits[4].enabled = false;
                    break;
                case "FB":
                    thetextbox.text = textlines[++currentline];
                    thetextheader.text = "Firebreather";
                    portraits[1].enabled = true;
                    portraits[0].enabled = false;
                    portraits[2].enabled = false;
                    portraits[3].enabled = false;
                    portraits[4].enabled = false;
                    break;
                case "LT":
                    thetextbox.text = textlines[++currentline];
                    thetextheader.text = "Liontamer";
                    portraits[2].enabled = true;
                    portraits[1].enabled = false;
                    portraits[0].enabled = false;
                    portraits[3].enabled = false;
                    portraits[4].enabled = false;
                    break;
                case "SS":
                    thetextbox.text = textlines[++currentline];
                    thetextheader.text = "Swordswallower";
                    portraits[3].enabled = true;
                    portraits[1].enabled = false;
                    portraits[2].enabled = false;
                    portraits[0].enabled = false;
                    portraits[4].enabled = false;
                    break;
                case "GR":
                    thetextbox.text = textlines[++currentline];
                    thetextheader.text = "All";
                    portraits[4].enabled = true;
                    portraits[1].enabled = false;
                    portraits[2].enabled = false;
                    portraits[0].enabled = false;
                    portraits[3].enabled = false;
                    break;
                default:
                    break;
            }
        }
        if(enddialog && Input.GetKeyDown(KeyCode.Return))
        {
            currentline++;
        }
       
        if (!enddialog&&textbox != null&&Input.GetKeyDown(KeyCode.Return))
        {
            textbox.SetActive(false);
        }
        }
	}
}
