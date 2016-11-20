using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CubeBrick
    {

        public enum sides { FRONT = 0, LEFT = 1, BACK = 2, RIGHT = 3, TOP = 4, BOTTOM = 5 };
        public static Color REDCOLOR { get { return Color.red; } }
        public static Color BLUECOLOR { get { return Color.blue; } }
        public static Color GREENCOLOR { get { return Color.green; } }
        public static Color ORANGECOLOR { get { return new Color(1.0f, 0.5f, 0.0f); } }
        public static Color YELLOWCOLOR { get { return Color.yellow; } }
        public static Color WHITECOLOR { get { return Color.white; } }
        public static Color BLACKCOLOR { get { return Color.black; } }
        List<Color> colors = new List<Color>();

        public CubeBrick()
        {
            for (int i = 0; i < 6; i++) { colors.Add(BLACKCOLOR); }
            setAllSideColors(BLACKCOLOR);
        }

        public CubeBrick(List<Color> c)
        {
            for (int i = 0; i < 6; i++) { colors.Add(BLACKCOLOR); }
            setSideColors(c);
        }

        public void setAllSideColors(Color c)
        {
            for (int i = 0; i < colors.Count; i++)
            {
                setSideColor((sides)i, c);
            }
        }

        public void setSideColors(List<Color> colors)
        {
            for (int i = 0; i < 6; i++)
            {
                setSideColor((sides)i, colors[i]);
            }
        }

        public void setSideColor(sides side, Color c)
        {
            colors[(int)side] = c;
        }

        public List<Color> getColors()
        {
            List<Color> tempcolors = new List<Color>();
            for (int i = 0; i < colors.Count; i++)
            {
                tempcolors.Add(colors[i]);
            }
            return tempcolors;
        }

    }

