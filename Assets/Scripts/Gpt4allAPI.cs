using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Runtime.CompilerServices;
//using OpenAI;



namespace OpenAI
{
    public class Gpt4allAPI : MonoBehaviour
    {
        //fields for UI components
        [SerializeField] private ScrollRect scrollRect;
        [SerializeField] private TMP_Text conversationText;
        [SerializeField] private TMP_InputField inputField;
        [SerializeField] private Button sendButton;
        [SerializeField] private Button clearButton;
        //Text color for the player and bot
        [SerializeField] private Color userTextColor = Color.blue;
        [SerializeField] private Color botTextColor = Color.black;
        //Navigation buttons
        [SerializeField] private Button upButton;
        [SerializeField] private Button downButton;
        [SerializeField] private Button leftButton;
        [SerializeField] private Button rightButton;

        [SerializeField] private string parsedOutput;
 

        //Fields to store the player's name and selected class
        private string classText;
        private string nameText;

        //Store color
        private string userColorHex;
        private string botColorHex;
        private string errorColorHex;

        //Bool used when waiting for a response from the language model
        [SerializeField] private bool isWaitingForResponse;

        
 
        //on Load
        private void Awake()
        {
            //set colors. Note that the error color hex is hard-coded. No real reason, Red just works.
            userColorHex = ColorUtility.ToHtmlStringRGB(userTextColor);
            botColorHex = ColorUtility.ToHtmlStringRGB(botTextColor);
            errorColorHex = ColorUtility.ToHtmlStringRGB(Color.red);

            //If we have a selected class, (we always should)
            if (PlayerPrefs.HasKey("SelectedClass"))
            {
                //Get the string
                classText = PlayerPrefs.GetString("SelectedClass");
            }
            //Get the name of the player
            nameText = CharacterScene.characterscene.player_name;
        }

        private void Start()
        {
            //Listeners for input field, activate the input field.
            sendButton.onClick.AddListener(SendButtonClicked);
            clearButton.onClick.AddListener(ClearButtonClicked);
            inputField.ActivateInputField();
            inputField.onEndEdit.AddListener(OnInputFieldEndEdit);

            //Sends an inital query to start off the scene.
            SendInitialQuery();
        }

