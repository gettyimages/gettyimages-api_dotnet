﻿using System;

namespace GettyImages.Api.Entity;

[Flags]
public enum ProductType
{
    None = 0,
    [Description("editorialsubscription")] Editorialsubscription = 2,
    [Description("premiumaccess")] Premiumaccess = 4,
    [Description("easyaccess")] Easyaccess = 8,

    [Description("royaltyfreesubscription")]
    Royaltyfreesubscription = 16,
    [Description("imagepack")] Imagepack = 32
}