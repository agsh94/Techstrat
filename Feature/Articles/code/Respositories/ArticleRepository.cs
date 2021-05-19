﻿namespace Sitecore.Feature.Articles.Respositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Sitecore.Data.Items;
    using Sitecore.Diagnostics;
    using Sitecore.Foundation.MultiTenant;

    [Service(typeof(IArticleRepository))]
    public class ArticleRepository : IArticleRepository
    {
        public IEnumerable<Item> Get(Item contextItem)
        {
            if (contextItem == null)
            {
                Log.Error("Item not found", contextItem);
                throw new ArgumentNullException(nameof(contextItem));
            }
            // return decendants of the current item.
            return contextItem.GetChildren().OrderBy(x => x.Name);

        }
        public Item GetArticleDetail(Item contextItem)
        {
            if (contextItem == null)
            {
                Log.Error("Item not found", contextItem);
                throw new ArgumentNullException(nameof(contextItem));
            }
            // return article details
            return contextItem;
        }
        public IEnumerable<Item> GetRelatedArticle(Item contextItem)
        {
            if (contextItem == null)
            {
                Log.Error("Item not found", contextItem);
                throw new ArgumentNullException(nameof(contextItem));
            }
            Data.Fields.MultilistField relatedArticles = contextItem?.Fields[Constants.Fields.RelatedArticlesField];
            Item[] items = relatedArticles?.GetItems();

            // return selected articles' details
            return items.OrderBy(x => x.Name);
        }
    }
}