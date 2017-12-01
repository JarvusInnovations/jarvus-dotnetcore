using System;
using System.Collections.Generic;
using System.Linq;

namespace V2Props.Settings
{
    public class AzureStorageSettings
    {
        public string StorageAccountName { get; set; }

        public string AccessKey { get; set; }

        public string FullImagesContainerName { get; set; }

        public string ScaledImageContainerName { get; set; }

        public string FullImageBaseUri { get; set; }

        public bool IsValid() {
            return !(
                    String.IsNullOrEmpty(StorageAccountName) &&
                    String.IsNullOrEmpty(AccessKey) &&
                    String.IsNullOrEmpty(FullImagesContainerName) &&
                    String.IsNullOrEmpty(ScaledImageContainerName) &&
                    String.IsNullOrEmpty(FullImageBaseUri)
                );
        }
    }
}