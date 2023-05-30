﻿using ConferencePlanning.Data.Entities;
using ConferencePlanning.DTO;

namespace ConferencePlanning.Services.PhotosServices;

public interface IPhotosService
{
    public Task<int> AddNewConferencePhoto(Guid conferenceId, string photoName);

    public Task<int> AddNewUserPhoto(string id, string photoName);

    public Task<string> GetPhotoName(Guid id);
    public Task<string> GetUserPhotoName(string userId);

    public Task<string> DeleteUserPhoto(string userId);
}