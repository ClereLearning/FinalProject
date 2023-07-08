namespace ISAT.Client.Services.InterviewService
{
    public interface IInterviewService
    {
        public List<Interview> Interviews { get; set; }
        public Task<List<Interview>> GetInterviews();
        public Task<Interview> GetInterview(int id);
        public Task PutInterview(int id, Interview interview);
        public Task<Interview> PostInterview(Interview interview);
        public Task DeleteInterview(int id);
    }
}
