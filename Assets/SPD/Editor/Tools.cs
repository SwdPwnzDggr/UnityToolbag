using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace SPD.EditorTools
{
    public class Tools
    {
        public static void DrawHeader(Color backgroundColor, Color headerColor, string title)
        {
            //Color backgroundColor = new Color(.2f, .2f, .2f,1f);
            //Color headerColor = new Color(.5f, .5f, .5f);

            Texture2D image = new Texture2D(1,1);
            image.filterMode = FilterMode.Point;
            image.wrapMode = TextureWrapMode.Repeat;

            image.SetPixel(0, 0, backgroundColor);
            image.Apply();

            GUIStyle style = new GUIStyle();
            style.normal.background = image;

            EditorGUI.LabelField( new Rect(5, 50, Screen.width-10, 50), " ", style);

            image.SetPixel(0, 0, headerColor);
            image.Apply();

            EditorGUI.LabelField(new Rect(5, 55, Screen.width - 10, 40), " ", style);

            style.richText = true;


            EditorGUI.LabelField(new Rect(10, 55, Screen.width - 20, 10), "<size=30><b>"+ title+ "</b> </size>", style);

        }
    }

}

