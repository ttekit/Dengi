using System;

namespace Dengi.Core;

public class Config
{
    private static Config _instance; 
    
    private Config()
    {
        
    }

    public static Config Instance
    {
        get { 
            if(_instance == null) _instance = new Config();
            return _instance;
        }
    }



    public string AssetsPath = @"E:\Dengi\Dengi\Assets";
    public string ToolPlanelImagesPath = _instance.AssetsPath + @"\ToolPanelImages\";
}