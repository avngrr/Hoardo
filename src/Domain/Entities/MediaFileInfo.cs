using Domain.Contracts;

namespace Domain.Entities;
public class MediaFileInfo : EntityBase<int>
{
    public string RelativePath { get; set; }
    public string Path { get; set; }
    public long Size { get; set; }
    public DateTime DateAdded { get; set; }
    public string SceneName { get; set; }
    public string ReleaseGroup { get; set; }
    public string RootFolderPath { get; set; }
}
