﻿using Domain.Contracts;

namespace Domain.Entities;
public abstract class MediaInfo : EntityBase
{
    public string ImdbId { get; set; }
    public string Title { get; set; }
    public string CleanTitle { get; set; }
    public string Overview { get; set; }
    public bool Monitored { get; set; }
    public int Year { get; set; }
    public List<string> Genres { get; set; }
    public DateTime Added { get; set; }
    public bool HasFile { get; set; }
}
