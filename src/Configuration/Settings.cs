#region license

// Copyright (c) 2021, andreakarasho
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions are met:
// 1. Redistributions of source code must retain the above copyright
//    notice, this list of conditions and the following disclaimer.
// 2. Redistributions in binary form must reproduce the above copyright
//    notice, this list of conditions and the following disclaimer in the
//    documentation and/or other materials provided with the distribution.
// 3. All advertising materials mentioning features or use of this software
//    must display the following acknowledgement:
//    This product includes software developed by andreakarasho - https://github.com/andreakarasho
// 4. Neither the name of the copyright holder nor the
//    names of its contributors may be used to endorse or promote products
//    derived from this software without specific prior written permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS ''AS IS'' AND ANY
// EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
// DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER BE LIABLE FOR ANY
// DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
// (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
// LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
// ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
// (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
// SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

#endregion

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using Microsoft.Xna.Framework;
using System.Text.Json.Serialization;
using ClassicUO.Utility.Logging;
using Microsoft.Xna.Framework.Design;

namespace ClassicUO.Configuration
{
    internal sealed class Settings
    {
        public const string SETTINGS_FILENAME = "settings.json";
        public static Settings GlobalSettings = new Settings();
        public static string CustomSettingsFilepath = null;


        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string IP { get; set; } = "127.0.0.1";
        public ushort Port { get; set; } = 2593;
        public string UltimaOnlineDirectory { get; set; } = "";
        public string ProfilesPath { get; set; } = string.Empty;
        public string ClientVersion { get; set; } = string.Empty;
        public string LastCharacterName { get; set; } = string.Empty;
        public string Language { get; set; } = "";
        public ushort LastServerNum { get; set; } = 1;
        public string LastServerName { get; set; } = string.Empty;
        public int FPS { get; set; } = 60;
        public Point? WindowPosition { get; set; }
        public Point? WindowSize { get; set; }
        public bool IsWindowMaximized { get; set; } = true;
        public bool SaveAccount { get; set; }
        public bool AutoLogin { get; set; }
        public bool Reconnect { get; set; }
        public int ReconnectTime { get; set; } = 1;
        public bool LoginMusic { get; set; } = true;
        public int LoginMusicVolume { get; set; } = 70;
        public int ShardType { get; set; } // 0 = normal (no customization), 1 = old, 2 = outlands??
        public bool FixedTimeStep { get; set; } = true;
        public bool RunMouseInASeparateThread { get; set; } = true;
        public byte ForceDriver { get; set; }
        public bool UseVerdata { get; set; }
        public string MapsLayouts { get; set; }
        public byte Encryption { get; set; }
        public string[] Plugins { get; set; } = Array.Empty<string>();


        public static string GetSettingsFilepath()
        {
            if (CustomSettingsFilepath != null)
            {
                if (Path.IsPathRooted(CustomSettingsFilepath))
                {
                    return CustomSettingsFilepath;
                }

                return Path.Combine(CUOEnviroment.ExecutablePath, CustomSettingsFilepath);
            }

            return Path.Combine(CUOEnviroment.ExecutablePath, SETTINGS_FILENAME);
        }

