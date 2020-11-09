using AutoMapper;
using owasp_topten_api.Entities;

namespace owasp_topten_api.Model
{
    public class AccountProfile: Profile
    {
        public AccountProfile() {
            CreateMap<Account, AccountInfo>()
                .ForMember(m=> m.Owner, opt => opt.MapFrom(d=> d.User.FirstName + " " + d.User.LastName));
        }       
    }

    public class UserProfile: Profile {

        public UserProfile() {
            CreateMap<NewUser, User>();
        }
    }
}