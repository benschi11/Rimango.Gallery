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

            manifest.DefineStyle("Rimango.Gallery.Overview").SetUrl("Gallery.Overview.css");
            manifest.DefineStyle("PrettyPhoto").SetUrl("prettyPhoto.css");
            manifest.DefineStyle("Rimango.Gallery.Detail").SetUrl("Gallery.Detail.css");

            manifest.DefineScript("Rimango.Gallery.Detail").SetUrl("Gallery.Detail.js").SetDependencies("jQuery");
            manifest.DefineScript("Rimango.Gallery.Overview").SetUrl("Gallery.Overview.js").SetDependencies("jQuery");
            manifest.DefineScript("PrettyPhoto").SetUrl("PrettyPhoto/jquery.prettyPhoto.js").SetDependencies("jQuery");
            manifest.DefineScript("Masonry").SetUrl("Masonry/masonry.pkgd.min.js").SetDependencies("jQuery");
        }
    }
}