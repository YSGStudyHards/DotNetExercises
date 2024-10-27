namespace MoqExercise
{
    public interface IVerifyService
    {
        void Process(int value);
    }

    public class VerifyServiceClient
    {
        private readonly IVerifyService _service;

        public VerifyServiceClient(IVerifyService service)
        {
            _service = service;
        }

        public void Execute(int[] values)
        {
            foreach (var value in values)
            {
                _service.Process(value);
            }
        }
    }
}
