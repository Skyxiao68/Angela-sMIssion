using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public GameObject Buttons;
   
    public GameObject black;
    public GameObject white;

    private int index;


    void Start()
    {
        Buttons.SetActive(false);
        textComponent.text = string.Empty;
        StartDialogue();
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
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        if (index == 0)
        {    black.SetActive(true);
            white.SetActive(false);
            Buttons.SetActive(false);
        } 
        if (index == 1)
        {
            black.SetActive(false);
            white.SetActive(true);
            Buttons.SetActive(true);
        }
        else
        {
            Buttons.SetActive(true);
        }
    }
}

