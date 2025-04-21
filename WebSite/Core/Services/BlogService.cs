using WebSite.Core.ViewModel.Blog;
using WebSite.DataLayer.Entities.Blog;

namespace WebSite.Core.Services
{

    public interface IBlogService
    {
        Task<BlogListViewModel> GetBlogList(int page = 1, int group = -1, string search = "", int countPerPage = 100,int language=-1);
        Task<IEnumerable<Blog>> GetBlogList(int language=-1);
        Task<IEnumerable<Blog>> GetBlogLatestList(int take = 100, int language = -1);

        //comment
        Task<IEnumerable<BlogComment>> GetCommentListByBlogId(int id);

        //photo
        Task<IEnumerable<BlogPhoto>> GetPhotoListByBlogId(int id);



        //comment 
        Task<BlogCommentListViewModel> GetBlogCommentList(int page = 1);

        Task<IEnumerable<BlogComment>> GetAcceptedBlogCommentListByBlogId(int id);
        Task<IEnumerable<BlogComment>> GetNotAcceptedBlogCommentListByBlogId(int id);
        Task<IEnumerable<BlogComment>> GetNotAcceptedBlogCommentList();

        Task<bool> VisitPlusBlogByBlogId(int id);

        //group
        Task<IEnumerable<BlogGroup>> GetBlogGroupList(int language = -1);
    }


    public class BlogService : IBlogService
    {
        private readonly IGenericRepository<Blog> _blogRepository;
        private readonly IGenericRepository<BlogPhoto> _blogPhotoRepository;
        private readonly IGenericRepository<BlogGroup> _blogGroupRepository;
        private readonly IGenericRepository<BlogComment> _blogCommentRepository;


        public BlogService(IGenericRepository<Blog> blogRepository, IGenericRepository<BlogPhoto> blogPhotoRepository, IGenericRepository<BlogGroup> blogGroupRepository, IGenericRepository<BlogComment> blogCommentRepository)
        {
            _blogRepository = blogRepository;
            _blogPhotoRepository = blogPhotoRepository;
            _blogGroupRepository = blogGroupRepository;
            _blogCommentRepository = blogCommentRepository;
        }

        public async Task<BlogListViewModel> GetBlogList(int page = 1, int group = -1, string search = "", int countPerPage = 100, int language = -1)
        {
            var blogList = await _blogRepository.Get(
                includes: "Group,Language",
                orderBy: q => q.OrderByDescending(d => d.BlogDate));

            blogList = blogList.ToList();

            //language filter
            if (language != -1)
            {
                blogList = blogList.Where(l => l.LanguageRefId == language);
            }

            int take = countPerPage;
            int skip = (page - 1) * take;
            BlogListViewModel viewModel = new BlogListViewModel()
            {
                BlogList = blogList.Skip(skip).Take(take).ToList(),
                CurrentPage = page,
                PageCount = blogList.Count() / take,
                TotalCount = blogList.Count(),
            };


            return viewModel;
        }


       

        public async Task<IEnumerable<Blog>> GetBlogList(int language = -1)
        {
            var blogList = await _blogRepository.Get(
                includes: "Group,Language",
                orderBy: q => q.OrderByDescending(d => d.BlogDate));

            //language filter
            if (language != -1)
            {
                blogList = blogList.Where(l => l.LanguageRefId == language);
            }

            return blogList;
        }

        public async Task<IEnumerable<Blog>> GetBlogLatestList(int take = 100, int language = -1)
        {
            var blogList = await _blogRepository.Get(
                includes: "Group,Language",
                orderBy: q => q.OrderByDescending(d => d.BlogDate));


            //language filter
            if (language != -1)
            {
                blogList = blogList.Where(l => l.LanguageRefId == language);
            }


            return blogList.Take(take);

        }

        public async Task<IEnumerable<BlogComment>> GetCommentListByBlogId(int id)
        {
            var blogCommentList = await _blogCommentRepository.Get(
                i => i.BlogRefId == id,
                includes: "User,Blog",
                orderBy: q => q.OrderByDescending(d => d.SendDate));
            return blogCommentList;
        }

        public async Task<IEnumerable<BlogPhoto>> GetPhotoListByBlogId(int id)
        {
            var photoList = await _blogPhotoRepository.Get(
                i => i.BlogRefId == id,
                includes: "Blog",
                orderBy: q => q.OrderByDescending(d => d.UploadDate));
            return photoList;
        }

        public async Task<BlogCommentListViewModel> GetBlogCommentList(int page = 1)
        {
            var commentList = await _blogCommentRepository.Get(
                includes: "User,Blog",
                orderBy: q => q.OrderByDescending(d => d.SendDate));

            commentList = commentList.ToList();

            int take = 60;
            int skip = (page - 1) * take;
            BlogCommentListViewModel viewModel = new BlogCommentListViewModel()
            {
                CommentList = commentList.Skip(skip).Take(take).ToList(),
                CurrentPage = page,
                PageCount = commentList.Count() / take,
                TotalCount = commentList.Count(),
            };
            return viewModel;
        }

        public async Task<IEnumerable<BlogComment>> GetAcceptedBlogCommentListByBlogId(int id)
        {
            var blogCommentList = await _blogCommentRepository.Get(
                i => i.BlogRefId == id &&
                i.IsAccept == true,
                includes: "User,Blog",
                orderBy: q => q.OrderByDescending(d => d.SendDate));
            return blogCommentList;
        }

        public async Task<IEnumerable<BlogComment>> GetNotAcceptedBlogCommentListByBlogId(int id)
        {
            var blogCommentList = await _blogCommentRepository.Get(
                i => i.BlogRefId == id &&
                     i.IsAccept == false,
                includes: "User,Blog",
                orderBy: q => q.OrderByDescending(d => d.SendDate));
            return blogCommentList;
        }

        public async Task<IEnumerable<BlogComment>> GetNotAcceptedBlogCommentList()
        {
            var commentList = await _blogCommentRepository.Get(
                i => i.IsAccept == false,
                includes: "User,Blog",
                orderBy: q => q.OrderByDescending(d => d.SendDate));
            return commentList;
        }

        public async Task<bool> VisitPlusBlogByBlogId(int id)
        {
            var blog = await _blogRepository.GetById(id);
            if (blog.Visit == null || blog.Visit < 0)
            {
                blog.Visit = 0;
            }

            blog.Visit += 1;

            await _blogRepository.Update(blog);

            return true;
        }

        public async Task<IEnumerable<BlogGroup>> GetBlogGroupList(int language = -1)
        {
            var groupList = await _blogGroupRepository.Get(
                orderBy: q => q.OrderBy(
                    d => d.Language).ThenBy(s => s.Sort));

            //language filter
            if (language != -1)
            {
                groupList = groupList.Where(l => l.LanguageRefId == language);
            }

            return groupList;
        }

        
    }
}
