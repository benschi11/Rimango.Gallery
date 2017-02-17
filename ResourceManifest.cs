using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rimango.Gallery
{
    using Orchard.UI.Resources;

    public class ResourceManifest : IResourceManifestProvider
    {
        public void BuildManifests(ResourceManifestBuilder builder)
        {
            var manifest = builder.Add();

            manifest.DefineStyle("Rimango.Gallery.Overview").SetUrl("Gallery.Overview.min.css", "Gallery.Overview.css");
            manifest.DefineStyle("PrettyPhoto").SetUrl("prettyPhoto.css");
            manifest.DefineStyle("Rimango.Gallery.Detail").SetUrl("Gallery.Detail.min.css", "Gallery.Detail.css");
            manifest.DefineStyle("Rimango.Gallery.FrontPage").SetUrl("Gallery.FrontPage.css", "Gallery.FrontPage.min.css");

            manifest.DefineScript("Rimango.Gallery.Detail").SetUrl("Gallery.Detail.js").SetDependencies("jQuery");
            manifest.DefineScript("Rimango.Gallery.Overview").SetUrl("Gallery.Overview.js").SetDependencies("jQuery");
            manifest.DefineScript("PrettyPhoto").SetUrl("PrettyPhoto/jquery.prettyPhoto.js").SetDependencies("jQuery");
            manifest.DefineScript("Masonry").SetUrl("Masonry/masonry.pkgd.min.js").SetDependencies("jQuery").SetDependencies("ImagesLoaded");
            manifest.DefineScript("ImagesLoaded").SetUrl("ImagesLoaded/imagesloaded.pkgd.min.js").SetDependencies("jQuery");

            
        }
    }
}