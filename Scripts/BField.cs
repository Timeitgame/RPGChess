using System;
using UnityEngine;

public class BField : MonoBehaviour
{

    [Header("Art-stuff")]
    [SerializeField] private Material TileMaterial;


    //константы для размера доски
    private const int TILE_COUNT_X = 8;
    private const int TILE_COUNT_Y = 8;

    private GameObject[,] tiles;
    private Camera currentCamera;
    private Vector2Int currentHover;
    
    private void Awake() 
    {
        GenerateAllTiles(1, TILE_COUNT_X, TILE_COUNT_Y);
    }

    private void Update() 
    {
        if (!currentCamera)
        {
            currentCamera = Camera.main;
            return;
        }

        RaycastHit info;
        Ray ray = currentCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out info, 100, LayerMask.GetMask("Tile")))
        {
            //получаем корды(индексы) клетки на которую навели курсор
            Vector2Int hitPosition = LookupTileIndex(info.transform.gameObject);

            //подсвечиваем первую клетку в которую попал курсор
            if (currentHover == -Vector2Int.one)
            {
                currentHover = hitPosition;
                tiles[hitPosition.x, hitPosition.y].layer = LayerMask.NameToLayer("Hover");
            }

            //если уже подсвечена клетка, меняем значения для подсветки
            if (currentHover != hitPosition)
            {
                tiles[currentHover.x, currentHover.y].layer = LayerMask.NameToLayer("Tile");
                currentHover = hitPosition;
                tiles[hitPosition.x, hitPosition.y].layer = LayerMask.NameToLayer("Hover");
            }
        }
        else 
        {
            //при убирании курсора с поля убирает подсветку
            if (currentHover != -Vector2Int.one)
            {
                tiles[currentHover.x, currentHover.y].layer = LayerMask.NameToLayer("Tile");
                currentHover = -Vector2Int.one;
            }
        }
    }

    //создание поля(доски)
    private void GenerateAllTiles(float tileSize, int tileCountX, int tileCountY) 
    {
        //tileSize - размер, tileCountX - Колво по иксу, tileCountY - колво по игрику
        tiles = new GameObject[tileCountX, tileCountY];
        //рисуем доску вложенным циклом
        for (int x = 0; x < tileCountX; x++)
        {
            for (int y = 0; y < tileCountY; y++)
            {
                tiles[x, y] = GenerateSingleTiles(tileSize, x, y);
            }
        }
    }
    private GameObject GenerateSingleTiles(float tileSize, int x, int y)
    {
        GameObject tileObject = new GameObject(string.Format("X:{0}, Y:{1}", x, y));
        tileObject.transform.parent = transform;

        Mesh mesh = new Mesh();
        tileObject.AddComponent<MeshFilter>().mesh = mesh;
        tileObject.AddComponent<MeshRenderer>().material = TileMaterial;

        //рисуем стороны одного квадратика
        Vector3[] vertices = new Vector3[4];
        vertices[0] = new Vector3(x * tileSize, 0, y * tileSize);
        vertices[1] = new Vector3(x * tileSize, 0, (y + 1) * tileSize);
        vertices[2] = new Vector3((x + 1) * tileSize, 0, y * tileSize);
        vertices[3] = new Vector3((x + 1) * tileSize, 0, (y + 1) * tileSize);

        //не трогать этот набор чисел, а то доска не правильно нарисуется( костыли :D )
        int[] tris = new int[] { 0, 1, 2, 1, 3, 2 };

        mesh.vertices = vertices;
        mesh.triangles = tris;
        //фикс бага со светом
        mesh.RecalculateNormals();

        tileObject.layer = LayerMask.NameToLayer("Tile");
        tileObject.AddComponent<BoxCollider>();

        return tileObject;
    }


    //Операции
    private Vector2Int LookupTileIndex(GameObject hitInfo)
    {
        // ищем клетку на которою навели курсор
        for (int x = 0; x < TILE_COUNT_X; x++)
        {
            for (int y = 0; y < TILE_COUNT_Y; y++)
            {
                if (tiles[x,y] == hitInfo)
                {
                    return new Vector2Int(x, y);
                }
            }
        }
        return -Vector2Int.one; //вернет корды -1 -1 (игра крашнется если такое случится, наверное...)
    }
}