using UnityEngine;

public class Tile : MonoBehaviour
{
    public int targetX, targetY;  // Ÿ���� ��ǥ ��ġ
    private int currentX, currentY;  // Ÿ���� ���� ��ġ

    // Ÿ���� ���� ��ġ�� ����
    public void SetPosition(int newX, int newY)
    {
        currentX = newX;
        currentY = newY;

        // ��ġ�� ������Ʈ�� ������ Ÿ���� UI ��ġ�� ������Ʈ
        UpdateTilePosition();
    }

    // Ÿ���� ��ġ�� UI �� �°� ���� (���� ������Ʈ�� RectTransform ��ġ)
    private void UpdateTilePosition()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        if (rectTransform != null)
        {
            float tileSize = rectTransform.rect.width;  // Ÿ���� ũ��
            float puzzleWidth = tileSize * SlidingPuzzleManager.Instance.gridSize;  // ������ �ʺ�

            // ȭ���� ���� ���� �ʺ� �������� Ÿ���� ��ġ�� ���
            Vector2 puzzlePosition = new Vector2(
                (Screen.width - puzzleWidth) / 2 + currentX * tileSize,  // X ��ġ�� ���ʿ� ���߾� ����
                -(currentY * tileSize)  // Y ��ġ�� ������ �Ʒ���
            );

            rectTransform.anchoredPosition = puzzlePosition;
        }
    }

    // Ÿ���� ��ǥ ��ġ�� �ִ��� Ȯ��
    public bool IsAtTargetPosition()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        if (rectTransform != null)
        {
            float tileSize = rectTransform.rect.width;  // Ÿ���� ũ��
            float puzzleWidth = tileSize * SlidingPuzzleManager.Instance.gridSize;  // ������ �ʺ�

            // ��ǥ ��ġ ���
            Vector2 targetPosition = new Vector2(
                (Screen.width - puzzleWidth) / 2 + targetX * tileSize,  // ��ǥ X ��ġ
                -(targetY * tileSize)  // ��ǥ Y ��ġ
            );

            // Ÿ���� ��ġ�� ��ǥ ��ġ�� �������� ��
            return rectTransform.anchoredPosition == targetPosition;
        }

        return false;
    }

    // Ÿ���� ������ ��ġ�� �ִ��� Ȯ��
    public bool IsAtPosition(Vector2 position)
    {
        return currentX == (int)position.x && currentY == (int)position.y;
    }

    // Ÿ�� Ŭ�� �� ȣ��Ǵ� �޼��� (Ÿ�� �̵�)
    public void OnClick()
    {
        SlidingPuzzleManager manager = FindObjectOfType<SlidingPuzzleManager>();
        manager.MoveTile(new Vector2(currentX, currentY));
    }

    // Ÿ���� ���� ��ġ�� ��ȯ
    public Vector2 GetCurrentPosition()
    {
        return new Vector2(currentX, currentY);
    }
}
