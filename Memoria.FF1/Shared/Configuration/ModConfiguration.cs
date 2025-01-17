﻿using System;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using Memoria.FFPR.Core;

namespace Memoria.FFPR.Configuration
{
    public sealed class ModConfiguration
    {
        public SpeedConfiguration Speed { get; }
        public EncountersConfiguration Encounters { get; }
        public AssetsConfiguration Assets { get; }

        public ModConfiguration()
        {
            using (var log = Logger.CreateLogSource("Memoria Config"))
            {
                try
                {
                    log.LogInfo($"Initializing {nameof(ModConfiguration)}");

                    ConfigFile file = new ConfigFile(GetConfigurationPath(), true, ownerMetadata: null);
                    Speed = new SpeedConfiguration(file);
                    Encounters = new EncountersConfiguration(file);
                    Assets = new AssetsConfiguration(file);

                    log.LogInfo($"{nameof(ModConfiguration)} initialized successfully.");
                }
                catch (Exception ex)
                {
                    log.LogError($"Failed to initialize {nameof(ModConfiguration)}: {ex}");
                    throw;
                }
            }
        }
        
        private static String GetConfigurationPath()
        {
            return Utility.CombinePaths(Paths.ConfigPath, ModConstants.Id + ".cfg");
        }
    }
}