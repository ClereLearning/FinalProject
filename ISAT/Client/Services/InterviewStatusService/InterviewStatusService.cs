namespace ISAT.Client.Services.InterviewStatusService
{
    public class InterviewStatusService : IInterviewStatusService
    {
        public List<InterviewStatus> InterviewsStatus { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Task<List<InterviewStatus>> GetInterviewsStatus()
        {
            throw new NotImplementedException();
        }

        public Task<InterviewStatus> GetInterviewStatus(int id)
        {
            throw new NotImplementedException();
        }
    }
}
