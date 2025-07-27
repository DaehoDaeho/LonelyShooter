using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float scrollSpeed = 2f;
    public Transform[] backgrounds; // 2���� ��� �̹���

    private float imageHeight;

    void Start()
    {
        imageHeight = backgrounds[0].GetComponent<SpriteRenderer>().bounds.size.y;
    }

    void Update()
    {
        foreach (Transform bg in backgrounds)
        {
            bg.position += Vector3.down * scrollSpeed * Time.deltaTime;

            // �̹����� ȭ�� �Ʒ��� ����� ���� ���ġ
            //if (bg.position.y < -imageHeight)
            //{
            //    float highestY = GetHighestY(); // �ٸ� �̹����� ��ġ ���� �̵�
            //    bg.position = new Vector3(bg.position.x, highestY + imageHeight, bg.position.z);
            //}

            if (bg.position.y < -12.0f)
            {
                bg.position = new Vector3(bg.position.x, 12.0f, bg.position.z);
            }   
        }
    }

    float GetHighestY()
    {
        float highest = backgrounds[0].position.y;
        foreach (Transform bg in backgrounds)
        {
            if (bg.position.y > highest)
                highest = bg.position.y;
        }
        return highest;
    }
}
