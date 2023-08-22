using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace OpenAI
{
    public class TextCompletionChat : MonoBehaviour
    {
        [SerializeField] private InputField inputField;
        [SerializeField] private Button button;
        [SerializeField] private ScrollRect scroll;
        
        [SerializeField] private RectTransform sent;
        [SerializeField] private RectTransform received;

        private float height;

        //specify no key since we are using gpt4all server
        private OpenAIApi openai = new OpenAIApi("not needed for a local LLM");

        private string userInput;
        private string prompt = "Act as the dungeon master for a game of dungeons and dragons.\nQ: ";
        
        private void Start()
        {
            button.onClick.AddListener(SendReply);
        }
        
        //adds the user's prompt from the window to the payload.
        private void AppendMessage(string message, bool isUser = true)
        {
            scroll.content.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 0);

            var item = Instantiate(isUser ? sent : received, scroll.content);
            item.GetChild(0).GetChild(0).GetComponent<Text>().text = message;
            item.anchoredPosition = new Vector2(0, -height);
            LayoutRebuilder.ForceRebuildLayoutImmediate(item);
            height += item.sizeDelta.y;
            scroll.content.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
            scroll.verticalNormalizedPosition = 0;
        }

        
        private async void SendReply()
        {
            userInput = inputField.text;
            prompt += $"{userInput}\nA: ";
            AppendMessage(userInput);
            
            button.enabled = false;
            inputField.text = "";
            inputField.enabled = false;
            
            // Complete the instruction
            var completionResponse = await openai.CreateCompletion(new CreateCompletionRequest()
            {
                Prompt = prompt,
                Model = "ggml-model-gpt4all-falcon-q4_0.bin",
                MaxTokens = 128,
                Temperature = 0.28f,
                TopP = 0.95f,
                N = 1,
                Echo = true,
                Stream = false
            });

            if (completionResponse.Choices != null && completionResponse.Choices.Count > 0)
            {
                AppendMessage(completionResponse.Choices[0].Text, false);
                prompt += $"{completionResponse.Choices[0].Text}\nQ: ";
            }
            else
            {
                Debug.LogWarning("No text was generated from this prompt.");
            }

            button.enabled = true;
            inputField.enabled = true;
        }
    }
}
