using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Runtime.CompilerServices;

namespace HuggingFace.API.Examples
{
    public class MattTextGeneration : MonoBehaviour
    {
        [SerializeField] private ScrollRect scrollRect;
        [SerializeField] private TMP_Text conversationText;
        [SerializeField] private TMP_InputField inputField;
        [SerializeField] private Button sendButton;
        [SerializeField] private Button clearButton;
        [SerializeField] private Color userTextColor = Color.blue;
        [SerializeField] private Color botTextColor = Color.black;

        [SerializeField] private Button upButton;
        [SerializeField] private Button downButton;
        [SerializeField] private Button leftButton;
        [SerializeField] private Button rightButton;

        [SerializeField] private TMP_InputField upNavText;
        [SerializeField] private TMP_InputField downNavText;
        [SerializeField] private TMP_InputField leftNavText;
        [SerializeField] private TMP_InputField rightNavText;

        private string classText;
        private string nameText;



        private TextGenerationTask textGenerationTask = new TextGenerationTask();

        //private Conversation conversation = new Conversation();
        private string userColorHex;
        private string botColorHex;
        private string errorColorHex;
        private bool isWaitingForResponse;

        private void Awake()
        {
            userColorHex = ColorUtility.ToHtmlStringRGB(userTextColor);
            botColorHex = ColorUtility.ToHtmlStringRGB(botTextColor);
            errorColorHex = ColorUtility.ToHtmlStringRGB(Color.red);

            if (PlayerPrefs.HasKey("SelectedClass"))
            {
                classText = PlayerPrefs.GetString("SelectedClass");
            }

            nameText = CharacterScene.characterscene.player_name;

        }

        private void Start()
        {
            sendButton.onClick.AddListener(SendButtonClicked);
            clearButton.onClick.AddListener(ClearButtonClicked);
            inputField.ActivateInputField();
            inputField.onEndEdit.AddListener(OnInputFieldEndEdit);


            SendInitialQuery();

        }

        private void SendButtonClicked()
        {
            SendQuery();
        }

        public void UpNavButtonClicked()
        {
            upNavText.text = "I navigate forward.";
            SendQuery();
        }

        public void DownNavButtonClicked()
        {
            upNavText.text = "I navigate backwards.";
            SendQuery();
        }

        public void LeftNavButtonClicked()
        {
            upNavText.text = "I navigate to the left.";
            SendQuery();
        }

        public void RightNavButtonClicked()
        {
            upNavText.text = "I navigate to the right.";
            SendQuery();
        }



        private void OnInputFieldEndEdit(string text)
        {
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                SendQuery();
            }
        }

        //method for sending the query to the API
        private void SendQuery()
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