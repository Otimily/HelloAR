using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class SpawnableManager : MonoBehaviour
{
    // [SerializeField] = Inspector�� �ε��Ͽ� �ٷ�� ���� �ڵ��Դϴ�.
    [SerializeField]

    ARRaycastManager m_RaycastManager;
    List<ARRaycastHit> m_Hits = new List<ARRaycastHit>();
    [SerializeField]
    GameObject spawnablePrefab;

    GameObject spawnadObject;

    void Start()
    {
        spawnadObject = null;
    }

    void Update()
    {
        // ���� ���� �����̴ϴ�. ��ġ ���°� �������� �Ǿ��̴����� ���� ������Ʈ�� �����ǰ� ������� �˴ϴ�.
        // 1. ��ġ ���°� Begin
        // 1. ��ġ ���°�
        // 1. ��ġ ���°�

        //����� input�� �ȿ� �ִ� Ŭ������ �پ��� �Է� ���� �޼ҵ带 �����մϴ�.
        if (Input.touchCount == 0)
            return;
        if (m_RaycastManager.Raycast(Input.GetTouch(0).position, m_Hits))
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                SpawnPrefab(m_Hits[0].pose.position);
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Moved && spawnadObject != null)
            {
                spawnadObject.transform.position = m_Hits[0].pose.position;
            }
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                spawnadObject = null;
            }

        }
    }

    //��ġ�� �����ͼ� Scene�� ������ ������Ʈ�� �̵��ϴ� �޼���
    private void SpawnPrefab(Vector3 spawnPosition)
    {
        spawnadObject = Instantiate(spawnablePrefab, spawnPosition, Quaternion.identity);
    }
}
