﻿using System;
using System.Collections.Generic;

namespace ZeonTicaret.WebUI.Models
{
    public partial class AspnetSchemaVersions
    {
        public string Feature { get; set; }
        public string CompatibleSchemaVersion { get; set; }
        public bool IsCurrentVersion { get; set; }
    }
}
