namespace MoqExercise
{
    public interface IUserInfo
    {
        string UserName { get; set; }
        int Age { get; set; }

        string GetUserData();
    }
}
