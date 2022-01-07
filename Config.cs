using System;
using Exiled.API.Interfaces;

namespace HitMarker
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
    }
}