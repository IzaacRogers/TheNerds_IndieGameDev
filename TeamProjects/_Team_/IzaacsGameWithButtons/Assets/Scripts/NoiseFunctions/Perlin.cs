using System.Collections;
using UnityEngine;

class Perlin 
{
    float[,] map;
    float fillPercent = 50;
    float blurRadius = 10;
    string seed;

    Perlin(float[,] map) {
        System.Random rng = new System.Random(seed.GetHashCode());

        for (int x = 0; x < map.GetLength(0); x++) {
            for (int y = 0; y < map.GetLength(1); y++) {
                map[x, y] = (float)rng.Next(0, 100) > fillPercent ? 0 : 1;
            }
        }

        for (int x = 0; x < map.GetLength(0); x++){
            for (int y = 0; y < map.GetLength(1); y++){
                
            }
        }
    }
}