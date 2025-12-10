using UnityEngine;

public class Test : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("1：");

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null)
            {
                Debug.Log("點擊到：" + hit.collider.name);
                Debug.Log("1：");
            }
        }
    }
}