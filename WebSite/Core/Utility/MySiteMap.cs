﻿using System.Xml.Linq;
using WebSite.Core.ViewModel.SiteMap;
using WebSite.Core.ViewModel;


namespace WebSite.Core.Utility
{
    public class MySiteMap
    {
        private readonly XNamespace NS = "http://www.sitemaps.org/schemas/sitemap/0.9";
        private List<SiteMapUrl> _urls;
        public MySiteMap()
        {
            _urls = new List<SiteMapUrl>();
        }



        #region Sitemap Generator
        public void AddUrl(string url, DateTime? modified = null, ChangeFrequency? changeFrequency = null, double? priority = null)
        {
            _urls.Add(new SiteMapUrl()
            {
                Url = url,
                Modified = modified,
                ChangeFrequency = changeFrequency,
                Priority = priority,
            });
        }

        public override string ToString()
        {
            var sitemap = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement(NS + "urlset",
                    from item in _urls
                    select CreateItemElement(item)
                ));

            return sitemap.ToString();
        }

        private XElement CreateItemElement(SiteMapUrl url)
        {
            XElement itemElement = new XElement(NS + "url", new XElement(NS + "loc", url.Url));

            if (url.Modified.HasValue)
            {
                itemElement.Add(new XElement(NS + "lastmod", url.Modified.Value.ToString("yyyy-MM-ddTHH:mm:ss.f") + "+00:00"));
            }

            if (url.ChangeFrequency.HasValue)
            {
                itemElement.Add(new XElement(NS + "changefreq", url.ChangeFrequency.Value.ToString().ToLower()));
            }

            if (url.Priority.HasValue)
            {
                itemElement.Add(new XElement(NS + "priority", url.Priority.Value.ToString("N1")));
            }

            return itemElement;
        }
        #endregion

    }
}
