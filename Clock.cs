using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Clock : MonoBehaviour
{
    const float
        degreesPerHour = 30f,
        degreesPerMinute = 6f,
        degreesPerSecond = 6f;
    const int secDelay = 17;

    // var someText = Text;

    public Transform hoursTransform, minutesTransform, secondsTransform;
    public TextMesh txtLine0, txtLine1,txtLine2,txtLine3;
    public Transform Raven;
    private float update;
    public  DateTime time;
    private string myQuote;
    private int ixWords, ixLines,ixChars;
    private char[] chars;


    void Start()
    {
        time = Convert.ToDateTime("2-Aug-18 11:59:15pm");
        myQuote = " Once upon a midnight dreary  while I pondered weak and weary.";
        chars = myQuote.ToCharArray();
        ixWords = 0;
        ixLines = 0;
        ixChars = 0;
    }

    void Update()
    {

        update += Time.deltaTime;

        if (update > 0.5f)
        {
            update = 0.0f;
            time = time.AddSeconds(0.5);

            // hours and minutes aren't working but used to
            hoursTransform.localRotation =
                Quaternion.Euler(0f, time.Hour * degreesPerHour, 0f);
            minutesTransform.localRotation =
                Quaternion.Euler(0f, time.Minute * degreesPerMinute, 0f);
            // seconds discrete
            secondsTransform.localRotation =
                Quaternion.Euler(0f, time.Second * degreesPerSecond, 0f);


            //     showText = GameObject.Find("txtLine" + lineNbr.ToString());
            //    var myText = showText.GetComponent<UnityEngine.UI.Text>().text;
            //      myText = "yep ";
            //  showText.GetComponent<UnityEngine.UI.Text>().text = "Noooooooo";
            //        Debug.Log(myText);

            // update the words onscreen

            if (time.Second>=secDelay)
            {
                ixChars += 1;
                if (chars[ixChars] == ' ')
                {
                    Debug.Log(ixLines);
                    ixWords += 1;
                    if ((ixWords % 3) == 0)
                    {ixLines += 1;}
                }

                if (ixLines == 0)
                {txtLine0.text = txtLine0.text + chars[ixChars];}
                if (ixLines == 1)
                {
                    txtLine1.text = txtLine1.text + chars[ixChars];
                 //   float alpha = Mathf.Lerp(1, 0, ixChars);
                 //   Debug.Log(alpha);
                }
                if (ixLines == 2)
                {txtLine2.text = txtLine2.text + chars[ixChars]; }
                if (ixLines == 3)
                {
                    txtLine3.text = txtLine3.text + chars[ixChars];
                }
            }

            if (time.Second==45){
               // fade out line 1
            }

        }

    }
}
