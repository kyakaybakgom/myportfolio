using UnityEngine;

public class Tile : MonoBehaviour
{
    public int targetX, targetY;  // 타일의 목표 위치
    private int currentX, currentY;  // 타일의 현재 위치

    // 타일의 현재 위치를 설정
    public void SetPosition(int newX, int newY)
    {
        currentX = newX;
        currentY = newY;

        // 위치가 업데이트될 때마다 타일의 UI 위치를 업데이트
        UpdateTilePosition();
    }

    // 타일의 위치를 UI 상에 맞게 설정 (게임 오브젝트의 RectTransform 위치)
    private void UpdateTilePosition()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        if (rectTransform != null)
        {
            float tileSize = rectTransform.rect.width;  // 타일의 크기
            float puzzleWidth = tileSize * SlidingPuzzleManager.Instance.gridSize;  // 퍼즐의 너비

            // 화면의 왼쪽 절반 너비를 기준으로 타일의 위치를 계산
            Vector2 puzzlePosition = new Vector2(
                (Screen.width - puzzleWidth) / 2 + currentX * tileSize,  // X 위치는 왼쪽에 맞추어 설정
                -(currentY * tileSize)  // Y 위치는 위에서 아래로
            );

            rectTransform.anchoredPosition = puzzlePosition;
        }
    }

    // 타일이 목표 위치에 있는지 확인
    public bool IsAtTargetPosition()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        if (rectTransform != null)
        {
            float tileSize = rectTransform.rect.width;  // 타일의 크기
            float puzzleWidth = tileSize * SlidingPuzzleManager.Instance.gridSize;  // 퍼즐의 너비

            // 목표 위치 계산
            Vector2 targetPosition = new Vector2(
                (Screen.width - puzzleWidth) / 2 + targetX * tileSize,  // 목표 X 위치
                -(targetY * tileSize)  // 목표 Y 위치
            );

            // 타일의 위치와 목표 위치가 동일한지 비교
            return rectTransform.anchoredPosition == targetPosition;
        }

        return false;
    }

    // 타일이 지정된 위치에 있는지 확인
    public bool IsAtPosition(Vector2 position)
    {
        return currentX == (int)position.x && currentY == (int)position.y;
    }

    // 타일 클릭 시 호출되는 메서드 (타일 이동)
    public void OnClick()
    {
        SlidingPuzzleManager manager = FindObjectOfType<SlidingPuzzleManager>();
        manager.MoveTile(new Vector2(currentX, currentY));
    }

    // 타일의 현재 위치를 반환
    public Vector2 GetCurrentPosition()
    {
        return new Vector2(currentX, currentY);
    }
}
