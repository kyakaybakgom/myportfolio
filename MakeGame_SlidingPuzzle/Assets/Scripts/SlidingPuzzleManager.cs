using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlidingPuzzleManager : MonoBehaviour
{
    public static SlidingPuzzleManager Instance; // �̱��� �ν��Ͻ�

    public int gridSize = 5; // ������ ũ�� (�������� ���� ����)
    public GameObject tilePrefab; // Ÿ�� ������
    public Transform puzzleParent; // ���� Ÿ�ϵ��� ��ġ�� �θ� ������Ʈ
    public Texture2D puzzleImage; // ���� ����� �̹���
    public TextMeshProUGUI completionMessage; // ���� �ϼ� �޽����� ǥ���� UI �ؽ�Ʈ

    private List<GameObject> tiles = new List<GameObject>();
    private Vector2 emptySlot;
    private bool isShuffled = false;

    void Awake()
    {
        Instance = this; // �̱��� �ν��Ͻ� ����
    }

    void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        if (completionMessage != null)
            completionMessage.gameObject.SetActive(false); // �޽��� ��Ȱ��ȭ

        isShuffled = false;

        GeneratePuzzle();
        ShufflePuzzle();
    }

    public void ReStartGame()
    {
        StartGame();
    }

    void GeneratePuzzle()
    {
        float tileSize = CalculateTileSize(); // Ÿ�� ũ�� ���
        emptySlot = new Vector2(gridSize - 1, gridSize - 1); // �� ĭ ��ġ

        // ���� ũ�� ���
        float puzzleWidth = tileSize * gridSize;
        float puzzleHeight = tileSize * gridSize;

        // ȭ�� �߾ӿ� ���� ��ġ
        Vector2 puzzlePosition = new Vector2(
            (Screen.width - puzzleWidth) / 2,  // ȭ�� �߾� X
            (Screen.height - puzzleHeight) / 2  // ȭ�� �߾� Y
        );

        // �̹��� ���� ó��
        Sprite[,] sprites = SplitImageIntoSprites();

        for (int y = 0; y < gridSize; y++)
        {
            for (int x = 0; x < gridSize; x++)
            {
                if (x == gridSize - 1 && y == gridSize - 1) continue; // �� ĭ ����

                GameObject tile = Instantiate(tilePrefab, puzzleParent);
                RectTransform rectTransform = tile.GetComponent<RectTransform>();
                rectTransform.anchoredPosition = puzzlePosition + new Vector2(x * tileSize, -y * tileSize);

                // �̹��� ����
                Image tileImage = tile.GetComponent<Image>();
                tileImage.sprite = sprites[x, y];

                Tile tileScript = tile.GetComponent<Tile>();
                tileScript.SetPosition(x, y);  // ���� ��ġ ����
                tileScript.targetX = x;  // ��ǥ X ��ġ ����
                tileScript.targetY = y;  // ��ǥ Y ��ġ ����

                tiles.Add(tile);
            }
        }
    }

    // Ÿ�� ũ�� ���
    float CalculateTileSize()
    {
        float maxTileSize = Screen.width / (float)gridSize;
        return Mathf.Min(maxTileSize, Screen.height / (float)gridSize); // �ִ� ũ�� ����
    }

    // �̹����� Ÿ�Ϸ� ����
    Sprite[,] SplitImageIntoSprites()
    {
        if (puzzleImage == null) return null;

        int tileWidth = puzzleImage.width / gridSize;
        int tileHeight = puzzleImage.height / gridSize;
        Sprite[,] sprites = new Sprite[gridSize, gridSize];

        for (int y = 0; y < gridSize; y++)
        {
            for (int x = 0; x < gridSize; x++)
            {
                Rect rect = new Rect(x * tileWidth, puzzleImage.height - (y + 1) * tileHeight, tileWidth, tileHeight);
                Vector2 pivot = new Vector2(0.5f, 0.5f);
                sprites[x, y] = Sprite.Create(puzzleImage, rect, pivot);
            }
        }

        return sprites;
    }

    void ShufflePuzzle()
    {
        for (int i = 0; i < 100; i++)
        {
            Vector2 randomDirection = GetRandomDirection();
            MoveTile(emptySlot + randomDirection);
        }

        isShuffled = true; // ���� �Ϸ� �÷��� Ȱ��ȭ
    }

    Vector2 GetRandomDirection()
    {
        Vector2[] directions = { Vector2.up, Vector2.down, Vector2.left, Vector2.right };
        return directions[Random.Range(0, directions.Length)];
    }

    public void MoveTile(Vector2 targetPosition)
    {
        if (isShuffled && IsPuzzleComplete()) return;

        if (targetPosition.x < 0 || targetPosition.x >= gridSize || targetPosition.y < 0 || targetPosition.y >= gridSize)
        return;

        if (Vector2.Distance(targetPosition, emptySlot) != 1) // ������ ��ġ�� �ƴϸ� ����
            return;

        GameObject tileToMove = tiles.Find(tile => tile.GetComponent<Tile>().IsAtPosition(targetPosition));

        if (tileToMove != null)
        {
            Tile tileScript = tileToMove.GetComponent<Tile>();
            Vector2 currentSlot = tileScript.GetCurrentPosition();
            tileScript.SetPosition((int)emptySlot.x, (int)emptySlot.y);

            emptySlot = currentSlot;

            if (isShuffled && IsPuzzleComplete())
            {
                ShowCompletionMessage();
            }
        }
    }

    bool IsPuzzleComplete()
    {
        foreach (var tile in tiles)
        {
            Tile tileScript = tile.GetComponent<Tile>();
            if (!tileScript.IsAtTargetPosition())
                return false;
        }
        return true;
    }

    void ShowCompletionMessage()
    {
        if (completionMessage != null)
        {
            completionMessage.gameObject.SetActive(true);
            completionMessage.text = "Puzzle Complete!";
        }
    }
}
