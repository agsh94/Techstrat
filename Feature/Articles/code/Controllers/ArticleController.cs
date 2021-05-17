using Sitecore.Feature.Articles.Respositories;
using Sitecore.Mvc.Presentation;
using System.Web.Mvc;

namespace Sitecore.Feature.Articles.Controllers
{
    public class ArticleController : Controller
    {
        public ArticleController()
        {

        }
        public ActionResult List()
        {
            var articleRepository = new ArticleRepository();
            var items = articleRepository.Get(RenderingContext.Current.Rendering.Item);
            return this.View("List", items);
        }
        public ActionResult Detail()
        {
            var articleDetailRepository = new ArticleRepository();
            var item = articleDetailRepository.GetArticleDetail(Context.Item);
            return this.View("Detail", item);
        }
        public ActionResult RelatedArticle()
        {
            var articleRepository = new ArticleRepository();
            var items = articleRepository.GetRelatedArticle(RenderingContext.Current.Rendering.Item);
            return this.View("RelatedArticle", items);
        }
    }
}