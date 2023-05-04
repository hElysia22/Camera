using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Photographer : MonoBehaviour
{
    // Start is called before the first frame update
    public float Pitch { get; private set; }  //抬升

    public float Yaw { get; private set; }  //左右旋转度  

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

    public void InitCamera(Transform target)     //初始化摄影机跟随点
    {
        _target = target;
        transform.position = _target.position;
    }
    public void UpdataRotation()
    {
        Yaw += Input.GetAxis("Mouse X") * mouseSpeed;
        Yaw += Input.GetAxis("CameraRateX") * cameraRotatingSpeed *Time.deltaTime;     //摇杆
        Pitch -= Input.GetAxis("Mouse Y") * mouseSpeed;
        Pitch += Input.GetAxis("CameraRateY") * cameraRotatingSpeed * Time.deltaTime;  //摇杆
        Pitch = Mathf.Clamp(Pitch, -90, 90);   //限制大小

        transform.rotation = Quaternion.Euler(Pitch, Yaw, 0);   //欧拉角x指绕着x轴旋转了Pitch度

    }

    public void UpdataPosition()    //摄影机跟随
    {
        Vector3 position = _target.position;
        float newY = Mathf.Lerp(transform.position.y, position.y,Time.deltaTime * cameraYspeed);   //给予y坐标一个跟随差值，使得y坐标可以缓缓移动
        transform.position = new Vector3(position.x, newY, position.z);
    }
}
