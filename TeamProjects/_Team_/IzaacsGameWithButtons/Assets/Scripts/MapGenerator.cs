using UnityEngine;
using System.Collections;

public class MapGenerator : MonoBehaviour {
    public int lod;

    public int drawDistance;

    public Vector2 offs;

    public string seed;
    public bool useRandomSeed;


    [Range(0,100)]
    public int randomFillPercent;

    int[,] map;

    void Start() 
    {
        GenerateMap();
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) 
        {
            GenerateMap();
        }
    }

    void GenerateMap() 
    {
        map = new int[drawDistance, drawDistance];
        RandomFillMap();
        for (int i = 0; i < 5; i++) 
        {
            SmoothMap();
        }

        MeshGenerator meshGen = GetComponent<MeshGenerator>();
        meshGen.GenerateMesh(map, lod);
    }

    void RandomFillMap() {
        if(useRandomSeed==true)
            seed = Time.time.ToString();

        System.Random pseudoRandom = new System.Random(seed.GetHashCode());

        for (int x = 0; x < drawDistance; x++)
        {
            for (int y = 0; y < drawDistance; y++)
            {
                map[x, y] = (pseudoRandom.Next(0, 100) < randomFillPercent) ? 1 : 0;
            }
        }

    }

    void SmoothMap() {
        for (int x = 0; x < drawDistance; x++)
        {
            for (int y = 0; y < drawDistance; y++)
            {
				int neighbourWallTiles = GetSurroundingWallCount(x,y);

				if (neighbourWallTiles > 4)
					map[x,y] = 1;
				else if (neighbourWallTiles < 4)
					map[x,y] = 0;

			}
		}
	}

	int GetSurroundingWallCount(int gridX, int gridY) {
		int wallCount = 0;
		for (int neighbourX = gridX - 1; neighbourX <= gridX + 1; neighbourX ++) {
			for (int neighbourY = gridY - 1; neighbourY <= gridY + 1; neighbourY ++) {
                if (neighbourX >= 0 && neighbourX < drawDistance && neighbourY >= 0 && neighbourY < drawDistance)
                {
					if (neighbourX != gridX || neighbourY != gridY) {
						wallCount += map[neighbourX,neighbourY];
					}
				}
				else {
					wallCount ++;
				}
			}
		}

		return wallCount;
	}






}
