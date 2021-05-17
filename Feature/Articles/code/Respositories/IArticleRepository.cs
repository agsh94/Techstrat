﻿namespace Sitecore.Feature.Articles.Respositories
{
    using Sitecore.Data.Items;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    public interface IArticleRepository
    {
        IEnumerable<Item> Get(Item contextItem);
    }
}