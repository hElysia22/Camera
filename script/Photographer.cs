using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Photographer : MonoBehaviour
{
    // Start is called before the first frame update
    public float Pitch { get; private set; }  //̧��

    public float Yaw { get; private set; }  //������ת��  

    public float mouseSpeed = 5;

    public float cameraRotatingSpeed = 80;

    private float cameraYspeed = 5;

    private Transform _target;

    // Update is called once per frame
    void Update()
    {
        UpdataRotation();
        UpdataPosition();
    }

    public void InitCamera(Transform target)     //��ʼ����Ӱ�������
    {
        _target = target;
        transform.position = _target.position;
    }
    public void UpdataRotation()
    {
        Yaw += Input.GetAxis("Mouse X") * mouseSpeed;
        Yaw += Input.GetAxis("CameraRateX") * cameraRotatingSpeed *Time.deltaTime;     //ҡ��
        Pitch -= Input.GetAxis("Mouse Y") * mouseSpeed;
        Pitch += Input.GetAxis("CameraRateY") * cameraRotatingSpeed * Time.deltaTime;  //ҡ��
        Pitch = Mathf.Clamp(Pitch, -90, 90);   //���ƴ�С

        transform.rotation = Quaternion.Euler(Pitch, Yaw, 0);   //ŷ����xָ����x����ת��Pitch��

    }

    public void UpdataPosition()    //��Ӱ������
    {
        Vector3 position = _target.position;
        float newY = Mathf.Lerp(transform.position.y, position.y,Time.deltaTime * cameraYspeed);   //����y����һ�������ֵ��ʹ��y������Ի����ƶ�
        transform.position = new Vector3(position.x, newY, position.z);
    }
}
