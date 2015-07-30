using UnityEngine;
using System.Collections;

public class StealthTesting : MonoBehaviour {

    public bool inShadow;

    byte sqr = 128;
    public Camera cam;

    RenderTexture RT;
    Texture texture;
    Texture2D texture2d;

    public float value;
    float width, height;
    float cooldownMax = 1;
    public float cooldown = 0;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (cooldown <= 0)
        {
            cooldown = cooldownMax;
            shadowCheck();
        }
        else 
        {
            cooldown -= Time.deltaTime;
        }
        


	}

    public void shadowCheck() {
        cam.aspect = 1.0f;

        RT = new RenderTexture(sqr, sqr, 24);
        cam.targetTexture = RT;
        cam.Render();

        RenderTexture.active = RT;
        texture2d = new Texture2D(sqr, sqr, TextureFormat.RGB24, false);

        texture2d.ReadPixels(new Rect(0, 0, sqr, sqr), 0, 0);

        RenderTexture.active = null;
        cam.targetTexture = null;

        //byte[] data;
        //data = texture2d.EncodeToPNG();

        width = texture2d.width;
        height = texture2d.height;

        Color colMean = new Color();

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (y == 0)
                {
                    colMean = texture2d.GetPixel(x, y);
                }
                else
                {
                    colMean = (colMean + texture2d.GetPixel(x, y)) / 2;
                }
            }
        }

        value = colMean.grayscale;
        if (value > .05)
            inShadow = false;
        else
            inShadow = true;
    }

}
