using ISAT.Shared.Models;
namespace ISAT.Client.Services.IntervieweeService
{
    public interface IIntervieweeService
    {
        public List<Interviewee> Interviewees { get; set; }
        public Task<List<Interviewee>> GetInterviewees();
        public Task<Interviewee> GetInterviewee(Guid id);
        public Task PutInterviewee(Guid id, Interviewee interviewee);
        public Task<Interviewee> PostInterviewee(Interviewee interviewee);
        public Task DeleteInterviewee(Guid id);
        public Task<List<SexualOrientation>> GetSexualOrientations();
        public Task<List<Gender>> GetGenders();
        public Task<List<Interviewee>> GetIntervieweeByEmailOrPhoneNumber(string email, string PhoneNumber);
        
    }
}
