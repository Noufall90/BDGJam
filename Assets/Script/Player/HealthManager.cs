using UnityEngine;
using UnityEngine.UI;
public class HealthManager : MonoBehaviour
{
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public static int health = 3;
    public static int number;


    void Awake(){
        health = 3;
    }
    // Update is called once er frame
    void Update()
    {
        foreach (Image img in hearts)
        {
            img.sprite = emptyHeart;
        }
        for (int i = 0; i < health; i++)
        {
            hearts[i].sprite = fullHeart;
        }
    }
}
