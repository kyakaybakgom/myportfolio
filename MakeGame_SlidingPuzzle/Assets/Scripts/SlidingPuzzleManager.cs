using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlidingPuzzleManager : MonoBehaviour
{
    public static SlidingPuzzleManager Instance; // 싱글톤 인스턴스

    public int gridSize = 5; // 퍼즐의 크기 (동적으로 설정 가능)
    public GameObject tilePrefab; // 타일 프리팹
    public Transform puzzleParent; // 퍼즐 타일들이 배치될 부모 오브젝트
    public Texture2D puzzleImage; // 퍼즐에 사용할 이미지
    public TextMeshProUGUI completionMessage; // 퍼즐 완성 메시지를 표시할 UI 텍스트

    private List<GameObject> tiles = new List<GameObject>();
    private Vector2 emptySlot;
    private bool isShuffled = false;

    void Awake()
    {
        Instance = this; // 싱글톤 인스턴스 설정
    }

    void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        if (completionMessage != null)
            completionMessage.gameObject.SetActive(false); // 메시지 비활성화

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
        float tileSize = CalculateTileSize(); // 타일 크기 계산
        emptySlot = new Vector2(gridSize - 1, gridSize - 1); // 빈 칸 위치

        // 퍼즐 크기 계산
        float puzzleWidth = tileSize * gridSize;
        float puzzleHeight = tileSize * gridSize;

        // 화면 중앙에 퍼즐 배치
        Vector2 puzzlePosition = new Vector2(
            (Screen.width - puzzleWidth) / 2,  // 화면 중앙 X
            (Screen.height - puzzleHeight) / 2  // 화면 중앙 Y
        );

        // 이미지 분할 처리
        Sprite[,] sprites = SplitImageIntoSprites();

        for (int y = 0; y < gridSize; y++)
        {
            for (int x = 0; x < gridSize; x++)
            {
                if (x == gridSize - 1 && y == gridSize - 1) continue; // 빈 칸 제외

                GameObject tile = Instantiate(tilePrefab, puzzleParent);
                RectTransform rectTransform = tile.GetComponent<RectTransform>();
                rectTransform.anchoredPosition = puzzlePosition + new Vector2(x * tileSize, -y * tileSize);

                // 이미지 설정
                Image tileImage = tile.GetComponent<Image>();
                tileImage.sprite = sprites[x, y];

                Tile tileScript = tile.GetComponent<Tile>();
                tileScript.SetPosition(x, y);  // 현재 위치 설정
                tileScript.targetX = x;  // 목표 X 위치 설정
                tileScript.targetY = y;  // 목표 Y 위치 설정

                tiles.Add(tile);
            }
        }
    }

    // 타일 크기 계산
    float CalculateTileSize()
    {
        float maxTileSize = Screen.width / (float)gridSize;
        return Mathf.Min(maxTileSize, Screen.height / (float)gridSize); // 최대 크기 제한
    }

    // 이미지를 타일로 분할
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

        isShuffled = true; // 섞기 완료 플래그 활성화
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

        if (Vector2.Distance(targetPosition, emptySlot) != 1) // 인접한 위치가 아니면 무시
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
