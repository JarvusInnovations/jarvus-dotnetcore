using System;
using System.Collections.Generic;
using System.Linq;

namespace Jarvus.Settings
{
    public class AzureBlobStorageSettings
    {
        public string Name { get; set; }
        public string StorageAccountName { get; set; }

        public string AccessKey { get; set; }

        public string ContainerName { get; set; }

        public string BaseUri {
            get;

            set;
        }
    }
}