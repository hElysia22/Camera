# Camera
unity3d 人物跟随视角进行移动的脚本 c#
V1.0  采用获取摄像机当前方向的方法，让人物沿着摄像机方向移动
V2.0  采用TranformDirection方法，更加容易理解

注意：出现错误是因为没添加手柄配置
如果不想用手柄，注释掉图片中的两行内容即可
如果想用手柄
按照图片在inputManager添加图片中的内容

注意2：
main camera要放在一个空物体下，如图所示
并且代码也放在空物体下，main camera不放代码
如果main camera下放代码会导致变成第一人称视角
