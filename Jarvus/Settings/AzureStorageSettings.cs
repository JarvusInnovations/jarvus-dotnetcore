using System;
using System.Collections.Generic;
using System.Linq;

namespace Jarvus.Settings
{
    public class AzureStorageSettings
    {

        public IEnumerable<AzureBlobStorageSettings> BlobStorageSettings { get; set; }

        public AzureBlobStorageSettings GetBlobStorageSettingsByName(string name)
        {
            if (BlobStorageSettings.Count() == 0) {
                throw new Exception($"no BlobStorageSettings are set. Cannot find one with attribute Name of '{name}'");
            }
            var result = BlobStorageSettings
                            .Where(settings => settings.Name.Equals(name))
                            .SingleOrDefault();

            if (result == null) {
                throw new Exception($"no bob storage account settings found with name '{name}'. Settings should be under AzureStorage.BlobStorageSettings in an array of configs with an attribute Name");
            }
            return result;
        }
    }
}