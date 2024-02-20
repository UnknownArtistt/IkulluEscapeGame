using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcTutoDialogue : MonoBehaviour
{
    public Text dialogueText; 
    public GameObject dialoguePanel; 
    public string[] sentences; 
    private int index = 0; 
    public float typingSpeed = 0.02f; 

    private void Start()
    {
        dialoguePanel.SetActive(false); 
    }

    void Update()
    {
        /*if (dialoguePanel.activeInHierarchy && Input.GetKeyDown(KeyCode.E))
        {
            DisplayNextSentence();
        }*/

        if (dialoguePanel.activeInHierarchy && Input.GetButtonDown("Interaction"))
        {
            DisplayNextSentence();
        }
    }


    private void UpdateDialogueText(string sentence)
    {
        dialogueText.text = sentence; 
        
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            dialoguePanel.SetActive(true); 
            NextSentence(); 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            dialoguePanel.SetActive(false); 
            index = 0; 
        }
    }

    public void NextSentence()
    {
        if (index < sentences.Length)
        {
            UpdateDialogueText(sentences[index]);
            index++;
        }
        else
        {
            dialoguePanel.SetActive(false); 
            index = 0; 
        }
    }

    // Llama a este método desde un botón en tu UI para pasar al siguiente diálogo.
    public void DisplayNextSentence()
    {
        if (dialoguePanel.activeInHierarchy)
        {
            NextSentence();
        }
    }
}
