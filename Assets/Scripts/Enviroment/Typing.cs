using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class Typing: MonoBehaviour
{
    public TMP_InputField inputField;
    public TextMeshProUGUI targetText; // Un Text UI donde se muestra la palabra objetivo.
    private string currentWord = ""; // La palabra objetivo actual.

    public TMP_FontAsset Alien;
    private float R=0.2352f, G=0.0549f, B=0.1058f;
    int previousSize = 0;
    private bool _isParentCursed = true;
    public int curse;
    Color _initialColor;

    private void Start()
    {
        // // Configura un evento para detectar cambios en el InputField en tiempo real.
        inputField.onValueChanged.AddListener(OnInputValueChanged);
        _initialColor = new Color(R,G,B,255);
        
        // // Inicializa el juego generando una palabra objetivo aleatoria.
        GenerateRandomWord();
    }
    private void Recolor(int i, bool correction){
        if(curse == 1){
                int meshIndex = targetText.textInfo.characterInfo[i].materialReferenceIndex;
                int vertexIndex = targetText.textInfo.characterInfo[i].vertexIndex;
                Color32[] vertexColors = targetText.textInfo.meshInfo[meshIndex].colors32;
            if(correction){
                vertexColors[vertexIndex + 0] = Color.green;
                vertexColors[vertexIndex + 1] = Color.green;
                targetText.UpdateVertexData(TMP_VertexDataUpdateFlags.All);
            }else{
                vertexColors[vertexIndex + 0] = Color.red;
                vertexColors[vertexIndex + 1] = Color.red;
                targetText.UpdateVertexData(TMP_VertexDataUpdateFlags.All);
            }
        }else if(curse == 2){
            int meshIndex = targetText.textInfo.characterInfo[currentWord.Length-i-1].materialReferenceIndex;
            int vertexIndex = targetText.textInfo.characterInfo[currentWord.Length-i-1].vertexIndex;
            Color32[] vertexColors = targetText.textInfo.meshInfo[meshIndex].colors32;
            if(correction){
                vertexColors[vertexIndex + 0] = Color.green;
                vertexColors[vertexIndex + 1] = Color.green;
                targetText.UpdateVertexData(TMP_VertexDataUpdateFlags.All);
            }else{
                vertexColors[vertexIndex + 0] = Color.red;
                vertexColors[vertexIndex + 1] = Color.red;
                targetText.UpdateVertexData(TMP_VertexDataUpdateFlags.All);
            }
        }
    }
    private void OnInputValueChanged(string userInput)
    {   
        
        if(!_isParentCursed){
            return;
        }
        char[] stringArray = currentWord.ToCharArray();//MEJORABLE
        Array.Reverse(stringArray);
        string reversed = new string(stringArray);
        if(curse ==4){
            targetText.font = Alien;
        }

        if(inputField.text == ""){
            targetText.color = Color.red; 
            targetText.UpdateVertexData(TMP_VertexDataUpdateFlags.All);
        }else if(previousSize > userInput.Length){
            if(curse == 1){
                //Debug.Log(userInput.Length);
                int meshIndex = targetText.textInfo.characterInfo[userInput.Length].materialReferenceIndex;
                int vertexIndex = targetText.textInfo.characterInfo[userInput.Length].vertexIndex;
                Color32[] vertexColors = targetText.textInfo.meshInfo[meshIndex].colors32;
                vertexColors[vertexIndex + 0] = _initialColor;
                vertexColors[vertexIndex + 1] = _initialColor;
                targetText.UpdateVertexData(TMP_VertexDataUpdateFlags.All);
            }
            if (curse == 2){
                //Debug.Log(userInput.Length);
                int meshIndex = targetText.textInfo.characterInfo[currentWord.Length-userInput.Length-1].materialReferenceIndex;
                int vertexIndex = targetText.textInfo.characterInfo[currentWord.Length-userInput.Length-1].vertexIndex;
                Color32[] vertexColors = targetText.textInfo.meshInfo[meshIndex].colors32;
                vertexColors[vertexIndex + 0] = _initialColor;
                vertexColors[vertexIndex + 1] = _initialColor;
                targetText.UpdateVertexData(TMP_VertexDataUpdateFlags.All);
            }
            
        }
        else if(curse!=3){
            if (userInput[userInput.Length-1]==currentWord[userInput.Length-1] && curse == 1){
                Recolor(userInput.Length-1, true);
                
            }else if(curse == 1){
                Recolor(userInput.Length-1, false);
            }else if(userInput[userInput.Length-1]==reversed[userInput.Length-1] && curse == 2){
                Recolor(userInput.Length-1, true);
            }else if(curse == 2){
                Recolor(userInput.Length-1, false);
            }
        }
        // Compara el texto ingresado por el usuario con la palabra objetivo actual.
        if ((userInput == currentWord && curse == 1) || (userInput == reversed && curse == 2) || (userInput.Length >=30 && curse == 3))
        {
            Debug.Log("¡Correcto! Palabra completada: " + currentWord);
            // Realiza las acciones necesarias cuando el usuario completa la palabra.
            inputField.text = ""; // Limpia el campo de entrada de texto.
            GetComponentInParent<Package>().isCursed = false;
            _isParentCursed = false;
            GetComponentInParent<Package>().DeactivateCurse();
            return;
        }
        previousSize = userInput.Length;
    }

    private void GenerateRandomWord()
    {
        // Aquí puedes implementar la lógica para generar una nueva palabra objetivo aleatoria.
        // Por ejemplo, puedes mantener una lista de palabras y elegir una al azar.
        // Luego, establece esa palabra como la palabra objetivo actual y muestra en el Text UI.
        currentWord = GetRandomWord();
        targetText.text = currentWord;
        if(curse ==4){
            targetText.font = Alien;
        }else{
            //targetText.color = _initialColor; 
        }
        

    }

    private string GetRandomWord()
    {
        // Aquí puedes implementar la lógica para obtener una palabra aleatoria de tu lista de palabras.
        // Este es solo un ejemplo simple.
        string[] wordList = { "iratze", "parabatai", "sanger", "nuntius", "catullus" };
        int randomIndex = UnityEngine.Random.Range(0, wordList.Length);
        return wordList[randomIndex];
    }
}
