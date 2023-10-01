using ForouzanTask.Application.DTOs.Project.Outer;
using ForouzanTask.Application.Extensions;
using ForouzanTask.Application.Generators;
using ForouzanTask.Application.Services.Interfaces;
using ForouzanTask.Application.Statics;
using ForouzanTask.DataLayer.Context;
using ForouzanTask.DataLayer.Entities.Projects;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Reflection.Metadata;

namespace ForouzanTask.Application.Services.Implementations
{
    public class OuterUserProjectService : IOuterUserProjectService
    {
        #region Ctor

        private ForouzanTaskContext _context;
        public OuterUserProjectService(ForouzanTaskContext context)
        {
            _context = context;
        }
        #endregion

        public async Task<Guid> CreateProject(CreateProjectDto createProject)
        {
            TbProject project = new TbProject
            {
                Id = Guid.NewGuid(),
                ProjectTypeId = createProject.ProjectTypeId,
                Title = createProject.Title,
                TrackingCode = NameGenerator.GenrateTrackingCode(),
                IsApproved = false,
                CreateUserId = Guid.Empty,
                LastModifiedUserIp = GetIpAddress.GetIp(),
                LastModifiedUserMac = GetMacAddress.GetClientMAC(GetIpAddress.GetIp())
            };
            await _context.TbProjects.AddAsync(project);
          
            TbProjectRequest request = new TbProjectRequest
            {
                Id = Guid.NewGuid(),
                ProjectId = project.Id,
                RequesterName = createProject.RequesterName,
                RequesterMobile = createProject.RequesterMobile,
                Description = createProject.Description,
                CreateUserId = Guid.Empty,
                LastModifiedUserIp = GetIpAddress.GetIp(),
                LastModifiedUserMac = GetMacAddress.GetClientMAC(GetIpAddress.GetIp())
            }; 
            await _context.TbProjectRequests.AddAsync(request);
            
            if (createProject.DocumentFile!=null)
            {

                TbProjectDocument document = new TbProjectDocument
                {
                    Id = Guid.NewGuid(),
                    ProjectId = project.Id,
                    DocumentName = NameGenerator.GenerateUniqCode()+ Path.GetExtension(createProject.DocumentFile.FileName),
                    DocumentDescription = createProject.DocumentDescription,
                    CreateUserId = Guid.Empty,
                    LastModifiedUserIp = GetIpAddress.GetIp(),
                    LastModifiedUserMac = GetMacAddress.GetClientMAC(GetIpAddress.GetIp())
                };
                var validFormats = new List<string>()
                {
                ".png",
                ".jpg",
                ".jpeg",
                ".pdf",
                ".rar",
                ".zip"
                };

                var result = createProject.DocumentFile.UploadFile(document.DocumentName, PathTools.ProjectDocumentServerPath, validFormats);
                if (!result)
                {
                    return Guid.Empty;
                }
                await _context.TbProjectDocuments.AddAsync(document);
            }

   
           
            await _context.SaveChangesAsync();
            return project.Id;
        }

        public async Task<List<OuterProjectTypeDto>> GetAllTypesForCreate()
        {
            var projectTypes = await _context.TbProjectTypes.ToListAsync();
            List<OuterProjectTypeDto> outerList = new List<OuterProjectTypeDto>();
            foreach (var type in projectTypes)
            {
                OuterProjectTypeDto projectTypeDto = new OuterProjectTypeDto();
                projectTypeDto.Id = type.Id;
                projectTypeDto.Name = type.Name;
                outerList.Add(projectTypeDto);
            }
            return outerList;
        }
    }
}
