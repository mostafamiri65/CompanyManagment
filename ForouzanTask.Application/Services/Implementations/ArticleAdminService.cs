using ForouzanTask.Application.DTOs.Article;
using ForouzanTask.Application.Extensions;
using ForouzanTask.Application.Generators;
using ForouzanTask.Application.Services.Interfaces;
using ForouzanTask.Application.Statics;
using ForouzanTask.DataLayer.Context;
using ForouzanTask.DataLayer.Entities.Article;
using Microsoft.EntityFrameworkCore;

namespace ForouzanTask.Application.Services.Implementations
{
    public class ArticleAdminService : IArticleAdminService
    {
        private readonly ForouzanTaskContext _context;
        public ArticleAdminService(ForouzanTaskContext context)
        {
            _context = context;
        }

        public async Task<Guid> AddArticle(CreateArticleDto createArticleDto, Guid userId)
        {
            TbArticle article = new TbArticle();
            article.Id = Guid.NewGuid();
            if (createArticleDto.MainImage != null)
            {
                article.MainImageName = NameGenerator.GenerateUniqCode() +
                    Path.GetExtension(createArticleDto.MainImage.FileName);
                var validFormats = new List<string>()
                {
                ".png",
                ".jpg",
                ".jpeg"
                };
                var result = createArticleDto.MainImage.
                    UploadFile(article.MainImageName, PathTools.ArticleImageServerPath, validFormats);
                if (!result) return Guid.Empty;

            }

            if (createArticleDto.SliderPicture != null)
            {
                article.SliderPicture = NameGenerator.GenerateUniqCode() +
                    Path.GetExtension(createArticleDto.SliderPicture.FileName);
                var validFormats = new List<string>()
                {
                ".png",
                ".jpg",
                ".jpeg"
                };
                var result = createArticleDto.SliderPicture.
                    UploadFile(article.SliderPicture, PathTools.ArticleImageServerPath, validFormats);
                if (!result) return Guid.Empty;

            }
            article.Title = createArticleDto.Title;
            article.ShortDescription = createArticleDto.ShortDescription;
            article.CategoryId = createArticleDto.CategoryId;
            article.MetaDescription = createArticleDto.MetaDescription;
            article.IsApproal = false;
            article.IsShown = false;
            article.CreateDate = DateTime.Now;
            article.CreateUserId = userId;
            article.LastModifiedUserIp = GetIpAddress.GetIp();
            article.LastModifiedUserMac = GetMacAddress.GetClientMAC(article.LastModifiedUserIp);

            await _context.TbArticles.AddAsync(article);
            await _context.SaveChangesAsync();
            return article.Id;
        }

