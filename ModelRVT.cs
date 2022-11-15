﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Xml;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RServerViewer
{
    internal class ModelRVT 
    {
        public object LockContext { get; set; }
        public int LockState { get; set; }
        public object ModelLocksInProgress { get; set; }
        public int ModelSize { get; set; }

        [JsonPropertyName("Name")]
        public string ModelName { get; set; }
        public int ProductVersion { get; set; }
        public int SupportSize { get; set; }
    }
}
