using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBubbleChat : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject bubbleChatPrefab;
    public GameObject enemybubbleChatPrefab;
    public Transform contentT;
    public InputField inputfield;
    HitAndBlow hitandblow;
    //public Button postButton;
    void Awake()
    {
        hitandblow = GetComponent<HitAndBlow>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            Post();
        }
    }

    public void Post()
    {
        //Text chattext = bubbleChatPrefab.transform.GetChild(0).GetComponent<Text>();
        //Instantiate(bubbleChatPrefab, transform.position,transform.rotation);
        //Instantiate(bubbleChatPrefab, contentT);

        GameObject bubble = Instantiate(bubbleChatPrefab, contentT);
        Text chattext = bubble.GetComponentInChildren<Text>();
        chattext.text = inputfield.text;

        GameObject enemybubble = Instantiate(enemybubbleChatPrefab, contentT);
        Text enemychattext = enemybubble.GetComponentInChildren<Text>();
        enemychattext.text = hitandblow.CheckGuess(int.Parse(chattext.text));

        inputfield.text = "";

    }


}
