using WebSite.Core.ViewModel.RealEstate;
using WebSite.DataLayer.Entities.RealEstate;

namespace WebSite.Core.Services
{

    public interface IRealEstateService
    {
        Task<RealEstateListViewModel> GetRealEstateList(int page = 1, int group = -1, int type = -1, int city = -1, string search = "", int countPerPage = 100, int language = -1);
        Task<RealEstateListViewModel> GetRealEstateList(int page = 1, int countPerPage = 100);

        Task<IEnumerable<RealEstate>> GetRealEstateList(int language = -1);

        Task<IEnumerable<RealEstate>> GetRealEstateListByAgentId(int id);
        Task<IEnumerable<RealEstate>> GetRealEstateLatestList(int take = 100, int language = -1);

        Task<IEnumerable<RealEstate>> GetRelatedRealEstateListByGroupId(int id); // id = group id

        //rent period
        Task<IEnumerable<RealEstateRentPeriod>> GetRentPeriodList(int language = -1);

        //building direction
        Task<IEnumerable<RealEstateBuildingDirection>> GetRealEstateDirectionList(int language = -1);

        //status
        Task<IEnumerable<RealEstateStatus>> GetRealEstateStatusList(int language = -1);

        //usage
        Task<IEnumerable<RealEstateUsageStatus>> GetRealEstateUsageList(int language = -1);


        //option
        Task<IEnumerable<RealEstateOption>> GetRealEstateOptionList(int language = -1);
        Task<bool> CheckPropertyHasOption(int property, int option);

        Task<IEnumerable<RealEstateJoinOption>> GetOptionListByRealEstateId(int id);

        //comment
        Task<IEnumerable<RealEstateComment>> GetRealEstateCommentListByRealEstateId(int id);

        //photo
        Task<RealEstatePhotoListViewModel> GetRealEstatePhotoList(int page = 1, int countPerPage = 100);
        Task<IEnumerable<RealEstatePhoto>> GetPhotoListByRealEstateId(int id);
        Task<RealEstateCommentListViewModel> GetRealEstateCommentList(int page = 1);


        //comment 
        Task<IEnumerable<RealEstateComment>> GetNotAcceptedRealEstateCommentListByRealEstateId(int id);
        Task<IEnumerable<RealEstateComment>> GetNotAcceptedRealEstateCommentList();

        Task<bool> VisitPlusByRealEstateId(int id);
        Task<bool> VisitPlusByProjectId(int id);

        //group
        Task<IEnumerable<RealEstateGroup>> GetRealEstateGroupList(int language = -1);

        //type
        Task<IEnumerable<RealEstateType>> GetRealEstateTypeList(int language = -1);

        //project
        Task<RealEstateProjectListViewModel> GetProjectList(int page = 1, int city = -1, string search = "", int countPerPage = 100, int language = -1);
        Task<RealEstateProjectListViewModel> GetProjectList(int page = 1, int countPerPage = 100);
        Task<IEnumerable<RealEstateProject>> GetProjectList(int language);
        Task<IEnumerable<RealEstateProject>> GetProjectListByAgentId(int id);
        Task<IEnumerable<RealEstateProject>> GetProjectLatestList(int take = 100, int language = -1);

        //project photo 
        Task<IEnumerable<RealEstateProjectPhoto>> GetPhotoListByProjectId(int id);

        //project status
        Task<IEnumerable<RealEstateProjectStatus>> GetProjectStatusList(int language = -1);

        //project comment
        Task<IEnumerable<RealEstateProjectComment>> GeCommentListByProjectId(int id);
    }


    public class RealEstateService : IRealEstateService
    {
        private readonly IGenericRepository<RealEstate> _realEstateRepository;
        private readonly IGenericRepository<RealEstateBuildingDirection> _realEstateDirectionRepository;
        private readonly IGenericRepository<RealEstateProjectStatus> _projectStatusRepository;
        private readonly IGenericRepository<RealEstateStatus> _realEstateStatusRepository;
        private readonly IGenericRepository<RealEstateUsageStatus> _realEstateUsageRepository;
        private readonly IGenericRepository<RealEstateProjectComment> _projectCommentRepository;
        private readonly IGenericRepository<RealEstateProjectPhoto> _projectPhotoRepository;
        private readonly IGenericRepository<RealEstateProject> _projectRepository;
        private readonly IGenericRepository<RealEstateOption> _realEstateOptionRepository;
        private readonly IGenericRepository<RealEstateRentPeriod> _realEstateRentPeriodRepository;
        private readonly IGenericRepository<RealEstateJoinOption> _realEstateJoinOptionRepository;
        private readonly IGenericRepository<RealEstateType> _realEstateTypeRepository;
        private readonly IGenericRepository<RealEstateAge> _realEstateAgeRepository;
        private readonly IGenericRepository<RealEstatePhoto> _realEstatePhotoRepository;
        private readonly IGenericRepository<RealEstateGroup> _realEstateGroupRepository;
        private readonly IGenericRepository<RealEstateComment> _realEstateCommentRepository;


