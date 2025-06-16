using System.Collections;
using TMPro;
using UnityEngine;

public class WinCutscene : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public GameObject Buttons;
    public GameObject angela;
    public GameObject molina;
    public GameObject boss;
    public GameObject win;
    public GameObject back;
    public GameObject outside;
    public GameObject playerUi; 

    private int index;


    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
        Buttons.SetActive(false);
        Buttons.SetActive(false);
        boss.SetActive(false);
        molina.SetActive(false);
        angela.SetActive(false);
        back.SetActive(true);
        win.SetActive(false);
        outside.SetActive(false);
        playerUi.SetActive(false);

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
        Buttons.SetActive(false);
        boss.SetActive(false);
        molina.SetActive(false);
        angela.SetActive(false);
        back.SetActive(true);
        win.SetActive(false);
        outside.SetActive(false);

        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        if (index == 0)
        {
            Buttons.SetActive(false);
            boss.SetActive(false);
            molina.SetActive(false);
            angela.SetActive(false);
            back.SetActive(true);
            win.SetActive(false);
            outside.SetActive(false);



        }
        if (index == 1)
        {
            Buttons.SetActive(false);
            boss.SetActive(true);
        }
        if (index == 2)
        {
            Buttons.SetActive(false);
            boss.SetActive(false);
            angela.SetActive(true);

        }
        if (index == 3)
        {
            Buttons.SetActive(false);
            boss.SetActive(true);
            angela.SetActive(false);
        }
        if (index == 4)
        {
            Buttons.SetActive(false);
            boss.SetActive(true);
            angela.SetActive(false);
        }
        if (index == 5)
        {
            Buttons.SetActive(false);
            boss.SetActive(true);


        }
        if (index == 6)
        {
            Buttons.SetActive(false);
            boss.SetActive(true);
        }
        if (index == 7)
        {
            Buttons.SetActive(false);
            boss.SetActive(true);
            angela.SetActive(false);
        }
        if (index == 8)
        {
            Buttons.SetActive(false);
            boss.SetActive(false);
            angela.SetActive(true);
        }
        if (index == 9)
        {
            Buttons.SetActive(false);
            boss.SetActive(true);
            angela.SetActive(false);
        }
        if (index == 10)
        {
            Buttons.SetActive(false);
            boss.SetActive(true);
        }
        if (index == 11)
        {
            Buttons.SetActive(false);
            boss.SetActive(false);
        }
        if (index == 12)
        {
            Buttons.SetActive(false);
            angela.SetActive(true);

        }
        if (index == 13)
        {
            Buttons.SetActive(false);
            angela.SetActive(true);
        }
        if (index == 14)
        {
            Buttons.SetActive(false);
            molina.SetActive(true);
            angela.SetActive(false);
        }
        if (index == 15)
        {
            Buttons.SetActive(false);
            angela.SetActive(false);
            molina.SetActive(false);
        }
        if (index == 16)
        {
            Buttons.SetActive(false);
            molina.SetActive(true);

        }
        if (index == 17)
        {
            Buttons.SetActive(false);
            angela.SetActive(true);
            molina.SetActive(false);
        }
        if (index == 18)
        {
            Buttons.SetActive(false);
            outside.SetActive(true);
            back.SetActive(false);
            angela.SetActive(true);
        }
        if (index == 19)
        {
            Buttons.SetActive(false);
            angela.SetActive(false);
            molina.SetActive(true);
            outside.SetActive(true) ;
            back.SetActive(false);
        }
        if (index == 20) 
        {
            Buttons.SetActive(true);
            win.SetActive(true);
            outside.SetActive(false);
        } 
        if (index == 21)
        {
            Buttons.SetActive(true);
        }
       
    }
}
