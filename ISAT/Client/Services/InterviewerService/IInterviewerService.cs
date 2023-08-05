namespace ISAT.Client.Services.InterviewerService
{
    public interface IInterviewerService
    {
        public List<Interviewer> Interviewers { get; set; }
        public Task<List<Interviewer>> GetInterviewers();
        public Task<Interviewer> GetInterviewer(string email);
    }
}