        public RealEstateService(IGenericRepository<RealEstate> realEstateRepository, IGenericRepository<RealEstateProjectStatus> projectStatusRepository, IGenericRepository<RealEstateProjectComment> projectCommentRepository, IGenericRepository<RealEstateProjectPhoto> projectPhotoRepository, IGenericRepository<RealEstateProject> projectRepository, IGenericRepository<RealEstateOption> realEstateOptionRepository, IGenericRepository<RealEstateRentPeriod> realEstateRentPeriodRepository, IGenericRepository<RealEstateJoinOption> realEstateJoinOptionRepository, IGenericRepository<RealEstateType> realEstateTypeRepository, IGenericRepository<RealEstateAge> realEstateAgeRepository, IGenericRepository<RealEstatePhoto> realEstatePhotoRepository, IGenericRepository<RealEstateGroup> realEstateGroupRepository, IGenericRepository<RealEstateComment> realEstateCommentRepository, IGenericRepository<RealEstateStatus> realEstateStatusRepository, IGenericRepository<RealEstateUsageStatus> realEstateUsageRepository, IGenericRepository<RealEstateBuildingDirection> realEstateDirectionRepository)
        {
            _realEstateRepository = realEstateRepository;
            _projectStatusRepository = projectStatusRepository;
            _projectCommentRepository = projectCommentRepository;
            _projectPhotoRepository = projectPhotoRepository;
            _projectRepository = projectRepository;
            _realEstateOptionRepository = realEstateOptionRepository;
            _realEstateRentPeriodRepository = realEstateRentPeriodRepository;
            _realEstateJoinOptionRepository = realEstateJoinOptionRepository;
            _realEstateTypeRepository = realEstateTypeRepository;
            _realEstateAgeRepository = realEstateAgeRepository;
            _realEstatePhotoRepository = realEstatePhotoRepository;
            _realEstateGroupRepository = realEstateGroupRepository;
            _realEstateCommentRepository = realEstateCommentRepository;
            _realEstateStatusRepository = realEstateStatusRepository;
            _realEstateUsageRepository = realEstateUsageRepository;
            _realEstateDirectionRepository = realEstateDirectionRepository;
        }

        public async Task<RealEstateListViewModel> GetRealEstateList(int page = 1, int group = -1, int type = -1, int city = -1, string search = "", int countPerPage = 100, int language = -1)
        {
            var realEstateList = await _realEstateRepository.Get(
                includes: "Group,City,Type,RentPeriod,Status,Language",
                orderBy: q => q.OrderByDescending(d => d.LastUpdate));

            //language filter
            if (language != -1)
            {
                realEstateList = realEstateList.Where(l => l.LanguageRefId == language);
            }

            //group filter
            if (group != -1)
            {
                realEstateList = realEstateList.Where(g => g.GroupRefId == group);
            }

            //type filter
            if (type != -1)
            {
                realEstateList = realEstateList.Where(g => g.TypeRefId == type);
            }

            //city filter
            if (city != -1)
            {
                realEstateList = realEstateList.Where(g => g.CityRefId == city);
            }

            //search filter
            if (search != "")
            {
                realEstateList = realEstateList.Where(i => i.Title != null && i.Title.Contains(search));
            }


            realEstateList = realEstateList.ToList();
            int take = countPerPage;
            int skip = (page - 1) * take;
            RealEstateListViewModel viewModel = new RealEstateListViewModel()
            {
                RealEstateList = realEstateList.Skip(skip).Take(take).ToList(),
                CurrentPage = page,
                PageCount = realEstateList.Count() / take,
                TotalCount = realEstateList.Count(),
            };
            return viewModel;
        }


