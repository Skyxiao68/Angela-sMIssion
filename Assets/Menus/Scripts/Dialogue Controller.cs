//ZASkip navigationSearchCreate9+Avatar image How to make a Dialogue System with Choices in Unity2D | Unity + Ink tutorial
//Shaped by Rain Studios
// Accessed 15 May 2025
//Version 4
//https://youtu.be/vY0Sk93YUhA?si=j-2sQNCayOO4pI2L



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueController : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public GameObject Buttons;

    private int index;

    
    void Start()
    {
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
        else
        {
            Buttons.SetActive(true);
        }
    }
}
