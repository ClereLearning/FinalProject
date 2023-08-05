namespace ISAT.Client.Services.InterviewerService
{
    public class InterviewerService : IInterviewerService
    {
        public List<Interviewer> Interviewers { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Task<Interviewer> GetInterviewer(string email)
        {
            throw new NotImplementedException();
        }

        public Task<List<Interviewer>> GetInterviewers()
        {
            throw new NotImplementedException();
        }
    }
}