        public static Settings LoadFile(string path)
        {
            Settings settings = new Settings();

            if (File.Exists(path))
            {
                using (JsonDocument doc = JsonDocument.Parse(File.ReadAllBytes(path)))
                {
                    JsonElement root = doc.RootElement;

                    if (root.TryGetProperty("username", out var elem))
                    {
                        settings.Username = elem.GetString();
                    }

                    if (root.TryGetProperty("password", out elem))
                    {
                        settings.Password = elem.GetString();
                    }

                    if (root.TryGetProperty("ip", out elem))
                    {
                        settings.IP = elem.GetString();
                    }

                    if (root.TryGetProperty("port", out elem))
                    {
                        settings.Port = elem.GetUInt16();
                    }

                    if (root.TryGetProperty("ultimaonlinedirectory", out elem))
                    {
                        settings.UltimaOnlineDirectory = elem.GetString();
                    }

                    if (root.TryGetProperty("profilespath", out elem))
                    {
                        settings.ProfilesPath = elem.GetString();
                    }

                    if (root.TryGetProperty("clientversion", out elem))
                    {
                        settings.ClientVersion = elem.GetString();
                    }

                    if (root.TryGetProperty("lastcharactername", out elem))
                    {
                        settings.LastCharacterName = elem.GetString();
                    }

                    if (root.TryGetProperty("lang", out elem))
                    {
                        settings.Language = elem.GetString();
                    }

                    if (root.TryGetProperty("lastservernum", out elem))
                    {
                        settings.LastServerNum = elem.GetUInt16();
                    }

                    if (root.TryGetProperty("last_server_name", out elem))
                    {
                        settings.LastServerName = elem.GetString();
                    }

                    if (root.TryGetProperty("fps", out elem))
                    {
                        settings.FPS = elem.GetInt32();
                    }

                    if (root.TryGetProperty("window_position", out elem))
                    {
                        settings.WindowPosition = new Point(elem.GetProperty("X").GetInt32(), elem.GetProperty("Y").GetInt32());
                    }

                    if (root.TryGetProperty("window_size", out elem))
                    {
                        settings.WindowSize = new Point(elem.GetProperty("X").GetInt32(), elem.GetProperty("Y").GetInt32());
                    }

                    if (root.TryGetProperty("is_win_maximized", out elem))
                    {
                        settings.IsWindowMaximized = elem.GetBoolean();
                    }

                    if (root.TryGetProperty("saveaccount", out elem))
                    {
                        settings.SaveAccount = elem.GetBoolean();
                    }

                    if (root.TryGetProperty("reconnect", out elem))
                    {
                        settings.Reconnect = elem.GetBoolean();
                    }

                    if (root.TryGetProperty("reconnect_time", out elem))
                    {
                        settings.ReconnectTime = elem.GetInt32();
                    }

                    if (root.TryGetProperty("login_music", out elem))
                    {
                        settings.LoginMusic = elem.GetBoolean();
                    }

                    if (root.TryGetProperty("login_music_volume", out elem))
                    {
                        settings.LoginMusicVolume = elem.GetInt32();
                    }

                    if (root.TryGetProperty("shard_type", out elem))
                    {
                        settings.ShardType = elem.GetInt32();
                    }

                    if (root.TryGetProperty("fixed_time_step", out elem))
                    {
                        settings.FixedTimeStep = elem.GetBoolean();
                    }

                    if (root.TryGetProperty("run_mouse_in_separate_thread", out elem))
                    {
                        settings.RunMouseInASeparateThread = elem.GetBoolean();
                    }

                    if (root.TryGetProperty("force_driver", out elem))
                    {
                        settings.ForceDriver = elem.GetByte();
                    }

                    if (root.TryGetProperty("use_verdata", out elem))
                    {
                        settings.UseVerdata = elem.GetBoolean();
                    }

                    if (root.TryGetProperty("maps_layouts", out elem))
                    {
                        settings.MapsLayouts = elem.GetString();
                    }

                    if (root.TryGetProperty("encryption", out elem))
                    {
                        settings.Encryption = elem.GetByte();
                    }

                    if (root.TryGetProperty("plugins", out elem))
                    {
                        settings.Plugins = new string[elem.GetArrayLength()];
                        int i = 0;
                        foreach (var e in elem.EnumerateArray())
                        {
                            settings.Plugins[i++] = e.GetString();
                        }
                    }
                }
            }
            else
            {
                Log.Warn($"settings not found in: '{path}'");
            }
            return settings;
        }


        public void Save()
        {
            string file = GetSettingsFilepath();

            using (FileStream fs = File.Create(file))
            {
                using (Utf8JsonWriter writer = new Utf8JsonWriter(fs, new JsonWriterOptions()
                {
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    Indented = true
                }))
                {
                    writer.WriteStartObject();

                    writer.WriteString("username", SaveAccount ? Username : string.Empty);
                    writer.WriteString("password", SaveAccount ? Password : string.Empty);
                    writer.WriteString("ip", IP);
                    writer.WriteNumber("port", Port);
                    writer.WriteString("ultimaonlinedirectory", UltimaOnlineDirectory);
                    writer.WriteString("profilespath", string.Empty);
                    writer.WriteString("clientversion", ClientVersion);
                    writer.WriteString("lastcharactername", LastCharacterName);
                    writer.WriteString("lang", Language);
                    writer.WriteNumber("lastservernum", LastServerNum);
                    writer.WriteString("last_server_name", LastServerName);
                    writer.WriteNumber("fps", FPS);

                    writer.WriteStartObject("window_position");
                    if (WindowPosition.HasValue)
                    {
                        writer.WriteNumber("X", WindowPosition.Value.X);
                        writer.WriteNumber("Y", WindowPosition.Value.Y);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }
                    writer.WriteEndObject();

                    writer.WriteStartObject("window_size");
                    if (WindowPosition.HasValue)
                    {
                        writer.WriteNumber("X", WindowSize.Value.X);
                        writer.WriteNumber("Y", WindowSize.Value.Y);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }
                    writer.WriteEndObject();

                    writer.WriteBoolean("is_win_maximized", IsWindowMaximized);
                    writer.WriteBoolean("saveaccount", SaveAccount);
                    writer.WriteBoolean("autologin", AutoLogin);
                    writer.WriteBoolean("reconnect", Reconnect);
                    writer.WriteNumber("reconnect_time", ReconnectTime);
                    writer.WriteBoolean("login_music", LoginMusic);
                    writer.WriteNumber("login_music_volume", LoginMusicVolume);
                    writer.WriteNumber("shard_type", ShardType);
                    writer.WriteBoolean("fixed_time_step", FixedTimeStep);
                    writer.WriteBoolean("run_mouse_in_separate_thread", RunMouseInASeparateThread);
                    writer.WriteNumber("force_driver", ForceDriver);
                    writer.WriteBoolean("use_verdata", UseVerdata);
                    writer.WriteString("maps_layouts", MapsLayouts);
                    writer.WriteNumber("encryption", Encryption);
                    writer.WriteStartArray("plugins");

                    if (Plugins == null)
                    {
                        writer.WriteNullValue();
                    }
                    else
                    {
                        foreach (string plugin in Plugins)
                        {
                            writer.WriteStringValue(plugin);
                        }
                    }

                    writer.WriteEndArray();

                    writer.WriteEndObject();
                }
            }
        }
    }
}