using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class SpawnableManager : MonoBehaviour
{
    // [SerializeField] = Inspector에 로드하여 다루기 위한 코드입니다.
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
        // 스폰 조건 설정이니다. 터치 상태가 무엇으로 되어이는지에 따라 오브젝트가 생성되고 움지깅게 됩니다.
        // 1. 터치 상태가 Begin
        // 1. 터치 상태가
        // 1. 터치 상태가

        //참고로 input을 안에 있는 클래스로 다양한 입력 감지 메소드를 지원합니다.
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

    //위치를 가져와서 Scene에 생성된 오브젝트를 이동하는 메서드
    private void SpawnPrefab(Vector3 spawnPosition)
    {
        spawnadObject = Instantiate(spawnablePrefab, spawnPosition, Quaternion.identity);
    }
}
