﻿using ConferencePlanning.Data.Entities;
using ConferencePlanning.DTO.ConferenceDto;
using ConferencePlanning.DTO.QuestionnaireDTOs;
using Microsoft.EntityFrameworkCore;


namespace ConferencePlanning.Services.ConferenceServices;

public interface IConferenceService
{
    Task<ICollection<ConferenceDto>> GetAllConferences();

    Task<ConferenceDto> GetConference(Guid id);

    Task<Conference> AddNewConference(ConferenceCreateDto conferenceDto);

    Task<Conference> UpdateConference(ConferenceDto confDto);

    public Task<bool> AddUser(Guid id, string userId);
    public Task<string> GetPhotoName(Guid id);

    public Task<Conference> GetConferenceWithSections(Guid id);

    public Task<ICollection<ConferenceShortDto>> GetUserConferences(string id);

    public Task<ICollection<ConferenceShortDto>> GetModeratorConferences(string id);

    public Task<ICollection<ConferenceQuestionnaireDto>> GetConferenceQuestionnaire(Guid confId);

    public Task<ConferenceDto> DeleteConference(Guid confId);

    public Task<List<ApplicationUser>> GetUsers(Guid confId);
}