        public async Task<bool> AddSubArticle(CreateSubArticleDto createSubArticle, Guid userId)
        {
            TbSubArticle sub = new TbSubArticle();
            sub.Id = Guid.NewGuid();
            sub.ArticleId = createSubArticle.ArticleId;
            sub.Content = createSubArticle.Content;
            sub.CreateDate = DateTime.Now;
            sub.CreateUserId = userId;
            if (createSubArticle.Picture != null)
            {
                sub.PictureName = NameGenerator.GenerateUniqCode() +
                    Path.GetExtension(createSubArticle.Picture.FileName);
                var validFormats = new List<string>()
                {
                ".png",
                ".jpg",
                ".jpeg"
                };
                var result = createSubArticle.Picture.
                    UploadFile(sub.PictureName, PathTools.ArticleImageServerPath, validFormats);
                if (!result) return false;
            }
            sub.LoadPictureInMaxSize = true;
            sub.LastModifiedUserIp = GetIpAddress.GetIp();
            sub.LastModifiedUserMac = GetMacAddress.GetClientMAC(sub.LastModifiedUserIp);
            await _context.TbSubArticles.AddAsync(sub);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<ArticleDto?> GetArticleById(Guid id)
        {
            var article = await _context.TbArticles.SingleOrDefaultAsync(a => a.Id == id);
            if (article != null)
            {
                ArticleDto dto = new ArticleDto()
                {
                    Id = article.Id,
                    Category = await _context.TbCategories.SingleAsync(c => c.Id == article.CategoryId),
                    CreateDate = article.CreateDate,
                    CreatedBy = await _context.TbUsers.SingleAsync(u => u.Id == article.CreateUserId),
                    MainImageName = article.MainImageName,
                    IsApproal = article.IsApproal,
                    IsShown = article.IsShown,
                    MetaDescription = article.MetaDescription,
                    ShortDescription = article.ShortDescription,
                    SliderPicture = article.ShortDescription,
                    Title = article.Title
                };


                return dto;
            }
            return null;
        }


        public async Task<List<ArticleListDto>> GetArticleList()
        {
            var articles = await _context.TbArticles.Where(a => !a.IsDelete).ToListAsync();
            List<ArticleListDto> list = new List<ArticleListDto>();
            foreach (var article in articles)
            {
                var user = await _context.TbUsers
                    .SingleOrDefaultAsync(u => u.Id == article.CreateUserId);
                var category = await _context.TbCategories.SingleOrDefaultAsync(c =>
                c.Id == article.CategoryId);
                ArticleListDto articleListDto = new ArticleListDto();
                articleListDto.Id = article.Id;
                articleListDto.Title = article.Title;
                articleListDto.CreateDate = article.CreateDate;
                if (user != null)
                    articleListDto.CreatedBy = user;
                if (article.MainImageName != null)
                    articleListDto.MainImageName = article.MainImageName;
                if (article.ShortDescription != null)
                    articleListDto.ShortDescription = article.ShortDescription;
                articleListDto.IsApproal = article.IsApproal;
                if (article.MetaDescription != null)
                    articleListDto.MetaDescription = article.MetaDescription;
                articleListDto.IsShown = article.IsShown;
                if (article.SliderPicture != null)
                    articleListDto.SliderPicture = article.SliderPicture;
                if (category != null)
                    articleListDto.Category = category;
                list.Add(articleListDto);
            }
            return list;
        }

        public async Task<List<CategoryListDto>> GetCategories()
        {
            var categories = await _context.TbCategories.ToListAsync();
            List<CategoryListDto> list = new List<CategoryListDto>();
            foreach (var item in categories)
            {
                if (item.Title != null)
                {
                    CategoryListDto dto = new CategoryListDto()
                    {
                        Id = item.Id,
                        Name = item.Title
                    };
                    list.Add(dto);
                }
            }
            return list;
        }

        public async Task<List<SubArticleDto>> GetSubArticles(Guid articleId)
        {
            var subs = await _context.TbSubArticles
                 .Where(s => s.ArticleId == articleId).ToListAsync();
            List<SubArticleDto> list = new List<SubArticleDto>();
            foreach (var item in subs)
            {
                SubArticleDto dto = new SubArticleDto()
                {
                    Id = item.Id,
                    Article = await GetArticleById(item.ArticleId),
                    Content = item.Content,
                    NumberOfParagraph = item.NumberOfParagraph,
                    PictureName = item.PictureName
                };
                list.Add(dto);
            }
            return list;
        }

        public async Task<int> GetNumOfParagraphForSubArticle(Guid articleId)
        {
            var subs = await _context.TbSubArticles
                 .Where(s => s.ArticleId == articleId)
                 .OrderByDescending(s => s.NumberOfParagraph).ToListAsync();
            if (subs.Count == 0) return 1;
            int currentNum = subs[0].NumberOfParagraph;
            return currentNum + 1;
        }

        public async Task<bool> IsTheNumOfParagraphOK(Guid articleId, int num)
        {
            var subs = await _context.TbSubArticles
                 .Where(s => s.ArticleId == articleId)
                 .OrderByDescending(s => s.NumberOfParagraph).ToListAsync();
            var enterdNum = subs.Select(s => s.NumberOfParagraph).ToList();
            if (subs.Count == 0 && num == 1)
                return true;
            int currentNum = subs[0].NumberOfParagraph;
            if (currentNum <= num + 1)
            {
                return true;
            }
            else if (!enterdNum.Contains(num))
            {
                return true;
            }
            return false;
        }
    }
}
