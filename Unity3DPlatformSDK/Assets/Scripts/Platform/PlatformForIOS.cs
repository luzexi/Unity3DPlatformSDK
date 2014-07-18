using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

//iOS平台类
//Author Sunyi
//2014-1-23
public class PlatformForIOS : PlatformBase
{
    protected IOSPay m_cIOSPay;   //支付类

    public PlatformForIOS()
    {
        this.m_cIOSPay = new IOSPay();
    }

    /// <summary>
    /// 初始化
    /// </summary>
    public override void Init()
    {
#if IOS && !UNITY_EDITOR
        this.m_cIOSPay.Init();
#endif
    }

    /// <summary>
    /// 更新版本
    /// </summary>
    /// <param name="path"></param>
    public override void UpdateVersion(string path)
    {
#if IOS && !UNITY_EDITOR
        this.m_cIOSPay.UpdateVersion(path);
#endif
    }

    /// <summary>
    /// 获取设备号
    /// </summary>
    /// <returns></returns>
    public override string GetDeviceID()
    {
        return "IOS";
    }

    /// <summary>
    /// 获取渠道号
    /// </summary>
    /// <returns></returns>
    public override string GetChannelName()
    {
        return "AppStore";
    }

    /// <summary>
    /// 暂停与恢复事件
    /// </summary>
    /// <param name="pause"></param>
    public override void OnApplicationPause(bool pause)
    {
        //发送数据
        if (!pause)
        {
            //
        }
    }

    /// <summary>
    /// 登录
    /// </summary>
    public override void Login()
    {
        //
    }

    /// <summary>
    /// 展示登录
    /// </summary>
    public override void ShowLogin()
    {
        //
    }

    /// <summary>
    /// 展示支付
    /// </summary>
    /// <param name="arg"></param>
    public override void ShowPayment( object[] arg)
    {
        string type_id = arg[3] as string;
        Debug.Log("Pay id " + type_id);
        int res = 0;
#if IOS && !UNITY_EDITOR
        res =  this.m_cIOSPay.Pay(type_id);
#endif
        Debug.Log(res + " pay res.");
        if (res != 100)
        {
            if(res == 101)
			{
				Debug.Log("该设备未开启应用内支付");
			}
            else
			{
				Debug.Log("支付失败");
			}
            return;
        }
    }

    /// <summary>
    /// 支付成功
    /// </summary>
    /// <param name="arg"></param>
    public override void OnPaymentSuccessCallBack(string arg)
    {
        string verify = arg;
        Debug.Log(verify + " verify");
    }

    /// <summary>
    /// 支付失败
    /// </summary>
    /// <param name="arg"></param>
    public override void OnPaymentFailCallBack(string arg)
    {
		Debug.Log(arg);
    }
}

