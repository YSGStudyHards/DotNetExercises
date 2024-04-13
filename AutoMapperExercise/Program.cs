using AutoMapper;

namespace AutoMapperExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var configuration = new MapperConfiguration(cfg => {
                cfg.AddProfile<MappingProfile>();
                //或者下面这种方式
                //cfg.CreateMap<PersonInfo, PersonInfoDto>();
            });
            var mapper = configuration.CreateMapper();

            var personInfo = new PersonInfo
            {
                FirstName = "大东",
                LastName = "陈",
                Age = 18,
                Nationality = "中国"
            };
            var personInfoDto = mapper.Map<PersonInfoDto>(personInfo);
        }
    }
}
