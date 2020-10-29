using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildObjects : MonoBehaviour
{

    // Start is called before the first frame update
    Sprite sprite;
    Grid grid;
    public GameObject m_object;

    private Color color;
    void Start()
    {
        sprite = (Sprite) Resources.Load("Tile/Wall", typeof(Sprite));
        grid = transform.parent.GetComponent<Grid>();
        color = GetComponent<Tilemap>().color;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int coord = grid.WorldToCell(wp);
            Ray2D ray = new Ray2D(wp, Vector2.zero);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            try
            {
                if (isSoft(GetComponent<Tilemap>().GetTile(coord).name) && GameManager.instance.m_state == 2)
                {
                    m_object.transform.position = coord + new Vector3(0.5f, 0.5f, 0);
                    m_object.GetComponent<ObjectController>().m_Complete = true;
                    Instantiate(m_object);
                    GameManager.instance.m_state = 0;
                    GameManager.instance.Pipe++;
                }

                if (GetComponent<Tilemap>().GetTile(coord).name == "Arrowzone" && GameManager.instance.m_state == 1)
                {
                    m_object.transform.position = coord + new Vector3(0, 0.5f, 0);
                    m_object.GetComponent<ObjectController>().m_Complete = true;
                    Instantiate(m_object);
                    GameManager.instance.m_state = 0;
                    GameManager.instance.Arrow++;
                }
            }
            catch
            {

            }
        }

        if (this.gameObject.tag == "ArrowZone")
        {
            if (GameManager.instance.m_state == 1)
            {
                color.a = 0.6f;
                GetComponent<Tilemap>().color = color;
            }
            else if (GameManager.instance.m_state == 0)
            {
                color.a = 0f;
                GetComponent<Tilemap>().color = color;
            }
        }
        else if(this.gameObject.tag == "PipeZone")
        {
            if (GameManager.instance.m_state == 2)
            {
                color.g = 0.6f;
                color.b = 0.6f;
                GetComponent<Tilemap>().color = color;
            }
            else if (GameManager.instance.m_state == 0)
            {
                color.g = 1f;
                color.b = 1f;
                GetComponent<Tilemap>().color = color;
            }
        }
    }

    bool isSoft(string blockname)
    {
        if (blockname.Equals("SoftBlock2") || blockname.Equals("WeakBlock"))
            return true;
        else
            return false;
    }

    void OnMouseOver()
    {
        //this.GetComponent<Tilemap>(). = sprite;

    }

    void OnMouseExit()
    {

    }
}