        public async Task<RealEstateListViewModel> GetRealEstateList(int page = 1, int countPerPage = 100)
        {
            var realEstateList = await _realEstateRepository.Get(
                includes: "Group,City,Type,RentPeriod,Status,Language",
                orderBy: q => q.OrderByDescending(d => d.LastUpdate));

            realEstateList = realEstateList.ToList();
            int take = countPerPage;
            int skip = (page - 1) * take;
            RealEstateListViewModel viewModel = new RealEstateListViewModel()
            {
                RealEstateList = realEstateList.Skip(skip).Take(take).ToList(),
                CurrentPage = page,
                PageCount = realEstateList.Count() / take,
                TotalCount = realEstateList.Count(),
            };
            return viewModel;
        }



        public async Task<IEnumerable<RealEstate>> GetRealEstateList(int language = -1)
        {
            var realEstateList = await _realEstateRepository.Get(
                includes: "Group,City,Type,RentPeriod,Language,Status",
                orderBy: q => q.OrderByDescending(d => d.LastUpdate));

            //language filter
            if (language != -1)
            {
                realEstateList = realEstateList.Where(l => l.LanguageRefId == language);
            }

            return realEstateList;
        }


        public async Task<IEnumerable<RealEstate>> GetRealEstateListByAgentId(int id)
        {
            var realEstateList = await _realEstateRepository.Get(
                i => i.AgentRefId == id,
                includes: "Group,City,Type,RentPeriod,Language,Status",
                orderBy: q => q.OrderByDescending(d => d.LastUpdate));

            return realEstateList;
        }

        public async Task<IEnumerable<RealEstate>> GetRealEstateLatestList(int take = 100, int language = -1)
        {
            var realEstateList = await _realEstateRepository.Get(
                includes: "Group,City,Type,RentPeriod,Language,Status",
                orderBy: q => q.OrderByDescending(d => d.LastUpdate));

            //language filter
            if (language != -1)
            {
                realEstateList = realEstateList.Where(l => l.LanguageRefId == language);
            }

            return realEstateList.Take(take);

        }

        public async Task<IEnumerable<RealEstate>> GetRelatedRealEstateListByGroupId(int id)
        {
            var realEstateList = await _realEstateRepository.Get(
                a => a.GroupRefId == id,
                includes: "Group,City,Type,RentPeriod,Language,Status",
                orderBy: q => q.OrderByDescending(d => d.LastUpdate));

            return realEstateList;

        }

        public async Task<IEnumerable<RealEstateRentPeriod>> GetRentPeriodList(int language = -1)
        {
            var periodList = await _realEstateRentPeriodRepository.Get(
                orderBy: q => q.OrderBy(d => d.Sort));

            //language filter
            if (language != -1)
            {
                periodList = periodList.Where(l => l.LanguageRefId == language);
            }
            return periodList;
        }

        public async Task<IEnumerable<RealEstateBuildingDirection>> GetRealEstateDirectionList(int language = -1)
        {
            var directionList = await _realEstateDirectionRepository.Get(
                orderBy: q => q.OrderBy(d => d.Sort));

            //language filter
            if (language != -1)
            {
                directionList = directionList.Where(l => l.LanguageRefId == language);
            }
            return directionList;
        }

        public async Task<IEnumerable<RealEstateStatus>> GetRealEstateStatusList(int language = -1)
        {
            var statusList = await _realEstateStatusRepository.Get(
                orderBy: q => q.OrderBy(d => d.Sort));

            //language filter
            if (language != -1)
            {
                statusList = statusList.Where(l => l.LanguageRefId == language);
            }
            return statusList;
        }

        public async Task<IEnumerable<RealEstateUsageStatus>> GetRealEstateUsageList(int language = -1)
        {
            var usageList = await _realEstateUsageRepository.Get(
                orderBy: q => q.OrderBy(d => d.Sort));

            //language filter
            if (language != -1)
            {
                usageList = usageList.Where(l => l.LanguageRefId == language);
            }
            return usageList;
        }

        public async Task<IEnumerable<RealEstateOption>> GetRealEstateOptionList(int language = -1)
        {
            var optionList = await _realEstateOptionRepository.Get(
                orderBy: q => q.OrderBy(d => d.Sort));


            //language filter
            if (language != -1)
            {
                optionList = optionList.Where(l => l.LanguageRefId == language);
            }

            return optionList;
        }

