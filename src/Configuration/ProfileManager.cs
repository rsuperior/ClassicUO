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

using System.IO;
using System.Text.Json;
using ClassicUO.Game.Managers;
using ClassicUO.Utility;
using Microsoft.Xna.Framework;

namespace ClassicUO.Configuration
{
    internal static class ProfileManager
    {
        public static Profile CurrentProfile { get; private set; }
        public static string ProfilePath { get; private set; }

        public static void Load(string servername, string username, string charactername)
        {
            string rootpath;

            if (string.IsNullOrWhiteSpace(Settings.GlobalSettings.ProfilesPath))
            {
                rootpath = Path.Combine(CUOEnviroment.ExecutablePath, "Data", "Profiles");
            }
            else
            {
                rootpath = Settings.GlobalSettings.ProfilesPath;
            }

            string path = FileSystemHelper.CreateFolderIfNotExists(rootpath, username, servername, charactername);
            string fileToLoad = Path.Combine(path, "profile.json");

            ProfilePath = path;


            Profile profile = new Profile();
            profile.Username = username;
            profile.ServerName = servername;
            profile.CharacterName = charactername;


            if (File.Exists(fileToLoad))
            {
                using (JsonDocument doc = JsonDocument.Parse(File.ReadAllBytes(fileToLoad)))
                {
                    JsonElement root = doc.RootElement;
                    
                    if (root.TryGetProperty("enable_sound", out var elem))
                    {
                        profile.EnableSound = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("sound_volume", out elem))
                    {
                        profile.SoundVolume = elem.GetInt32();
                    }
                    if (root.TryGetProperty("enable_music", out elem))
                    {
                        profile.EnableMusic = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("music_volume", out elem))
                    {
                        profile.MusicVolume = elem.GetInt32();
                    }
                    if (root.TryGetProperty("enable_footsteps_sound", out elem))
                    {
                        profile.EnableFootstepsSound = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("enable_combat_music", out elem))
                    {
                        profile.EnableCombatMusic = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("reproduce_sounds_in_background", out elem))
                    {
                        profile.ReproduceSoundsInBackground = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("chat_font", out elem))
                    {
                        profile.ChatFont = elem.GetByte();
                    }
                    if (root.TryGetProperty("speech_delay", out elem))
                    {
                        profile.SpeechDelay = elem.GetInt32();
                    }
                    if (root.TryGetProperty("scale_speech_delay", out elem))
                    {
                        profile.ScaleSpeechDelay = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("save_journal_to_file", out elem))
                    {
                        profile.SaveJournalToFile = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("force_unicode_journal", out elem))
                    {
                        profile.ForceUnicodeJournal = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("speech_hue", out elem))
                    {
                        profile.SpeechHue = elem.GetUInt16();
                    }
                    if (root.TryGetProperty("whisper_hue", out elem))
                    {
                        profile.WhisperHue = elem.GetUInt16();
                    }
                    if (root.TryGetProperty("emote_hue", out elem))
                    {
                        profile.EmoteHue = elem.GetUInt16();
                    }
                    if (root.TryGetProperty("yell_hue", out elem))
                    {
                        profile.YellHue = elem.GetUInt16();
                    }
                    if (root.TryGetProperty("party_message_hue", out elem))
                    {
                        profile.PartyMessageHue = elem.GetUInt16();
                    }
                    if (root.TryGetProperty("guild_message_hue", out elem))
                    {
                        profile.GuildMessageHue = elem.GetUInt16();
                    }
                    if (root.TryGetProperty("ally_message_hue", out elem))
                    {
                        profile.AllyMessageHue = elem.GetUInt16();
                    }
                    if (root.TryGetProperty("chat_message_hue", out elem))
                    {
                        profile.ChatMessageHue = elem.GetUInt16();
                    }
                    if (root.TryGetProperty("innocent_hue", out elem))
                    {
                        profile.InnocentHue = elem.GetUInt16();
                    }
                    if (root.TryGetProperty("party_aura_hue", out elem))
                    {
                        profile.PartyAuraHue = elem.GetUInt16();
                    }
                    if (root.TryGetProperty("friend_hue", out elem))
                    {
                        profile.FriendHue = elem.GetUInt16();
                    }
                    if (root.TryGetProperty("criminal_hue", out elem))
                    {
                        profile.CriminalHue = elem.GetUInt16();
                    }
                    if (root.TryGetProperty("can_attack_hue", out elem))
                    {
                        profile.CanAttackHue = elem.GetUInt16();
                    }
                    if (root.TryGetProperty("enemy_hue", out elem))
                    {
                        profile.EnemyHue = elem.GetUInt16();
                    }
                    if (root.TryGetProperty("murderer_hue", out elem))
                    {
                        profile.MurdererHue = elem.GetUInt16();
                    }
                    if (root.TryGetProperty("benefic_hue", out elem))
                    {
                        profile.BeneficHue = elem.GetUInt16();
                    }
                    if (root.TryGetProperty("harmful_hue", out elem))
                    {
                        profile.HarmfulHue = elem.GetUInt16();
                    }
                    if (root.TryGetProperty("neutral_hue", out elem))
                    {
                        profile.NeutralHue = elem.GetUInt16();
                    }
                    if (root.TryGetProperty("enable_spell_hue", out elem))
                    {
                        profile.EnabledSpellHue = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("enable_spell_format", out elem))
                    {
                        profile.EnabledSpellFormat = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("spell_dispalay_format", out elem))
                    {
                        profile.SpellDisplayFormat = elem.GetString();
                    }
                    if (root.TryGetProperty("poison_hue", out elem))
                    {
                        profile.PoisonHue = elem.GetUInt16();
                    }
                    if (root.TryGetProperty("paralyzed_hue", out elem))
                    {
                        profile.ParalyzedHue = elem.GetUInt16();
                    }
                    if (root.TryGetProperty("invulnerable_hue", out elem))
                    {
                        profile.InvulnerableHue = elem.GetUInt16();
                    }
                    if (root.TryGetProperty("enabled_criminal_action_query", out elem))
                    {
                        profile.EnabledCriminalActionQuery = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("enabled_beneficial_criminal_action_query", out elem))
                    {
                        profile.EnabledBeneficialCriminalActionQuery = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("enable_stat_report", out elem))
                    {
                        profile.EnableStatReport = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("enable_skill_report", out elem))
                    {
                        profile.EnableSkillReport = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("use_old_status_gump", out elem))
                    {
                        profile.UseOldStatusGump = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("backpack_style", out elem))
                    {
                        profile.BackpackStyle = elem.GetInt32();
                    }
                    if (root.TryGetProperty("highlight_game_objects", out elem))
                    {
                        profile.HighlightGameObjects = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("highlight_mobiles_by_flags", out elem))
                    {
                        profile.HighlightMobilesByFlags = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("show_mobiles_h_p", out elem))
                    {
                        profile.ShowMobilesHP = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("mobile_h_p_type", out elem))
                    {
                        profile.MobileHPType = elem.GetInt32();
                    }
                    if (root.TryGetProperty("mobile_h_p_show_when", out elem))
                    {
                        profile.MobileHPShowWhen = elem.GetInt32();
                    }
                    if (root.TryGetProperty("draw_roofs", out elem))
                    {
                        profile.DrawRoofs = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("tree_to_stumps", out elem))
                    {
                        profile.TreeToStumps = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("enable_cave_border", out elem))
                    {
                        profile.EnableCaveBorder = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("hide_vegetation", out elem))
                    {
                        profile.HideVegetation = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("fields_type", out elem))
                    {
                        profile.FieldsType = elem.GetInt32();
                    }
                    if (root.TryGetProperty("no_color_objects_out_of_range", out elem))
                    {
                        profile.NoColorObjectsOutOfRange = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("use_circle_of_transparency", out elem))
                    {
                        profile.UseCircleOfTransparency = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("circle_of_transparency_radius", out elem))
                    {
                        profile.CircleOfTransparencyRadius = elem.GetInt32();
                    }
                    if (root.TryGetProperty("circle_of_transparency_type", out elem))
                    {
                        profile.CircleOfTransparencyType = elem.GetInt32();
                    }
                    if (root.TryGetProperty("vendor_gump_height", out elem))
                    {
                        profile.VendorGumpHeight = elem.GetInt32();
                    }
                    if (root.TryGetProperty("default_scale", out elem))
                    {
                        profile.DefaultScale = (float) elem.GetDouble();
                    }
                    if (root.TryGetProperty("enable_mousewheel_scale_zoom", out elem))
                    {
                        profile.EnableMousewheelScaleZoom = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("save_scale_after_close", out elem))
                    {
                        profile.SaveScaleAfterClose = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("restore_scale_after_unpress_ctrl", out elem))
                    {
                        profile.RestoreScaleAfterUnpressCtrl = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("bandage_self_old", out elem))
                    {
                        profile.BandageSelfOld = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("enable_death_screen", out elem))
                    {
                        profile.EnableDeathScreen = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("enable_black_white_effect", out elem))
                    {
                        profile.EnableBlackWhiteEffect = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("use_tooltip", out elem))
                    {
                        profile.UseTooltip = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("tooltip_text_hue", out elem))
                    {
                        profile.TooltipTextHue = elem.GetUInt16();
                    }
                    if (root.TryGetProperty("tooltip_delay_before_display", out elem))
                    {
                        profile.TooltipDelayBeforeDisplay = elem.GetInt32();
                    }
                    if (root.TryGetProperty("tooltip_display_zoom", out elem))
                    {
                        profile.TooltipDisplayZoom = elem.GetInt32();
                    }
                    if (root.TryGetProperty("tooltip_background_opacity", out elem))
                    {
                        profile.TooltipBackgroundOpacity = elem.GetInt32();
                    }
                    if (root.TryGetProperty("tooltip_font", out elem))
                    {
                        profile.TooltipFont = elem.GetByte();
                    }
                    if (root.TryGetProperty("enable_pathfind", out elem))
                    {
                        profile.EnablePathfind = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("use_shift_to_pathfind", out elem))
                    {
                        profile.UseShiftToPathfind = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("always_run", out elem))
                    {
                        profile.AlwaysRun = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("always_run_unless_hidden", out elem))
                    {
                        profile.AlwaysRunUnlessHidden = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("smooth_movements", out elem))
                    {
                        profile.SmoothMovements = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("hold_down_key_tab", out elem))
                    {
                        profile.HoldDownKeyTab = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("hold_shift_for_context", out elem))
                    {
                        profile.HoldShiftForContext = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("hold_shift_to_split_stack", out elem))
                    {
                        profile.HoldShiftToSplitStack = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("window_client_bounds", out elem))
                    {
                        profile.WindowClientBounds = new Point(elem.GetProperty("X").GetInt32(), elem.GetProperty("Y").GetInt32());
                    }
                    if (root.TryGetProperty("container_default_position", out elem))
                    {
                        profile.ContainerDefaultPosition = new Point(elem.GetProperty("X").GetInt32(), elem.GetProperty("Y").GetInt32());
                    }
                    if (root.TryGetProperty("game_window_position", out elem))
                    {
                        profile.GameWindowPosition = new Point(elem.GetProperty("X").GetInt32(), elem.GetProperty("Y").GetInt32());
                    }
                    if (root.TryGetProperty("game_window_lock", out elem))
                    {
                        profile.GameWindowLock = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("game_window_full_size", out elem))
                    {
                        profile.GameWindowFullSize = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("window_borderless", out elem))
                    {
                        profile.WindowBorderless = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("game_window_size", out elem))
                    {
                        profile.GameWindowSize = new Point(elem.GetProperty("X").GetInt32(), elem.GetProperty("Y").GetInt32());
                    }
                    if (root.TryGetProperty("topbar_gump_position", out elem))
                    {
                        profile.TopbarGumpPosition = new Point(elem.GetProperty("X").GetInt32(), elem.GetProperty("Y").GetInt32());
                    }
                    if (root.TryGetProperty("topbar_gump_is_minimized", out elem))
                    {
                        profile.TopbarGumpIsMinimized = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("topbar_gump_is_disabled", out elem))
                    {
                        profile.TopbarGumpIsDisabled = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("use_alternative_lights", out elem))
                    {
                        profile.UseAlternativeLights = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("use_custom_light_level", out elem))
                    {
                        profile.UseCustomLightLevel = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("light_level", out elem))
                    {
                        profile.LightLevel = elem.GetByte();
                    }
                    if (root.TryGetProperty("use_colored_lights", out elem))
                    {
                        profile.UseColoredLights = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("use_dark_nights", out elem))
                    {
                        profile.UseDarkNights = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("close_health_bar_type", out elem))
                    {
                        profile.CloseHealthBarType = elem.GetInt32();
                    }
                    if (root.TryGetProperty("activate_chat_after_enter", out elem))
                    {
                        profile.ActivateChatAfterEnter = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("activate_chat_additional_buttons", out elem))
                    {
                        profile.ActivateChatAdditionalButtons = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("activate_chat_shift_enter_support", out elem))
                    {
                        profile.ActivateChatShiftEnterSupport = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("use_objects_fading", out elem))
                    {
                        profile.UseObjectsFading = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("hold_down_key_alt_to_close_anchored", out elem))
                    {
                        profile.HoldDownKeyAltToCloseAnchored = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("close_all_anchored_gumps_in_group_with_right_click", out elem))
                    {
                        profile.CloseAllAnchoredGumpsInGroupWithRightClick = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("hold_alt_to_move_gumps", out elem))
                    {
                        profile.HoldAltToMoveGumps = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("hide_screenshot_stored_in_message", out elem))
                    {
                        profile.HideScreenshotStoredInMessage = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("cast_spells_by_one_click", out elem))
                    {
                        profile.CastSpellsByOneClick = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("buff_bar_time", out elem))
                    {
                        profile.BuffBarTime = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("auto_open_doors", out elem))
                    {
                        profile.AutoOpenDoors = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("smooth_doors", out elem))
                    {
                        profile.SmoothDoors = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("auto_open_corpses", out elem))
                    {
                        profile.AutoOpenCorpses = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("auto_open_corpse_range", out elem))
                    {
                        profile.AutoOpenCorpseRange = elem.GetInt32();
                    }
                    if (root.TryGetProperty("corpse_open_options", out elem))
                    {
                        profile.CorpseOpenOptions = elem.GetInt32();
                    }
                    if (root.TryGetProperty("skip_empty_corpse", out elem))
                    {
                        profile.SkipEmptyCorpse = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("disable_default_hotkeys", out elem))
                    {
                        profile.DisableDefaultHotkeys = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("disable_arrow_btn", out elem))
                    {
                        profile.DisableArrowBtn = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("disable_tab_btn", out elem))
                    {
                        profile.DisableTabBtn = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("disable_ctrl_q_w_btn", out elem))
                    {
                        profile.DisableCtrlQWBtn = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("disable_auto_move", out elem))
                    {
                        profile.DisableAutoMove = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("enable_drag_select", out elem))
                    {
                        profile.EnableDragSelect = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("drag_select_modifier_key", out elem))
                    {
                        profile.DragSelectModifierKey = elem.GetInt32();
                    }
                    if (root.TryGetProperty("override_container_location", out elem))
                    {
                        profile.OverrideContainerLocation = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("override_container_location_setting", out elem))
                    {
                        profile.OverrideContainerLocationSetting = elem.GetInt32();
                    }
                    if (root.TryGetProperty("override_container_location_position", out elem))
                    {
                        profile.OverrideContainerLocationPosition = new Point(elem.GetProperty("X").GetInt32(), elem.GetProperty("Y").GetInt32());
                    }
                    if (root.TryGetProperty("drag_select_humanoids_only", out elem))
                    {
                        profile.DragSelectHumanoidsOnly = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("name_overhead_type_allowed", out elem))
                    {
                        profile.NameOverheadTypeAllowed = (NameOverheadTypeAllowed) elem.GetInt32();
                    }
                    if (root.TryGetProperty("name_overhead_toggled", out elem))
                    {
                        profile.NameOverheadToggled = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("show_target_range_indicator", out elem))
                    {
                        profile.ShowTargetRangeIndicator = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("party_invite_gump", out elem))
                    {
                        profile.PartyInviteGump = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("custom_bars_toggled", out elem))
                    {
                        profile.CustomBarsToggled = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("c_b_black_b_g_toggled", out elem))
                    {
                        profile.CBBlackBGToggled = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("show_info_bar", out elem))
                    {
                        profile.ShowInfoBar = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("info_bar_highlight_type", out elem))
                    {
                        profile.InfoBarHighlightType = elem.GetInt32();
                    }
                    if (root.TryGetProperty("counter_bar_enabled", out elem))
                    {
                        profile.CounterBarEnabled = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("counter_bar_highlight_on_use", out elem))
                    {
                        profile.CounterBarHighlightOnUse = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("counter_bar_highlight_on_amount", out elem))
                    {
                        profile.CounterBarHighlightOnAmount = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("counter_bar_display_abbreviated_amount", out elem))
                    {
                        profile.CounterBarDisplayAbbreviatedAmount = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("counter_bar_abbreviated_amount", out elem))
                    {
                        profile.CounterBarAbbreviatedAmount = elem.GetInt32();
                    }
                    if (root.TryGetProperty("counter_bar_highlight_amount", out elem))
                    {
                        profile.CounterBarHighlightAmount = elem.GetInt32();
                    }
                    if (root.TryGetProperty("counter_bar_cell_size", out elem))
                    {
                        profile.CounterBarCellSize = elem.GetInt32();
                    }
                    if (root.TryGetProperty("counter_bar_rows", out elem))
                    {
                        profile.CounterBarRows = elem.GetInt32();
                    }
                    if (root.TryGetProperty("counter_bar_columns", out elem))
                    {
                        profile.CounterBarColumns = elem.GetInt32();
                    }
                    if (root.TryGetProperty("show_skills_changed_message", out elem))
                    {
                        profile.ShowSkillsChangedMessage = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("show_skills_changed_delta_value", out elem))
                    {
                        profile.ShowSkillsChangedDeltaValue = elem.GetInt32();
                    }
                    if (root.TryGetProperty("show_stats_changed_message", out elem))
                    {
                        profile.ShowStatsChangedMessage = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("filter_type", out elem))
                    {
                        profile.FilterType = elem.GetInt32();
                    }
                    if (root.TryGetProperty("shadows_enabled", out elem))
                    {
                        profile.ShadowsEnabled = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("shadows_statics", out elem))
                    {
                        profile.ShadowsStatics = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("terrain_shadows_level", out elem))
                    {
                        profile.TerrainShadowsLevel = elem.GetInt32();
                    }
                    if (root.TryGetProperty("aura_under_feet_type", out elem))
                    {
                        profile.AuraUnderFeetType = elem.GetInt32();
                    }
                    if (root.TryGetProperty("aura_on_mouse", out elem))
                    {
                        profile.AuraOnMouse = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("party_aura", out elem))
                    {
                        profile.PartyAura = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("use_x_b_r", out elem))
                    {
                        profile.UseXBR = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("hide_chat_gradient", out elem))
                    {
                        profile.HideChatGradient = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("standard_skills_gump", out elem))
                    {
                        profile.StandardSkillsGump = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("show_new_mobile_name_incoming", out elem))
                    {
                        profile.ShowNewMobileNameIncoming = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("show_new_corpse_name_incoming", out elem))
                    {
                        profile.ShowNewCorpseNameIncoming = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("grab_bag_serial", out elem))
                    {
                        profile.GrabBagSerial = elem.GetUInt32();
                    }
                    if (root.TryGetProperty("grid_loot_type", out elem))
                    {
                        profile.GridLootType = elem.GetInt32();
                    }
                    if (root.TryGetProperty("reduce_f_p_s_when_inactive", out elem))
                    {
                        profile.ReduceFPSWhenInactive = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("override_all_fonts", out elem))
                    {
                        profile.OverrideAllFonts = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("override_all_fonts_is_unicode", out elem))
                    {
                        profile.OverrideAllFontsIsUnicode = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("sallos_easy_grab", out elem))
                    {
                        profile.SallosEasyGrab = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("journal_dark_mode", out elem))
                    {
                        profile.JournalDarkMode = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("containers_scale", out elem))
                    {
                        profile.ContainersScale = elem.GetByte();
                    }
                    if (root.TryGetProperty("scale_items_inside_containers", out elem))
                    {
                        profile.ScaleItemsInsideContainers = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("double_click_to_loot_inside_containers", out elem))
                    {
                        profile.DoubleClickToLootInsideContainers = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("use_large_container_gumps", out elem))
                    {
                        profile.UseLargeContainerGumps = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("relative_drag_and_drop_items", out elem))
                    {
                        profile.RelativeDragAndDropItems = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("highlight_container_when_selected", out elem))
                    {
                        profile.HighlightContainerWhenSelected = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("show_house_content", out elem))
                    {
                        profile.ShowHouseContent = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("save_healthbars", out elem))
                    {
                        profile.SaveHealthbars = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("text_fading", out elem))
                    {
                        profile.TextFading = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("use_smooth_boat_movement", out elem))
                    {
                        profile.UseSmoothBoatMovement = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("ignore_stamina_check", out elem))
                    {
                        profile.IgnoreStaminaCheck = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("show_journal_client", out elem))
                    {
                        profile.ShowJournalClient = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("show_journal_objects", out elem))
                    {
                        profile.ShowJournalObjects = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("show_journal_system", out elem))
                    {
                        profile.ShowJournalSystem = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("show_journal_guild_ally", out elem))
                    {
                        profile.ShowJournalGuildAlly = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("world_map_width", out elem))
                    {
                        profile.WorldMapWidth = elem.GetInt32();
                    }
                    if (root.TryGetProperty("world_map_height", out elem))
                    {
                        profile.WorldMapHeight = elem.GetInt32();
                    }
                    if (root.TryGetProperty("world_map_font", out elem))
                    {
                        profile.WorldMapFont = elem.GetInt32();
                    }
                    if (root.TryGetProperty("world_map_flip_map", out elem))
                    {
                        profile.WorldMapFlipMap = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("world_map_top_most", out elem))
                    {
                        profile.WorldMapTopMost = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("world_map_free_view", out elem))
                    {
                        profile.WorldMapFreeView = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("world_map_show_party", out elem))
                    {
                        profile.WorldMapShowParty = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("world_map_zoom_index", out elem))
                    {
                        profile.WorldMapZoomIndex = elem.GetInt32();
                    }
                    if (root.TryGetProperty("world_map_show_coordinates", out elem))
                    {
                        profile.WorldMapShowCoordinates = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("world_map_show_mobiles", out elem))
                    {
                        profile.WorldMapShowMobiles = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("world_map_show_player_name", out elem))
                    {
                        profile.WorldMapShowPlayerName = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("world_map_show_player_bar", out elem))
                    {
                        profile.WorldMapShowPlayerBar = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("world_map_show_group_name", out elem))
                    {
                        profile.WorldMapShowGroupName = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("world_map_show_group_bar", out elem))
                    {
                        profile.WorldMapShowGroupBar = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("world_map_show_markers", out elem))
                    {
                        profile.WorldMapShowMarkers = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("world_map_show_markers_names", out elem))
                    {
                        profile.WorldMapShowMarkersNames = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("world_map_show_multis", out elem))
                    {
                        profile.WorldMapShowMultis = elem.GetBoolean();
                    }
                    if (root.TryGetProperty("world_map_hidden_marker_files", out elem))
                    {
                        profile.WorldMapHiddenMarkerFiles = elem.GetString();
                    }
                }
            }


            CurrentProfile = profile;
            ValidateFields(CurrentProfile);
        }


        private static void ValidateFields(Profile profile)
        {
            if (profile == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(profile.ServerName))
            {
                throw new InvalidDataException();
            }

            if (string.IsNullOrEmpty(profile.Username))
            {
                throw new InvalidDataException();
            }

            if (string.IsNullOrEmpty(profile.CharacterName))
            {
                throw new InvalidDataException();
            }

            if (profile.WindowClientBounds.X < 600)
            {
                profile.WindowClientBounds = new Point(600, profile.WindowClientBounds.Y);
            }

            if (profile.WindowClientBounds.Y < 480)
            {
                profile.WindowClientBounds = new Point(profile.WindowClientBounds.X, 480);
            }
        }

        public static void UnLoadProfile()
        {
            CurrentProfile = null;
        }
    }
}