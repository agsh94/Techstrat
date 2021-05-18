namespace Sitecore.Feature.Articles.Respositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Sitecore.Data.Items;

    public class ArticleRepository : IArticleRepository
    {
        public IEnumerable<Item> Get(Item contextItem)
        {
            if (contextItem == null)
            {
                throw new ArgumentNullException(nameof(contextItem));
            }
            return contextItem.GetChildren().OrderBy(x => x.Name);

        }
        public Item GetArticleDetail(Item contextItem)
        {
            if (contextItem == null)
            {
                throw new ArgumentNullException(nameof(contextItem));
            }

            return contextItem;
        }
        public IEnumerable<Item> GetRelatedArticle(Item contextItem)
        {
            if (contextItem == null)
            {
                throw new ArgumentNullException(nameof(contextItem));
            }
            Data.Fields.MultilistField relatedArticles = contextItem?.Fields[Constants.Fields.RelatedArticlesField];
            Item[] items = relatedArticles?.GetItems();

            return items.OrderBy(x => x.Name);
        }
    }
}