namespace ReaperInvasion.UI
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

    public sealed class AssetLoader
    {
        private static readonly AssetLoader instance = new AssetLoader();

        private static Dictionary<AssetType,BitmapFrame> assets; 

        private AssetLoader()
        {
            assets = new Dictionary<AssetType,BitmapFrame>();
        }

        public static AssetLoader Instance
        {
            get
            {
                return instance;
            }
        }

        public Image GetImage(AssetType type)
        {
            return new Image()
            {
                Source =  this.LoadImage(type) 
            };
        }

        private ImageSource LoadImage(AssetType type)
        {
            if (!assets.ContainsKey(type))
            {
                string path = string.Empty;

                switch (type)
                {
                    case AssetType.Reaper:
                        path = AssetPaths.ReaperImage;
                        break;
                    default:
                        throw new ArgumentException("Unsupported asset type.");
                }

                var src = new Uri(path, UriKind.Relative);
                var asset = BitmapFrame.Create(src);
                assets.Add(type, asset);
            }

            return assets[type];
        }
    }
}
