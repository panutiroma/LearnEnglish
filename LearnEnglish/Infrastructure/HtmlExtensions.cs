using System.Web.Mvc;
using System.Web.Routing;

namespace LearnEnglish.Infrastructure
{
    public static class HtmlExtensions
    {
        public static string TranslationToHtml(string text)
        {
            text = "<p><i>" + text.Replace("-", "</i>-");

            return text.Replace("\n\r", "</p><p><i>") + "</p>";
        }

        public static MvcHtmlString MyActonLink(
        this HtmlHelper html,
        string linkText,
        string action,
        string controller,
        object routeValues,
        object htmlAttributes
    )
        {
            var urlHelper = new UrlHelper(html.ViewContext.RequestContext);
            var url = urlHelper.Action(action, controller, routeValues);
            var anchor = new TagBuilder("a") {InnerHtml = linkText};
            anchor.Attributes["href"] = url;
            anchor.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            return MvcHtmlString.Create(anchor.ToString());
        }
    }
}