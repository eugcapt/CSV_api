using System.Data.Entity.Core.Metadata.Edm;

public record UserDescriptionDto(string Name, string Surname, string Email, DateTime RegDate);
public record ProjectDescriptionDto(int id, string Description);
public record ProjectDto(int ProjectId, string Name, string? Description, DateTime CreationDate, DateTime? UpdateDate);
public record UserUpdateDto(int UserId, string Login, string Name, string Surname, string Email, DateTime RegDate, DateTime? UpdateDate);
public record UserUpdateProjectDto(int UserId, string Login, string Name, string Surname, string Email, DateTime RegDate, DateTime? UpdateDate, int ProjectId);
public record TaskDto(int TaskId, string Name, string Description, Int16 Status, DateTime CreationDate, DateTime? UpdateDate, int ProjectID);
public record CommentDto(int CommentId, string Text, DateTime CreationDate, DateTime? UpdateDate, int TaskId);
