using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PL_Lore_PrintLore : MonoBehaviour
{
    [SerializeField] private List<string> text;
    private TextMeshProUGUI dialogueText;
    private string currentSentence;

    private void Awake()
    {
        dialogueText = GetComponent<TextMeshProUGUI>();
        currentSentence = text[0];
        StartCoroutine(TypeSentence(currentSentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.01f);
        }
    }

    public void OnSelect(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {

            StopAllCoroutines();
            print(text.IndexOf(currentSentence));
            if (text.IndexOf(currentSentence)+1 >= text.Count)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                return;
            }

            currentSentence = text[text.IndexOf(currentSentence) + 1];
            StartCoroutine(TypeSentence(currentSentence));
        }
    }
}
