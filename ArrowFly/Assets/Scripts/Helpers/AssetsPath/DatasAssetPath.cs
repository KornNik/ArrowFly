using System.Collections.Generic;
using Helpers.Extensions;

namespace Helpers.AssetsPath
{
    sealed class DatasAssetPath
    {
        public static Dictionary<DataTypes, string> DatasPath = new Dictionary<DataTypes, string>
        {
            {
                DataTypes.BundleData, StringBuilderExtender.CreateString
                (ResourcesPathManager.DATA_FOLDER,ResourcesPathManager.DATA_BUNDLE_NAME)
            }
        };
    }
}