        //Make arrow keys on keyboard work for movement.
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                SendLeftQuery();
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                SendRightQuery();
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                SendUpQuery();
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                SendDownQuery();
            }
        }

        //When clicking the send button
        private void SendButtonClicked()
        {
            SendQuery();
        }
        //when clicking the up arrow
        public void UpNavButtonClicked()
        {
            SendUpQuery();
        }
        //when clicking the down arrow
        public void DownNavButtonClicked()
        {
            SendDownQuery();
        }
        //when clicking the left arrow
        public void LeftNavButtonClicked()
        {
            SendLeftQuery();
        }
        //when clicking the right arrow
        public void RightNavButtonClicked()
        {
            SendRightQuery();
        }

        //Sends the query if the user clicks enter/return
        private void OnInputFieldEndEdit(string text)
        {
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                SendQuery();
            }
        }

        //method for sending the query to the API
        public async void SendQuery()
        {
            if (isWaitingForResponse) return;

            //the user-entered text
            string inputText = inputField.text;
            if (string.IsNullOrEmpty(inputText))
            {
                return;
            }

            isWaitingForResponse = true;
            inputField.interactable = false;
            sendButton.interactable = false;
            inputField.text = "";

            upButton.interactable = false;
            downButton.interactable = false;
            leftButton.interactable = false;
            rightButton.interactable = false;

            conversationText.text += $"<color=#{userColorHex}>You: {inputText}</color>\n";
            conversationText.text += "Bot is typing...\n";

            Canvas.ForceUpdateCanvases();
            scrollRect.verticalNormalizedPosition = 0f;

            //api call
            var openai = new OpenAIApi("not needed for a local LLM");
            var request = new CreateCompletionRequest
            {
                Model = "ggml-model-gpt4all-falcon-q4_0",
                Prompt = inputText,
                MaxTokens = 150,
                Temperature = 0.28f,
                TopP = 0.95f,
                N = 1,
                Echo = true,
                Stream = false
            };

            var response = await openai.CreateCompletion(request);
            

            //If the model generates too much and has an incomplete response
            //This logic stops the model from generating incomplete responses at the cost of the user needing to wait sometimes.
            if (response.Choices[0].FinishReason == "length")
            {
                parsedOutput = "The model generated too much... lets try that again. please be patient!";

                conversationText.text = conversationText.text.TrimEnd("Bot is typing...\n".ToCharArray());
                conversationText.text += $"\n<color=#{botColorHex}>Bot: {parsedOutput}</color>\n\n";


                openai = new OpenAIApi("not needed for a local LLM");
                request = new CreateCompletionRequest
                {
                    Model = "ggml-model-gpt4all-falcon-q4_0",
                    Prompt = inputText + " (shorten the response).",
                    MaxTokens = 100,
                    Temperature = 0.28f,
                    TopP = 0.95f,
                    N = 1,
                    Echo = true,
                    Stream = false
                };
                response = await openai.CreateCompletion(request);
            }

            //generated output
            parsedOutput = response.Choices[0].Text;

            string cleanedOutput = parsedOutput.Replace(inputText, "");
            cleanedOutput.Replace("\n", "");

            //this happens after we get a response
            conversationText.text = conversationText.text.TrimEnd("Bot is typing...\n".ToCharArray());
            conversationText.text += $"\n<color=#{botColorHex}>Bot: {cleanedOutput}</color>\n\n";
            inputField.interactable = true;
            sendButton.interactable = true;
            inputField.ActivateInputField();
            isWaitingForResponse = false;
            Canvas.ForceUpdateCanvases();
            scrollRect.verticalNormalizedPosition = 0f;

            upButton.interactable = true;
            downButton.interactable = true;
            leftButton.interactable = true;
            rightButton.interactable = true;

        }

        public async void SendInitialQuery()
        {
            if (isWaitingForResponse) return;

            //the text to be sent
            string inputText = "Lets play a game of D&D! You are the dungeon master. " +
                "I am " + nameText + " the " + classText + ".";
            
            isWaitingForResponse = true;
            inputField.interactable = false;
            sendButton.interactable = false;
            inputField.text = "";

            upButton.interactable = false;
            downButton.interactable = false;
            leftButton.interactable = false;
            rightButton.interactable = false;


            //conversationText.text += $"<color=#{userColorHex}>You: {inputText}</color>\n";
            conversationText.text += "Bot is typing...\n";

            Canvas.ForceUpdateCanvases();
            scrollRect.verticalNormalizedPosition = 0f;

            //api call
            var openai = new OpenAIApi("not needed for a local LLM");
            var request = new CreateCompletionRequest
            {
                Model = "ggml-model-gpt4all-falcon-q4_0",
                Prompt = inputText,
                MaxTokens = 130,
                Temperature = 0.20f,
                TopP = 0.95f,
                N = 1,
                Echo = true,
                Stream = false
            };

            var response = await openai.CreateCompletion(request);

            parsedOutput = response.Choices[0].Text;
            string cleanedOutput = parsedOutput.Replace(inputText, "");
            cleanedOutput.Replace("\n", "");


            //this happens after we get a response
            conversationText.text = conversationText.text.TrimEnd("Bot is typing...\n".ToCharArray());
            conversationText.text += $"\n<color=#{botColorHex}>Bot: {cleanedOutput}</color>\n\n";
            inputField.interactable = true;
            sendButton.interactable = true;
            inputField.ActivateInputField();
            isWaitingForResponse = false;
            Canvas.ForceUpdateCanvases();
            scrollRect.verticalNormalizedPosition = 0f;

            upButton.interactable = true;
            downButton.interactable = true;
            leftButton.interactable = true;
            rightButton.interactable = true;
        }


        public async void SendUpQuery()
        {
            if (isWaitingForResponse) return;

            //the text to be sent
            string inputText = "I walk forward.";

            isWaitingForResponse = true;
            inputField.interactable = false;
            sendButton.interactable = false;
            inputField.text = "";

            upButton.interactable = false;
            downButton.interactable = false;
            leftButton.interactable = false;
            rightButton.interactable = false;


            conversationText.text += $"<color=#{userColorHex}>You: {inputText}</color>\n";
            conversationText.text += "Bot is typing...\n";

            Canvas.ForceUpdateCanvases();
            scrollRect.verticalNormalizedPosition = 0f;

            //api call
            var openai = new OpenAIApi("not needed for a local LLM");
            var request = new CreateCompletionRequest
            {
                Model = "ggml-model-gpt4all-falcon-q4_0",
                Prompt = inputText,
                MaxTokens = 100,
                Temperature = 0.28f,
                TopP = 0.95f,
                N = 1,
                Echo = true,
                Stream = false
            };

            var response = await openai.CreateCompletion(request);

            parsedOutput = response.Choices[0].Text;
            string cleanedOutput = parsedOutput.Replace(inputText, "");
            cleanedOutput.Replace("\n", "");

            //this happens after we get a response
            conversationText.text = conversationText.text.TrimEnd("Bot is typing...\n".ToCharArray());
            conversationText.text += $"\n<color=#{botColorHex}>Bot: {cleanedOutput}</color>\n\n";
            inputField.interactable = true;
            sendButton.interactable = true;
            inputField.ActivateInputField();
            isWaitingForResponse = false;
            Canvas.ForceUpdateCanvases();
            scrollRect.verticalNormalizedPosition = 0f;

            upButton.interactable = true;
            downButton.interactable = true;
            leftButton.interactable = true;
            rightButton.interactable = true;
        }

        public async void SendDownQuery()
        {
            if (isWaitingForResponse) return;

            //the text to be sent
            string inputText = "I turn around.";

            isWaitingForResponse = true;
            inputField.interactable = false;
            sendButton.interactable = false;
            inputField.text = "";

            upButton.interactable = false;
            downButton.interactable = false;
            leftButton.interactable = false;
            rightButton.interactable = false;


            conversationText.text += $"<color=#{userColorHex}>You: {inputText}</color>\n";
            conversationText.text += "Bot is typing...\n";

            Canvas.ForceUpdateCanvases();
            scrollRect.verticalNormalizedPosition = 0f;

            //api call
            var openai = new OpenAIApi("not needed for a local LLM");
            var request = new CreateCompletionRequest
            {
                Model = "ggml-model-gpt4all-falcon-q4_0",
                Prompt = inputText,
                MaxTokens = 100,
                Temperature = 0.28f,
                TopP = 0.95f,
                N = 1,
                Echo = true,
                Stream = false
            };

            var response = await openai.CreateCompletion(request);

            parsedOutput = response.Choices[0].Text;
            string cleanedOutput = parsedOutput.Replace(inputText, "");
            cleanedOutput.Replace("\n", "");

            //this happens after we get a response
            conversationText.text = conversationText.text.TrimEnd("Bot is typing...\n".ToCharArray());
            conversationText.text += $"\n<color=#{botColorHex}>Bot: {cleanedOutput}</color>\n\n";
            inputField.interactable = true;
            sendButton.interactable = true;
            inputField.ActivateInputField();
            isWaitingForResponse = false;
            Canvas.ForceUpdateCanvases();
            scrollRect.verticalNormalizedPosition = 0f;

            upButton.interactable = true;
            downButton.interactable = true;
            leftButton.interactable = true;
            rightButton.interactable = true;
        }

        public async void SendLeftQuery()
        {
            if (isWaitingForResponse) return;

            //the text to be sent
            string inputText = "I walk to the left.";

            isWaitingForResponse = true;
            inputField.interactable = false;
            sendButton.interactable = false;
            inputField.text = "";

            upButton.interactable = false;
            downButton.interactable = false;
            leftButton.interactable = false;
            rightButton.interactable = false;


            conversationText.text += $"<color=#{userColorHex}>You: {inputText}</color>\n";
            conversationText.text += "Bot is typing...\n";

            Canvas.ForceUpdateCanvases();
            scrollRect.verticalNormalizedPosition = 0f;

            //api call
            var openai = new OpenAIApi("not needed for a local LLM");
            var request = new CreateCompletionRequest
            {
                Model = "ggml-model-gpt4all-falcon-q4_0",
                Prompt = inputText,
                MaxTokens = 100,
                Temperature = 0.28f,
                TopP = 0.95f,
                N = 1,
                Echo = true,
                Stream = false
            };

            var response = await openai.CreateCompletion(request);

            parsedOutput = response.Choices[0].Text;
            string cleanedOutput = parsedOutput.Replace(inputText, "");
            cleanedOutput.Replace("\n", "");

            //this happens after we get a response
            conversationText.text = conversationText.text.TrimEnd("Bot is typing...\n".ToCharArray());
            conversationText.text += $"\n<color=#{botColorHex}>Bot: {cleanedOutput}</color>\n\n";
            inputField.interactable = true;
            sendButton.interactable = true;
            inputField.ActivateInputField();
            isWaitingForResponse = false;
            Canvas.ForceUpdateCanvases();
            scrollRect.verticalNormalizedPosition = 0f;

            upButton.interactable = true;
            downButton.interactable = true;
            leftButton.interactable = true;
            rightButton.interactable = true;
        }

        public async void SendRightQuery()
        {
            if (isWaitingForResponse) return;

            //the text to be sent
            string inputText = "I walk to the right.";

            isWaitingForResponse = true;
            inputField.interactable = false;
            sendButton.interactable = false;
            inputField.text = "";

            upButton.interactable = false;
            downButton.interactable = false;
            leftButton.interactable = false;
            rightButton.interactable = false;


            conversationText.text += $"<color=#{userColorHex}>You: {inputText}</color>\n";
            conversationText.text += "Bot is typing...\n";

            Canvas.ForceUpdateCanvases();
            scrollRect.verticalNormalizedPosition = 0f;

            //api call
            var openai = new OpenAIApi("not needed for a local LLM");
            var request = new CreateCompletionRequest
            {
                Model = "ggml-model-gpt4all-falcon-q4_0",
                Prompt = inputText,
                MaxTokens = 100,
                Temperature = 0.28f,
                TopP = 0.95f,
                N = 1,
                Echo = true,
                Stream = false
            };

            var response = await openai.CreateCompletion(request);

            parsedOutput = response.Choices[0].Text;
            string cleanedOutput = parsedOutput.Replace(inputText, "");
            cleanedOutput.Replace("\n", "");


            //this happens after we get a response
            conversationText.text = conversationText.text.TrimEnd("Bot is typing...\n".ToCharArray());
            conversationText.text += $"\n<color=#{botColorHex}>Bot: {cleanedOutput}</color>\n\n";
            inputField.interactable = true;
            sendButton.interactable = true;
            inputField.ActivateInputField();
            isWaitingForResponse = false;
            Canvas.ForceUpdateCanvases();
            scrollRect.verticalNormalizedPosition = 0f;

            upButton.interactable = true;
            downButton.interactable = true;
            leftButton.interactable = true;
            rightButton.interactable = true;
        }


        private void ClearButtonClicked()
        {
            if (isWaitingForResponse) return;
            conversationText.text = "";
        }
    }
}