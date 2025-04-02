using Helpers;
using Helpers.Extensions;
using Helpers.AssetsPath;
using Data;

namespace Behaviours
{
    sealed class DataInitializer : IInitialization
    {
        private DatasBundle _datasBundle;
        
        public void Initialization()
        {
            _datasBundle = CustomResources.Load<DatasBundle>(DatasAssetPath.DatasPath[DataTypes.BundleData]);
            Services.Instance.DatasBundle.SetObject(_datasBundle);
            Services.Instance.DataResourcePrefabs.SetObject(_datasBundle.GetData<DataResourcePrefabs>());
        }
    }
}