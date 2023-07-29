using AppsFlyerSDK;
using System.Collections.Generic;
using UnityEngine;

public class ConversionDataLoader : MonoBehaviour, IAppsFlyerConversionData
{
    private const string DevKey = "ZLigGqGzDdxGMT7QBPjsMG";

    public void Load()
    {
        AppsFlyer.setIsDebug(true);
        AppsFlyer.initSDK(DevKey, null, this);
        AppsFlyer.startSDK();
    }

    public void onAppOpenAttribution(string attributionData)
    {
        AppsFlyer.AFLog("onAppOpenAttribution", attributionData);
        Dictionary<string, object> attributionDataDictionary = AppsFlyer.CallbackStringToDictionary(attributionData);
    }

    public void onAppOpenAttributionFailure(string error)
    {
        AppsFlyer.AFLog("onAppOpenAttributionFailure", error);
    }

    public void onConversionDataFail(string error)
    {
        AppsFlyer.AFLog("onConversionDataFail", error);
    }

    public void onConversionDataSuccess(string conversionData)
    {
        AppsFlyer.AFLog("onConversionDataSuccess", conversionData);
        Dictionary<string, object> conversionDataDictionary = AppsFlyer.CallbackStringToDictionary(conversionData);
    }
}
