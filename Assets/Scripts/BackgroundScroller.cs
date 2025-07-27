using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float scrollSpeed = 2f;
    public Transform[] backgrounds; // 2개의 배경 이미지

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

            // 이미지가 화면 아래로 벗어나면 위로 재배치
            //if (bg.position.y < -imageHeight)
            //{
            //    float highestY = GetHighestY(); // 다른 이미지의 위치 위로 이동
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
