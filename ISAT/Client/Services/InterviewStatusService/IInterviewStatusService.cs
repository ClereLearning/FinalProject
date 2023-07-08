namespace ISAT.Client.Services.InterviewStatusService
{
    public interface IInterviewStatusService
    {
        public List<InterviewStatus> InterviewsStatus { get; set; }
        public Task<List<InterviewStatus>> GetInterviewsStatus();
        public Task<InterviewStatus> GetInterviewStatus(int id);

    }
}
