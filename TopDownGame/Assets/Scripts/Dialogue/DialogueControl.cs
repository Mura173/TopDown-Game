using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    [Header("Components")]
    public GameObject dialogueObj; // Janela do dialogo
    public Image profileSprite; // Sprite do perfil
    public Text speechText; // Texto da fala
    public Text actorNameText; // Nome do npc

    [Header("Settings")]
    public float typingSpeed; // Velocidade da fala

    // Variaveis de controle
    private bool isShowing; // Se a janela esta visivel
    private int index; // Index das falas
    private string[] sentences;

    public static DialogueControl instance;

    // Awake e chamado antes de todos os starts na hierarquia de execucao de scripts
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TypeSentence()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    // Pular para proxima fala
    public void NextSentence()
    {

    }

    // Chamar a fala do npc
    public void Speech(string[] txt)
    {
        if (!isShowing)
        {
            dialogueObj.SetActive(true);
            sentences = txt;
            StartCoroutine(TypeSentence());
            isShowing = true;
        }
    }
}