        public async Task<bool> CheckPropertyHasOption(int property, int option)
        {
            var optionList = await _realEstateJoinOptionRepository.Get(
                i => i.OptionRefId == option && i.RealEstateRefId == property);

            if (optionList.Any())
            {
                return true;
            }

            return false;

        }


        public async Task<IEnumerable<RealEstateJoinOption>> GetOptionListByRealEstateId(int id)
        {
            var optionList = await _realEstateJoinOptionRepository.Get(
                i => i.RealEstateRefId == id,
                includes: "Option,RealEstate",
                orderBy: q => q.OrderBy(d => d.Option!.Sort));

            return optionList;
        }

        public async Task<IEnumerable<RealEstateComment>> GetRealEstateCommentListByRealEstateId(int id)
        {
            var commentList = await _realEstateCommentRepository.Get(
                i => i.RealEstateRefId == id,
                includes: "User,RealEstate",
                orderBy: q => q.OrderByDescending(d => d.SendDate));

            return commentList;
        }

        public async Task<RealEstatePhotoListViewModel> GetRealEstatePhotoList(int page = 1, int countPerPage = 100)
        {
            var photoList = await _realEstatePhotoRepository.Get(
                includes: "RealEstate",
                orderBy: q => q.OrderByDescending(d => d.UploadDate));

            photoList = photoList.ToList();
            int take = countPerPage;
            int skip = (page - 1) * take;

            RealEstatePhotoListViewModel viewModel = new RealEstatePhotoListViewModel()
            {
                PhotoList = photoList.Skip(skip).Take(take).ToList(),
                CurrentPage = page,
                PageCount = photoList.Count() / take,
                TotalCount = photoList.Count(),
            };
            return viewModel;
        }

        public async Task<IEnumerable<RealEstatePhoto>> GetPhotoListByRealEstateId(int id)
        {
            var photoList = await _realEstatePhotoRepository.Get(
                i => i.RealEstateRefId == id,
                includes: "RealEstate",
                orderBy: q => q.OrderBy(d => d.Sort));

            return photoList;
        }

        public async Task<IEnumerable<RealEstateProjectPhoto>> GetPhotoListByProjectId(int id)
        {
            var photoList = await _projectPhotoRepository.Get(
                i => i.ProjectRefId == id,
                includes: "Project",
                orderBy: q => q.OrderBy(d => d.Sort));

            return photoList;
        }

        public async Task<IEnumerable<RealEstateProjectStatus>> GetProjectStatusList(int language = -1)
        {
            var statusList = await _projectStatusRepository.Get(
                orderBy: q => q.OrderBy(d => d.Sort));

            if (language != -1)
            {
                statusList = statusList.Where(l => l.LanguageRefId == language);
            }

            return statusList;
        }

        public async Task<IEnumerable<RealEstateProjectComment>> GeCommentListByProjectId(int id)
        {
            var commentList = await _projectCommentRepository.Get(
                i => i.ProjectRefId == id,
                includes: "User,Project",
                orderBy: q => q.OrderByDescending(d => d.SendDate));

            return commentList;
        }


        public async Task<RealEstateCommentListViewModel> GetRealEstateCommentList(int page = 1)
        {
            var commentList = await _realEstateCommentRepository.Get(
                includes: "User,RealEstate",
                orderBy: q => q.OrderByDescending(d => d.SendDate));

            commentList = commentList.ToList();

            int take = 60;
            int skip = (page - 1) * take;
            RealEstateCommentListViewModel viewModel = new RealEstateCommentListViewModel()
            {
                CommentList = commentList.Skip(skip).Take(take).ToList(),
                CurrentPage = page,
                PageCount = commentList.Count() / take,
                TotalCount = commentList.Count(),
            };
            return viewModel;
        }



        public async Task<IEnumerable<RealEstateComment>> GetNotAcceptedRealEstateCommentListByRealEstateId(int id)
        {
            var realEstateCommentList = await _realEstateCommentRepository.Get(
                i => i.RealEstateRefId == id &&
                     i.IsAccept == false,
                includes: "User,RealEstate",
                orderBy: q => q.OrderByDescending(d => d.SendDate));
            return realEstateCommentList;
        }

        public async Task<IEnumerable<RealEstateComment>> GetNotAcceptedRealEstateCommentList()
        {
            var commentList = await _realEstateCommentRepository.Get(
                i => i.IsAccept == false,
                includes: "User,RealEstate",
                orderBy: q => q.OrderByDescending(d => d.SendDate));
            return commentList;
        }

