using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Runtime.CompilerServices;

namespace HuggingFace.API.Examples
{
    public class MattTextGeneration : MonoBehaviour
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

        //Unused field that was used to send text to the input field when working on Button Navigation
        //[SerializeField] private TMP_InputField navText;

        //Fields to store the player's name and selected class
        private string classText;
        private string nameText;

        //Init task
        private TextGenerationTask textGenerationTask = new TextGenerationTask();

        //Store color
        private string userColorHex;
        private string botColorHex;
        private string errorColorHex;
        //Bool used when waiting for a response from the language model
        private bool isWaitingForResponse;

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
                LeftNavButtonClicked();
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                RightNavButtonClicked();
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                UpNavButtonClicked();
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                DownNavButtonClicked();
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
            //navText.text = "I navigate forward.";
            SendUpQuery();
        }
        //when clicking the down arrow
        public void DownNavButtonClicked()
        {
            //navText.text = "I navigate backwards.";
            SendDownQuery();
        }
        //when clicking the left arrow
        public void LeftNavButtonClicked()
        {
            //navText.text = "I navigate to the left.";
            SendLeftQuery();
        }
        //when clicking the right arrow
        public void RightNavButtonClicked()
        {
            //navText.text = "I navigate to the right.";
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
        public void SendQuery()
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


            HuggingFaceAPI.TextGeneration(inputText, response =>
            {
                //string reply = response;
                conversationText.text = conversationText.text.TrimEnd("Bot is typing...\n".ToCharArray());
                conversationText.text += $"\n<color=#{botColorHex}>Bot: {response}</color>\n\n";
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

            }, error =>
            {
                conversationText.text = conversationText.text.TrimEnd("Bot is typing...\n".ToCharArray());
                conversationText.text += $"\n<color=#{errorColorHex}>Error: {error}</color>\n\n";
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

            });

        }

        //logic for the query sent when using the up arrow
        public void SendUpQuery()
        {
            if (isWaitingForResponse) return;

            //the user-entered text
            string inputText = "I navigate forward.";
            
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


            HuggingFaceAPI.TextGeneration(inputText, response =>
            {
                //string reply = response;
                conversationText.text = conversationText.text.TrimEnd("Bot is typing...\n".ToCharArray());
                conversationText.text += $"\n<color=#{botColorHex}>Bot: {response}</color>\n\n";
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

            }, error =>
            {
                conversationText.text = conversationText.text.TrimEnd("Bot is typing...\n".ToCharArray());
                conversationText.text += $"\n<color=#{errorColorHex}>Error: {error}</color>\n\n";
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

            });

        }

        //logic for the query sent when using the down arrow
        public void SendDownQuery()
        {
            if (isWaitingForResponse) return;

            //the user-entered text
            string inputText = "I navigate backwards.";
            /*if (string.IsNullOrEmpty(inputText))
            {
                return;
            }*/

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


            HuggingFaceAPI.TextGeneration(inputText, response =>
            {
                //string reply = response;
                conversationText.text = conversationText.text.TrimEnd("Bot is typing...\n".ToCharArray());
                conversationText.text += $"\n<color=#{botColorHex}>Bot: {response}</color>\n\n";
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

            }, error =>
            {
                conversationText.text = conversationText.text.TrimEnd("Bot is typing...\n".ToCharArray());
                conversationText.text += $"\n<color=#{errorColorHex}>Error: {error}</color>\n\n";
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

            });

        }

        //logic for the query sent when using the left arrow
        public void SendLeftQuery()
        {
            if (isWaitingForResponse) return;

            //the user-entered text
            string inputText = "I navigate to the left.";
            /*if (string.IsNullOrEmpty(inputText))
            {
                return;
            }*/

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


            HuggingFaceAPI.TextGeneration(inputText, response =>
            {
                //string reply = response;
                conversationText.text = conversationText.text.TrimEnd("Bot is typing...\n".ToCharArray());
                conversationText.text += $"\n<color=#{botColorHex}>Bot: {response}</color>\n\n";
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

            }, error =>
            {
                conversationText.text = conversationText.text.TrimEnd("Bot is typing...\n".ToCharArray());
                conversationText.text += $"\n<color=#{errorColorHex}>Error: {error}</color>\n\n";
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

            });

        }

        //logic for the query sent when using the right arrow
        public void SendRightQuery()
        {
            if (isWaitingForResponse) return;

            //the user-entered text
            string inputText = "I navigate to the right.";
            /*if (string.IsNullOrEmpty(inputText))
            {
                return;
            }*/

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


            HuggingFaceAPI.TextGeneration(inputText, response =>
            {
                //string reply = response;
                conversationText.text = conversationText.text.TrimEnd("Bot is typing...\n".ToCharArray());
                conversationText.text += $"\n<color=#{botColorHex}>Bot: {response}</color>\n\n";
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

            }, error =>
            {
                conversationText.text = conversationText.text.TrimEnd("Bot is typing...\n".ToCharArray());
                conversationText.text += $"\n<color=#{errorColorHex}>Error: {error}</color>\n\n";
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

            });

        }

        //logic for the inital query that is sent to the model
        private void SendInitialQuery()
        {
            if (isWaitingForResponse) return;
            

            //the user-entered text
            string inputText = "Welcome to The Generative Lands! I am " + nameText + ", a " + classText + " looking for an adventure!";
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


            HuggingFaceAPI.TextGeneration(inputText, response =>
            {
                //string reply = response;
                conversationText.text = conversationText.text.TrimEnd("Bot is typing...\n".ToCharArray());
                conversationText.text += $"\n<color=#{botColorHex}>Bot: {response}</color>\n\n";
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

            }, error =>
            {
                conversationText.text = conversationText.text.TrimEnd("Bot is typing...\n".ToCharArray());
                conversationText.text += $"\n<color=#{errorColorHex}>Error: {error}</color>\n\n";
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

            });

        }


        private void ClearButtonClicked()
        {
            conversationText.text = "";
            //conversation.Clear();
        }
    }
}