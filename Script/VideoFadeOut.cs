using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoFadeOut : MonoBehaviour
{

    public RawImage videoFade;

    // Start is called before the first frame update
    void Start()
    {
        videoFade.canvasRenderer.SetAlpha(20.0f);

        fadeOut();
    }

    // Update is called once per frame
    void fadeOut()
    {
        videoFade.CrossFadeAlpha(0, 7, false);
    }
}
