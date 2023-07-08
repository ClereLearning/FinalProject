using ISAT.Shared.Models;
namespace ISAT.Client.Services.IntervieweeService
{
    public interface IIntervieweeService
    {
        public List<Interviewee> Interviewees { get; set; }
        public Task<List<Interviewee>> GetInterviewees();
        public Task<Interviewee> GetInterviewee(int id);
        public Task PutInterviewee(int id, Interviewee interviewee);
        public Task<Interviewee> PostInterviewee(Interviewee interviewee);
        public Task DeleteInterviewee(int id);
    }
}
