using System.Collections.Generic;
using UnityEngine;

public class SNAKE_CONFIG : Singleton<SNAKE_CONFIG> {
    public List<Color> colors = new List<Color>();

    public Color GetRandomColor() {
        return colors[Random.Range(0, colors.Count)];
    }
}
