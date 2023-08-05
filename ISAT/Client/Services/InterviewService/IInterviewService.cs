using ISAT.Shared.Models;

namespace ISAT.Client.Services.InterviewService
{
    public interface IInterviewService
    {
        //public List<Interviewee> Interviewees { get; set; }
        public Task<List<Interviewee>> GetInterviewees();
        public List<Interview> Interviews { get; set; }
        public Task<List<Interview>> GetInterviews();
        public Task<Interview> GetInterview(Guid id);
        public Task PutInterview(Guid id, Interview interview);
        public Task<Interview> PostInterview(Interview interview);
        public Task DeleteInterview(Guid id);
        public Task UpdateStatus(Guid id, int statusId);
    }
}
