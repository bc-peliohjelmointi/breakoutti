using System;
using UnityEngine;
using UnityEngine.UI;

public class palikkaSpawn : MonoBehaviour
{
    public GameObject palikkaPrefab;
    public GameObject palikkaAP;
    public Text Scoretext;
    private int Score;
    public int palikoidenmäärä = 0;
    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
        GameObject TextUi = GameObject.Find("ScoreText");
        Scoretext = TextUi.GetComponent<Text>();
        for (int rivi = 0; rivi < 5; rivi++)
        {
            Vector3 pistäpalikka = palikkaAP.transform.position;
            pistäpalikka.y += rivi * -1.0f;
            for (int i = 0; i < 12; i++)
            {
                GameObject palikka = Instantiate(palikkaPrefab, pistäpalikka, Quaternion.identity);
                palikka.GetComponent<Palikat>().BlockDestroyedevent += OnBlockDestroy;
                pistäpalikka.x += 1.7f;
                palikoidenmäärä++;
            }


        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnBlockDestroy(object sender, EventArgs e)
    {
        if (Scoretext != null)
        {
            Score++;
            palikoidenmäärä--;
            Scoretext.text = $"Score: {Score}";
        }
        if(palikoidenmäärä == 0)
        {
            Scoretext.text = "You win";
        }
    }
}
