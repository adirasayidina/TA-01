using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KuisScript : MonoBehaviour
{
    public Button[] buttons;
    public GameObject PilihJawaban;

    public Dictionary<string, Sprite> normalSpriteDict = new();
    public Dictionary<string, Sprite> SelectedSpriteDict = new();
    public Sprite[] normalSprite;
    public Sprite[] SelectedSprite;

    void Start() {
        print("hi kuis");
        print(StaticClass.QuizCode);
        foreach(Sprite spt in normalSprite) {
            normalSpriteDict.Add(spt.name, spt);
        }
        foreach(Sprite spt in SelectedSprite) {
            SelectedSpriteDict.Add(spt.name[..1], spt);
        }
    }
    public void ChangeImage(Button button)
    {
        if (button.image.sprite == normalSpriteDict[button.name])
        {
            foreach (Button btn in buttons)
            {
                if (btn.image.sprite == SelectedSpriteDict[btn.name])
                    btn.image.sprite = normalSpriteDict[btn.name];
            }
                button.image.sprite = SelectedSpriteDict[button.name];
                PilihJawaban.SetActive(true);
        }
        else
        {
            button.image.sprite = normalSpriteDict[button.name];
            PilihJawaban.SetActive(false);
        }
    }
}

