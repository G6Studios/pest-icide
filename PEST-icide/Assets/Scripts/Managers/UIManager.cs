using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class UIManager : MonoBehaviour
{

    public static UIManager instance = null;

    // Awake() runs before any Start() calls
    // Enforces the singleton pattern
    private void Awake()
    {
        // Check if instance exists
        if (instance == null)
        {
            // If not, set the game manager to this
            instance = this;
        }

        else if (instance != this)
        {
            Destroy(gameObject);
        }

        // Ensures that this persists between scenes
        DontDestroyOnLoad(gameObject);
    }

    string textFile;
    string objectName;
    string text;
    Vector3 position;
    Vector4 color;
    int fontSize;

    Text[] list;

    [SerializeField]
    Text textPrefab;

    [SerializeField]
    Canvas canvas;

    Vector3 startingPosition = new Vector3(0.0f, 0.0f, 0.0f);

    // Importing functions from dll
    [DllImport("UIManagerPlugin")]
    public static extern void LoadDLL();
    [DllImport("UIManagerPlugin")]
    public static extern void ChangeState(int newState);
    [DllImport("UIManagerPlugin")]
    public static extern void LoadFile(string fileName);
    [DllImport("UIManagerPlugin")]
    public static extern void Compose(int index);
    [DllImport("UIManagerPlugin", CallingConvention = CallingConvention.Cdecl)]
    public static extern System.IntPtr ReturnName(int newState);
    [DllImport("UIManagerPlugin", CallingConvention = CallingConvention.Cdecl)]
    public static extern System.IntPtr ReturnText(int newState);
    [DllImport("UIManagerPlugin")]
    public static extern float ReturnPosX();
    [DllImport("UIManagerPlugin")]
    public static extern float ReturnPosY();
    [DllImport("UIManagerPlugin")]
    public static extern float ReturnPosZ();
    [DllImport("UIManagerPlugin")]
    public static extern float ReturnRed();
    [DllImport("UIManagerPlugin")]
    public static extern float ReturnGreen();
    [DllImport("UIManagerPlugin")]
    public static extern float ReturnBlue();
    [DllImport("UIManagerPlugin")]
    public static extern float ReturnAlpha();
    [DllImport("UIManagerPlugin")]
    public static extern int ReturnFontSize();

    // Text elements
    Text timeText;
    Text foodText1;
    Text foodText2;
    Text foodText3;
    Text foodText4;

    Text timeCount;
    Text foodCount1;
    Text foodCount2;
    Text foodCount3;
    Text foodCount4;


    // Use this for initialization
    void Start()
    {
        LoadDLL();

        createStaticText();

        list = GameObject.FindObjectsOfType<Text>(); // Get array of text elements in the game scene

        LoadFile("UIElements"); // Load properties from text file
        for (int i = 0; i < list.Length; i++) // For each text element
        {
            PackData(i); // Compose and pack data for it
            SetData(list[i]); // Send the composed data to the text element
        }

        createDynText();


    }

    // Update is called once per frame
    void Update()
    {
        timeCount.text = formatText(GameManager.instance.TimeRemaining);
        foodCount1.text = GameManager.instance.Player1Food.ToString();
        foodCount2.text = GameManager.instance.Player2Food.ToString();
        foodCount3.text = GameManager.instance.Player3Food.ToString();
        foodCount4.text = GameManager.instance.Player4Food.ToString();
    }

    private string formatText(float time)
    {
        // Uses string.Format to display the time as minutes and seconds with a colon in the middle
        return string.Format("{0}:{1:00}", ((int)time / 60), ((int)time % 60));
    }

    void createStaticText()
    {
        timeText = Instantiate(textPrefab, startingPosition, textPrefab.transform.rotation) as Text;
        timeText.transform.SetParent(canvas.transform, false);
        foodText1 = Instantiate(textPrefab, startingPosition, textPrefab.transform.rotation) as Text;
        foodText1.transform.SetParent(canvas.transform, false);
        foodText2 = Instantiate(textPrefab, startingPosition, textPrefab.transform.rotation) as Text;
        foodText2.transform.SetParent(canvas.transform, false);
        foodText3 = Instantiate(textPrefab, startingPosition, textPrefab.transform.rotation) as Text;
        foodText3.transform.SetParent(canvas.transform, false);
        foodText4 = Instantiate(textPrefab, startingPosition, textPrefab.transform.rotation) as Text;
        foodText4.transform.SetParent(canvas.transform, false);
    }

    void createDynText()
    {
        timeCount = Instantiate(textPrefab, startingPosition, textPrefab.transform.rotation) as Text;
        timeCount.transform.SetParent(canvas.transform, false);
        foodCount1 = Instantiate(textPrefab, startingPosition, textPrefab.transform.rotation) as Text;
        foodCount1.transform.SetParent(canvas.transform, false);
        foodCount2 = Instantiate(textPrefab, startingPosition, textPrefab.transform.rotation) as Text;
        foodCount2.transform.SetParent(canvas.transform, false);
        foodCount3 = Instantiate(textPrefab, startingPosition, textPrefab.transform.rotation) as Text;
        foodCount3.transform.SetParent(canvas.transform, false);
        foodCount4 = Instantiate(textPrefab, startingPosition, textPrefab.transform.rotation) as Text;
        foodCount4.transform.SetParent(canvas.transform, false);

        timeCount.rectTransform.localPosition = new Vector3(49, 226, 0);
        foodCount1.rectTransform.localPosition = new Vector3(-267, 223, 0);
        foodCount2.rectTransform.localPosition = new Vector3(-233, 191, 0);
        foodCount3.rectTransform.localPosition = new Vector3(-249, 156, 0);
        foodCount4.rectTransform.localPosition = new Vector3(-234, 124, 0);
    }

    void PackData(int index)
    {
        Compose(index);
        objectName = Marshal.PtrToStringAnsi(ReturnName(0)); // Takes in char pointer and converts it into a string
        text = Marshal.PtrToStringAnsi(ReturnText(0)); // Takes in char pointer and converts it to a string
        position = new Vector3(ReturnPosX(), ReturnPosY(), ReturnPosZ());
        color = new Vector4(ReturnRed(), ReturnGreen(), ReturnBlue(), ReturnAlpha());
        fontSize = ReturnFontSize();
    }

    void SetData(Text tempText)
    {
        tempText.name = objectName;
        tempText.text = text;
        tempText.rectTransform.localPosition = position;
        tempText.color = color;
        tempText.fontSize = fontSize;
    }

}
