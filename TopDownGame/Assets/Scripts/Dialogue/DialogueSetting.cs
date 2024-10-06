using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Modificar o inspector da Unity
using UnityEditor;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "New Dialogue/Dialogue")]
public class DialogueSetting : ScriptableObject
{
    [Header("Settings")]
    public GameObject actor;

    [Header("Dialogue")]
    public Sprite speakerSprite;
    public string sentence;

    public List<Sentences> dialogues = new List<Sentences>();
}

[System.Serializable]
public class Sentences
{
    public string actorName;
    public Sprite profile;
    public Languages sentence;
}

[System.Serializable]
public class Languages
{
    public string portuguese;
    public string english;
    public string spanish;
}

// Criando botão no inspector
#if UNITY_EDITOR
[CustomEditor(typeof(DialogueSetting))]
public class BuilderEditor : Editor
{
    // Sobrescrever o que esta dentro deste metodo
    public override void OnInspectorGUI()
    {
        // Metodo para sobrescrever algo no inspector
        DrawDefaultInspector();

        DialogueSetting ds = (DialogueSetting)target;
        
        Languages l = new Languages();
        // Armazenando no string portuguese as falas
        l.portuguese = ds.sentence;

        Sentences s = new Sentences();
        s.profile = ds.speakerSprite;
        s.sentence = l;

        if(GUILayout.Button("Create Dialogue"))
        {
            if(ds.sentence != "")
            {
                // Armazenando na lista
                ds.dialogues.Add(s);

                ds.speakerSprite = null;
                ds.sentence = "";
            }
        }
    }
}


#endif
