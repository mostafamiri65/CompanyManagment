using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForouzanTask.Application.Statics
{
    public static class PathTools
    {
        #region User

        public static readonly string DefaultUserAvatar = "DefaultAvatar.png";

        public static readonly string UserAvatarServerPath = 
            Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/user/Avatar/");
        public static readonly string UserAvatarPath = "/content/user/";
        public static readonly string ProjectDocumentServerPath =
           Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Project/File/");

        public static readonly string ArticleImageServerPath =
          Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Article/File/");
        public static readonly string ArticleImagePath = "/Article/File/";

        #endregion

        #region Site

        public static readonly string SiteAddress = "https://localhost:44308";

        #endregion

        #region Ckeditor

        public static readonly string EditorImageServerPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/content/ckeditor/");
        public static readonly string EditorImagePath = "/content/ckeditor/";

        #endregion
    }
}
