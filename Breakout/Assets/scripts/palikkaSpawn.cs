using System;
using UnityEngine;
using UnityEngine.UI;

public class palikkaSpawn : MonoBehaviour
{
    public GameObject palikkaPrefab;
    public GameObject palikkaAP;
    public Text Scoretext;
    private int Score;
    public int palikoidenm‰‰r‰ = 0;
    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
        GameObject TextUi = GameObject.Find("ScoreText");
        Scoretext = TextUi.GetComponent<Text>();
        for (int rivi = 0; rivi < 5; rivi++)
        {
            Vector3 pist‰palikka = palikkaAP.transform.position;
            pist‰palikka.y += rivi * -1.0f;
            for (int i = 0; i < 12; i++)
            {
                GameObject palikka = Instantiate(palikkaPrefab, pist‰palikka, Quaternion.identity);
                palikka.GetComponent<Palikat>().BlockDestroyedevent += OnBlockDestroy;
                pist‰palikka.x += 1.7f;
                palikoidenm‰‰r‰++;
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
            palikoidenm‰‰r‰--;
            Scoretext.text = $"Score: {Score}";
        }
        if(palikoidenm‰‰r‰ == 0)
        {
            Scoretext.text = "You win";
        }
    }
}
