using Domain.Contracts;

namespace Domain.Entities;
public class MediaFileInfo : EntityBase
{
    public string RelativePath { get; set; }
    public string Path { get; set; }
    public long Size { get; set; }
    public DateTime DateAdded { get; set; }
    public string SceneName { get; set; }
    public string ReleaseGroup { get; set; }
    public int RootFolderId { get; set; }
    public RootFolder RootFolder { get; set; }
}
