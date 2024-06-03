using bobsbodymetrics.Dtos;
using bobsbodymetrics.Interfaces;
using bobsbodymetrics.Models;
using Microsoft.AspNetCore.Identity;

namespace bobsbodymetrics.Service;

public class ProfileService(IProfileRepository profileRepository, UserManager<AppUser> userManager)
{
    private readonly IProfileRepository _profileRepository = profileRepository;
    private readonly UserManager<AppUser> _userManager = userManager;

    public PublicProfileDto GetPublicProfile(string username)
    {
        var profile = _profileRepository.GetUserProfileByUsername(username);
        if (profile != null)
        {
            return new PublicProfileDto
            {
                UserId = profile.UserId,
                Name = profile.Name,
                Age = profile.Age,
                ProfileImg = profile.ProfileImg,
                BgImg = profile.BgImg,
                ProfileColor = profile.ProfileColor,
                Bio = profile.Bio,
                Gender = profile.Gender
            };
        }
        return null;
    }

    public PrivateProfileDto GetPrivateProfile(string userId)
    {
        var profile = _profileRepository.GetUserProfile(userId);
        if (profile != null)
        {
            return new PrivateProfileDto
            {
                UserId = profile.UserId,
                Name = profile.Name,
                Age = profile.Age,
                ProfileImg = profile.ProfileImg,
                BgImg = profile.BgImg,
                ProfileColor = profile.ProfileColor,
                Bio = profile.Bio,
                Gender = profile.Gender,

                Weight = profile.Weight,
                Height = profile.Height,
                
                IsPublic = profile.IsPublic
            };
        }
        return null;
    }
    public IEnumerable<PublicProfileShortDto> GetAllUserProfilesShortWithUsername()
    {
        return _profileRepository.GetAllUserProfilesShortWithUsername();
    }

    public IEnumerable<PublicProfileShortWithFSDto> GetAllUserProfilesShortWithFriendStatus(string userId)
    {
        return _profileRepository.GetAllUserProfilesShortWithFriendStatus(userId);
    }

    public IEnumerable<PublicProfileDto> GetAllProfiles()
    {
        return _profileRepository.GetAll().Select(profile => new PublicProfileDto
            {
                UserId = profile.UserId,
                Name = profile.Name,
                Age = profile.Age,
                ProfileImg = profile.ProfileImg,
                ProfileColor = profile.ProfileColor,
                Bio = profile.Bio,
                Gender = profile.Gender
            });
    }

    public PrivateProfileDto GetProfileById(int id)
    {
        var profile = _profileRepository.GetById(id);
        if (profile != null)
        {
            return new PrivateProfileDto
            {
                UserId = profile.UserId,
                Name = profile.Name,
                Age = profile.Age,
                ProfileImg = profile.ProfileImg,
                ProfileColor = profile.ProfileColor,
                Bio = profile.Bio,
                Gender = profile.Gender,

                Weight = profile.Weight,
                Height = profile.Height,
                
                IsPublic = profile.IsPublic
            };
        }
        return null;
    }

    public void CreateProfile(Profile profile)
    {
        _profileRepository.Insert(profile);
        _profileRepository.Save();
    }

    public void UpdateProfile(Profile profile)
    {
        _profileRepository.Update(profile);
        _profileRepository.Save();
    }

    public void DeleteProfile(int id)
    {
        _profileRepository.Delete(id);
        _profileRepository.Save();
    }
}

