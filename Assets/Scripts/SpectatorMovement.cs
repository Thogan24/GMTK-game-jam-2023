using UnityEngine;
using TMPro;

public class SpectatorMovement : MonoBehaviour
{
    public float dragSpeed = 2;
    private Vector3 dragOrigin;

    RaycastHit hit;
    Ray ray;

    GameObject selectedObject;
    public GameObject EnemyTextObject;
    public TextMeshProUGUI enemyName;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;
            return;
        }

        if (!Input.GetMouseButton(0)) return;

        Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
        Vector3 move = new Vector3(pos.x * dragSpeed, pos.y * dragSpeed, 0);

        transform.Translate(-move, Space.World);
        return;








        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100))
            {
                GameObject go = hit.transform.gameObject;
                if (go.GetComponent<Enemy>() != null)
                {
                    selectedObject = go;
                    EnemyTextObject.SetActive(true);
                }
                else
                {
                    EnemyTextObject.SetActive(false);
                }
            }
            else
            {
                EnemyTextObject.SetActive(false);
            }
        }
        if (selectedObject != null)
        {
            enemyName.text = selectedObject.name;
        }
    }

}