        public async Task<bool> VisitPlusByRealEstateId(int id)
        {
            var realEstate = await _realEstateRepository.GetById(id);
            if (realEstate.Visit == null || realEstate.Visit < 0)
            {
                realEstate.Visit = 0;
            }

            realEstate.Visit += 1;

            await _realEstateRepository.Update(realEstate);

            return true;
        }

        public async Task<bool> VisitPlusByProjectId(int id)
        {
            var project = await _projectRepository.GetById(id);
            if (project.Visit == null || project.Visit < 0)
            {
                project.Visit = 0;
            }

            project.Visit += 1;

            await _projectRepository.Update(project);

            return true;
        }

        public async Task<IEnumerable<RealEstateGroup>> GetRealEstateGroupList(int language = -1)
        {
            var groupList = await _realEstateGroupRepository.Get(
                orderBy: q => q.OrderBy(d => d.Sort));

            //language filter
            if (language != -1)
            {
                groupList = groupList.Where(l => l.LanguageRefId == language);
            }

            return groupList;
        }


        public async Task<IEnumerable<RealEstateType>> GetRealEstateTypeList(int language = -1)
        {
            var typeList = await _realEstateTypeRepository.Get(
                orderBy: q => q.OrderBy(d => d.Sort));


            //language filter
            if (language != -1)
            {
                typeList = typeList.Where(l => l.LanguageRefId == language);
            }

            return typeList;
        }



        public async Task<RealEstateProjectListViewModel> GetProjectList(int page = 1, int city = -1, string search = "", int countPerPage = 100, int language = -1)
        {
            var projectList = await _projectRepository.Get(
                includes: "City,Language,Status",
                orderBy: q => q.OrderByDescending(d => d.LastUpdate));

            //language filter
            if (language != -1)
            {
                projectList = projectList.Where(l => l.LanguageRefId == language);
            }

            //city filter
            if (city != -1)
            {
                projectList = projectList.Where(g => g.CityRefId == city);
            }

            //search filter
            if (search != "")
            {
                projectList = projectList.Where(i => i.Title != null && i.Title.Contains(search));
            }

            projectList = projectList.ToList();
            int take = countPerPage;
            int skip = (page - 1) * take;
            RealEstateProjectListViewModel viewModel = new RealEstateProjectListViewModel()
            {
                ProjectList = projectList.Skip(skip).Take(take).ToList(),
                CurrentPage = page,
                PageCount = projectList.Count() / take,
                TotalCount = projectList.Count(),
            };

            return viewModel;
        }

        public async Task<RealEstateProjectListViewModel> GetProjectList(int page = 1, int countPerPage = 100)
        {
            var projectList = await _projectRepository.Get(
                includes: "City,Language,Status",
                orderBy: q => q.OrderByDescending(d => d.LastUpdate));


            projectList = projectList.ToList();
            int take = countPerPage;
            int skip = (page - 1) * take;
            RealEstateProjectListViewModel viewModel = new RealEstateProjectListViewModel()
            {
                ProjectList = projectList.Skip(skip).Take(take).ToList(),
                CurrentPage = page,
                PageCount = projectList.Count() / take,
                TotalCount = projectList.Count(),
            };

            return viewModel;
        }



        public async Task<IEnumerable<RealEstateProject>> GetProjectList(int language = -1)
        {
            var projectList = await _projectRepository.Get(
                includes: "City,Language",
                orderBy: q => q.OrderByDescending(d => d.LastUpdate));

            //language filter
            if (language != -1)
            {
                projectList = projectList.Where(l => l.LanguageRefId == language);
            }
            return projectList;
        }

        public async Task<IEnumerable<RealEstateProject>> GetProjectListByAgentId(int id)
        {
            var projectList = await _projectRepository.Get(
                l => l.AgentRefId == id,
                includes: "City,Language",
                orderBy: q => q.OrderByDescending(d => d.LastUpdate));

            return projectList;
        }

        public async Task<IEnumerable<RealEstateProject>> GetProjectLatestList(int take = 100, int language = -1)
        {
            var projectList = await _projectRepository.Get(
                includes: "City,Language,Status",
                orderBy: q => q.OrderByDescending(d => d.LastUpdate));

            //language filter
            if (language != -1)
            {
                projectList = projectList.Where(l => l.LanguageRefId == language);
            }
            return projectList.Take(take);
        }

    }
}
