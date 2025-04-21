namespace WebSite.Core.ViewModel.Agent
{
    public class AgentListViewModel
    {
        public List<DataLayer.Entities.Agent.Agent>? AgentList { get; set; }

        public string? SearchText { get; set; }

        public int CurrentPage { get; set; }

        public int PageCount { get; set; }

        public int TotalCount { get; set; }
    }
}
