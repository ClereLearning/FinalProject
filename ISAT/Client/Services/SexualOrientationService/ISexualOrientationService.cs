namespace ISAT.Client.Services.SexualOrientationService
{
    public interface ISexualOrientationService
    {
        public List<SexualOrientation> SexualOrientations { get; set; }
        public Task<List<SexualOrientation>> GetSexualOrientations();
        public Task<SexualOrientation> GetSexualOrientation(int id);
        public Task PutSexualOrientation(int id, SexualOrientation sexualOrientation);
        public Task<SexualOrientation> PostSexualOrientation(SexualOrientation sexualOrientation);
        public Task DeleteSexualOrientation(int id);
    }
}
