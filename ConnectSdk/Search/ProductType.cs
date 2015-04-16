using System;

namespace GettyImages.Connect.Search
{
    [Flags]
    public enum ProductType
    {
        None =0,
        editorialsubscription =2,
        premiumaccess = 4,
        easyaccess = 8,
        royaltyfreesubscription = 16,
        imagepack =32
    }
}