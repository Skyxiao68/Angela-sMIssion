//ZASkip navigationSearchCreate9+Avatar image How to make a Dialogue System with Choices in Unity2D | Unity + Ink tutorial
//Shaped by Rain Studios
// Accessed 15 May 2025
//Version 4
//https://youtu.be/vY0Sk93YUhA?si=j-2sQNCayOO4pI2L



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoryWriter : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public GameObject Buttons;
    public GameObject Image1;
    public GameObject Image2;
    public GameObject Image3;
    public GameObject Image4;
    public GameObject angelaImage;

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

            if (index == 0)
            {
                Image1.SetActive(true);
                Image2.SetActive(false);
                Image3.SetActive(false);
                Image4.SetActive(false);
                angelaImage.SetActive(false);
            }
            if (index == 2)
            { 
                angelaImage.SetActive(true);
            }
            if (index == 3)
            {

            angelaImage.SetActive(false);
            }
            if (index == 4)
            {
                Image2.SetActive(true);
            }
            if (index == 7)
            {
                Image2.SetActive(false);
            }
            if (index == 11)
            {
                Image3.SetActive(true);
            }
            if(index == 12)
            {
                angelaImage.SetActive(true);
            }
            if (index == 14)
            {
                Image3 .SetActive(false);
                angelaImage.SetActive(false);
            }
            if (index == 15)
            { 
              Image4 .SetActive(true);
              angelaImage .SetActive(true);
            }           
        }
        else
        {
            Buttons.SetActive(true);
        }
    }
}
