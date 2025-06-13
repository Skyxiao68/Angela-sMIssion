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
        if (index < lines.Length - 1)
        {
            angela.SetActive(false);
            molina.SetActive(false);
            boss.SetActive(false);
            back.SetActive(true);
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }

        if (index == 1)
        {
            molina.SetActive(false);
            angela.SetActive(true);
            boss.SetActive(false);
        }
        if (index== 2)
        {
            angela.SetActive(false);
            molina.SetActive(true);
            boss.SetActive(false);
        }
        if (index== 3)
        {
            molina.SetActive(false);
            boss.SetActive(true);
            angela.SetActive(false) ;
        }
        if (index == 4)
        {
            angela.SetActive(false);
            molina.SetActive(false);
            boss.SetActive(false);
        }
        else
        {
            Buttons.SetActive(true);
        }
    }
}
