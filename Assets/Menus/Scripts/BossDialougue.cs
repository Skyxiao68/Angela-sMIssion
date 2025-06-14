using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BossDialougue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public GameObject Buttons;
    public GameObject angela;
    public GameObject boss;
    public GameObject molina;
    public GameObject back;
    private int index;


    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
        angela.SetActive(false);
        molina.SetActive(false);
        boss.SetActive(false);
        Buttons.SetActive(false);
        AudioListener.volume = 0;
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        Buttons.SetActive(true);
        if (index >= lines.Length - 1) ;
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
            if (index == 0)
            {
                angela.SetActive(false);
                molina.SetActive(false);
                boss.SetActive(false);
            }

            if (index == 1)
            {
                boss.SetActive(true);
               
            }
            if (index == 2)
            {
                boss.SetActive(false);
            }
            if (index == 3)
            {
                boss.SetActive(true) ;
            }
            if (index == 4)
            {
                angela.SetActive(true);
                boss.SetActive(false) ;
            }
            if (index == 5)
            {
                angela.SetActive(false);
                boss.SetActive(true) ;
            }
            if (index == 6)
            {
                boss.SetActive(false);
            }
            if (index == 7)
            {
                angela.SetActive(true);
            }
            if (index == 8) 
            {
                boss.SetActive(true);
                angela.SetActive(false);
            }
            if (index == 10)
            {
                angela.SetActive(true);
                boss.SetActive(false);
            }
           if (index == 12)
            {
                angela.SetActive(false);
                boss.SetActive(true) ;
            }
           if (index == 13)
            {
                angela.SetActive(false);
                boss.SetActive (false);
            }
           if (index == 14)
            {
                angela.SetActive(true);
            }
            else
            {
                Buttons.SetActive(true);
            }
        }
    }
}
