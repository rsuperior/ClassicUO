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
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml;
using ClassicUO.Game;
using ClassicUO.Game.GameObjects;
using ClassicUO.Game.Managers;
using ClassicUO.Game.UI.Gumps;
using ClassicUO.Utility;
using ClassicUO.Utility.Logging;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Design;

namespace ClassicUO.Configuration
{
    internal sealed class Profile
    {
         public string Username { get; set; }
         public string ServerName { get; set; }
         public string CharacterName { get; set; }


        // sounds
        public bool EnableSound { get; set; } = true;
        public int SoundVolume { get; set; } = 100;
        public bool EnableMusic { get; set; } = true;
        public int MusicVolume { get; set; } = 100;
        public bool EnableFootstepsSound { get; set; } = true;
        public bool EnableCombatMusic { get; set; } = true;
        public bool ReproduceSoundsInBackground { get; set; }

        // fonts and speech
        public byte ChatFont { get; set; } = 1;
        public int SpeechDelay { get; set; } = 100;
        public bool ScaleSpeechDelay { get; set; } = true;
        public bool SaveJournalToFile { get; set; } = true;
        public bool ForceUnicodeJournal { get; set; }

        // hues
        public ushort SpeechHue { get; set; } = 0x02B2;
        public ushort WhisperHue { get; set; } = 0x0033;
        public ushort EmoteHue { get; set; } = 0x0021;
        public ushort YellHue { get; set; } = 0x0021;
        public ushort PartyMessageHue { get; set; } = 0x0044;
        public ushort GuildMessageHue { get; set; } = 0x0044;
        public ushort AllyMessageHue { get; set; } = 0x0057;
        public ushort ChatMessageHue { get; set; } = 0x0256;
        public ushort InnocentHue { get; set; } = 0x005A;
        public ushort PartyAuraHue { get; set; } = 0x0044;
        public ushort FriendHue { get; set; } = 0x0044;
        public ushort CriminalHue { get; set; } = 0x03B2;
        public ushort CanAttackHue { get; set; } = 0x03B2;
        public ushort EnemyHue { get; set; } = 0x0031;
        public ushort MurdererHue { get; set; } = 0x0023;
        public ushort BeneficHue { get; set; } = 0x0059;
        public ushort HarmfulHue { get; set; } = 0x0020;
        public ushort NeutralHue { get; set; } = 0x03B1;
        public bool EnabledSpellHue { get; set; }
        public bool EnabledSpellFormat { get; set; }
        public string SpellDisplayFormat { get; set; } = "{power} [{spell}]";
        public ushort PoisonHue { get; set; } = 0x0044;
        public ushort ParalyzedHue { get; set; } = 0x014C;
        public ushort InvulnerableHue { get; set; } = 0x0030;

        // visual
        public bool EnabledCriminalActionQuery { get; set; } = true;
        public bool EnabledBeneficialCriminalActionQuery { get; set; } = false;
        public bool EnableStatReport { get; set; } = true;
        public bool EnableSkillReport { get; set; } = true;
        public bool UseOldStatusGump { get; set; }
        public int BackpackStyle { get; set; }
        public bool HighlightGameObjects { get; set; }
        public bool HighlightMobilesByFlags { get; set; } = true;
        public bool ShowMobilesHP { get; set; }
        public int MobileHPType { get; set; }     // 0 = %, 1 = line, 2 = both
        public int MobileHPShowWhen { get; set; } // 0 = Always, 1 - <100%
        public bool DrawRoofs { get; set; } = true;
        public bool TreeToStumps { get; set; }
        public bool EnableCaveBorder { get; set; }
        public bool HideVegetation { get; set; }
        public int FieldsType { get; set; } // 0 = normal, 1 = static, 2 = tile
        public bool NoColorObjectsOutOfRange { get; set; }
        public bool UseCircleOfTransparency { get; set; }
        public int CircleOfTransparencyRadius { get; set; } = Constants.MAX_CIRCLE_OF_TRANSPARENCY_RADIUS / 2;
        public int CircleOfTransparencyType { get; set; } // 0 = normal, 1 = like original client
        public int VendorGumpHeight { get; set; } = 60;   //original vendor gump size
        public float DefaultScale { get; set; } = 1.0f;
        public bool EnableMousewheelScaleZoom { get; set; }
        public bool SaveScaleAfterClose { get; set; }
        public bool RestoreScaleAfterUnpressCtrl { get; set; }
        public bool BandageSelfOld { get; set; } = true;
        public bool EnableDeathScreen { get; set; } = true;
        public bool EnableBlackWhiteEffect { get; set; } = true;

        // tooltip
        public bool UseTooltip { get; set; } = true;
        public ushort TooltipTextHue { get; set; } = 0xFFFF;
        public int TooltipDelayBeforeDisplay { get; set; } = 250;
        public int TooltipDisplayZoom { get; set; } = 100;
        public int TooltipBackgroundOpacity { get; set; } = 70;
        public byte TooltipFont { get; set; } = 1;

        // movements
        public bool EnablePathfind { get; set; }
        public bool UseShiftToPathfind { get; set; }
        public bool AlwaysRun { get; set; }
        public bool AlwaysRunUnlessHidden { get; set; }
        public bool SmoothMovements { get; set; } = true;
        public bool HoldDownKeyTab { get; set; } = true;
        public bool HoldShiftForContext { get; set; } = false;
        public bool HoldShiftToSplitStack { get; set; } = false;

        // general
        public Point WindowClientBounds { get; set; } = new Point(600, 480);
        public Point ContainerDefaultPosition { get; set; } = new Point(24, 24);
        public Point GameWindowPosition { get; set; } = new Point(10, 10);
        public bool GameWindowLock { get; set; }
        public bool GameWindowFullSize { get; set; }
        public bool WindowBorderless { get; set; } = false;
        public Point GameWindowSize { get; set; } = new Point(600, 480);
        public Point TopbarGumpPosition { get; set; } = new Point(0, 0);
        public bool TopbarGumpIsMinimized { get; set; }
        public bool TopbarGumpIsDisabled { get; set; }
        public bool UseAlternativeLights { get; set; }
        public bool UseCustomLightLevel { get; set; }
        public byte LightLevel { get; set; }
        public bool UseColoredLights { get; set; } = true;
        public bool UseDarkNights { get; set; }
        public int CloseHealthBarType { get; set; } // 0 = none, 1 == not exists, 2 == is dead
        public bool ActivateChatAfterEnter { get; set; }
        public bool ActivateChatAdditionalButtons { get; set; } = true;
        public bool ActivateChatShiftEnterSupport { get; set; } = true;
        public bool UseObjectsFading { get; set; } = true;
        public bool HoldDownKeyAltToCloseAnchored { get; set; } = true;
        public bool CloseAllAnchoredGumpsInGroupWithRightClick { get; set; } = false;
        public bool HoldAltToMoveGumps { get; set; }
        public bool HideScreenshotStoredInMessage { get; set; }

        // Experimental
        public bool CastSpellsByOneClick { get; set; }
        public bool BuffBarTime { get; set; }
        public bool AutoOpenDoors { get; set; }
        public bool SmoothDoors { get; set; }
        public bool AutoOpenCorpses { get; set; }
        public int AutoOpenCorpseRange { get; set; } = 2;
        public int CorpseOpenOptions { get; set; } = 3;
        public bool SkipEmptyCorpse { get; set; }
        public bool DisableDefaultHotkeys { get; set; }
        public bool DisableArrowBtn { get; set; }
        public bool DisableTabBtn { get; set; }
        public bool DisableCtrlQWBtn { get; set; }
        public bool DisableAutoMove { get; set; }
        public bool EnableDragSelect { get; set; }
        public int DragSelectModifierKey { get; set; } // 0 = none, 1 = control, 2 = shift
        public bool OverrideContainerLocation { get; set; }
        public int OverrideContainerLocationSetting { get; set; } // 0 = container position, 1 = top right of screen, 2 = last dragged position, 3 = remember every container
        public Point OverrideContainerLocationPosition { get; set; } = new Point(200, 200);
        public bool DragSelectHumanoidsOnly { get; set; }
        public NameOverheadTypeAllowed NameOverheadTypeAllowed { get; set; } = NameOverheadTypeAllowed.All;
        public bool NameOverheadToggled { get; set; } = false;
        public bool ShowTargetRangeIndicator { get; set; }
        public bool PartyInviteGump { get; set; }
        public bool CustomBarsToggled { get; set; }
        public bool CBBlackBGToggled { get; set; }
        public bool ShowInfoBar { get; set; }
        public int InfoBarHighlightType { get; set; } // 0 = text colour changes, 1 = underline
        public bool CounterBarEnabled { get; set; }
        public bool CounterBarHighlightOnUse { get; set; }
        public bool CounterBarHighlightOnAmount { get; set; }
        public bool CounterBarDisplayAbbreviatedAmount { get; set; }
        public int CounterBarAbbreviatedAmount { get; set; } = 1000;
        public int CounterBarHighlightAmount { get; set; } = 5;
        public int CounterBarCellSize { get; set; } = 40;
        public int CounterBarRows { get; set; } = 1;
        public int CounterBarColumns { get; set; } = 1;
        public bool ShowSkillsChangedMessage { get; set; } = true;
        public int ShowSkillsChangedDeltaValue { get; set; } = 1;
        public bool ShowStatsChangedMessage { get; set; } = true;
        public int FilterType { get; set; } = 0;
        public bool ShadowsEnabled { get; set; } = true;
        public bool ShadowsStatics { get; set; } = true;
        public int TerrainShadowsLevel { get; set; } = 15;
        public int AuraUnderFeetType { get; set; } // 0 = NO, 1 = in warmode, 2 = ctrl+shift, 3 = always
        public bool AuraOnMouse { get; set; } = true;
        public bool PartyAura { get; set; }
        public bool UseXBR { get; set; } = true;
        public bool HideChatGradient { get; set; } = false;
        public bool StandardSkillsGump { get; set; } = true;
        public bool ShowNewMobileNameIncoming { get; set; } = true;
        public bool ShowNewCorpseNameIncoming { get; set; } = true;
        public uint GrabBagSerial { get; set; }
        public int GridLootType { get; set; } // 0 = none, 1 = only grid, 2 = both
        public bool ReduceFPSWhenInactive { get; set; } = true;
        public bool OverrideAllFonts { get; set; }
        public bool OverrideAllFontsIsUnicode { get; set; } = true;
        public bool SallosEasyGrab { get; set; }
        public bool JournalDarkMode { get; set; }
        public byte ContainersScale { get; set; } = 100;
        public bool ScaleItemsInsideContainers { get; set; }
        public bool DoubleClickToLootInsideContainers { get; set; }
        public bool UseLargeContainerGumps { get; set; } = false;
        public bool RelativeDragAndDropItems { get; set; }
        public bool HighlightContainerWhenSelected { get; set; }
        public bool ShowHouseContent { get; set; }
        public bool SaveHealthbars { get; set; }
        public bool TextFading { get; set; } = true;
        public bool UseSmoothBoatMovement { get; set; } = false;
        public bool IgnoreStaminaCheck { get; set; } = false;
        public bool ShowJournalClient { get; set; } = true;
        public bool ShowJournalObjects { get; set; } = true;
        public bool ShowJournalSystem { get; set; } = true;
        public bool ShowJournalGuildAlly { get; set; } = true;
        public int WorldMapWidth { get; set; } = 400;
        public int WorldMapHeight { get; set; } = 400;
        public int WorldMapFont { get; set; } = 3;
        public bool WorldMapFlipMap { get; set; } = true;
        public bool WorldMapTopMost { get; set; }
        public bool WorldMapFreeView { get; set; }
        public bool WorldMapShowParty { get; set; } = true;
        public int WorldMapZoomIndex { get; set; } = 4;
        public bool WorldMapShowCoordinates { get; set; } = true;
        public bool WorldMapShowMobiles { get; set; } = true;
        public bool WorldMapShowPlayerName { get; set; } = true;
        public bool WorldMapShowPlayerBar { get; set; } = true;
        public bool WorldMapShowGroupName { get; set; } = true;
        public bool WorldMapShowGroupBar { get; set; } = true;
        public bool WorldMapShowMarkers { get; set; } = true;
        public bool WorldMapShowMarkersNames { get; set; } = true;
        public bool WorldMapShowMultis { get; set; } = true;
        public string WorldMapHiddenMarkerFiles { get; set; } = string.Empty;






        public void Save(string path)
        {
            Log.Trace($"Saving path:\t\t{path}");

            string file = Path.Combine(path, "profile.json");

            using (FileStream fs = File.Create(file))
            {
                using (Utf8JsonWriter writer = new Utf8JsonWriter
                (
                    fs,
                    new JsonWriterOptions()
                    {
                        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                        Indented = true
                    }
                ))
                {
                    writer.WriteStartObject();

                    writer.WriteBoolean("enable_sound", EnableSound);
                    writer.WriteNumber("sound_volume", SoundVolume);
                    writer.WriteBoolean("enable_music", EnableMusic);
                    writer.WriteNumber("music_volume", MusicVolume);
                    writer.WriteBoolean("enable_footsteps_sound", EnableFootstepsSound);
                    writer.WriteBoolean("enable_combat_music", EnableCombatMusic);
                    writer.WriteBoolean("reproduce_sounds_in_background", ReproduceSoundsInBackground);
                    writer.WriteNumber("chat_font", ChatFont);
                    writer.WriteNumber("speech_delay", SpeechDelay);
                    writer.WriteBoolean("scale_speech_delay", ScaleSpeechDelay);
                    writer.WriteBoolean("save_journal_to_file", SaveJournalToFile);
                    writer.WriteBoolean("force_unicode_journal", ForceUnicodeJournal);
                    writer.WriteNumber("speech_hue", SpeechHue);
                    writer.WriteNumber("whisper_hue", WhisperHue);
                    writer.WriteNumber("emote_hue", EmoteHue);
                    writer.WriteNumber("yell_hue", YellHue);
                    writer.WriteNumber("party_message_hue", PartyMessageHue);
                    writer.WriteNumber("guild_message_hue", GuildMessageHue);
                    writer.WriteNumber("ally_message_hue", AllyMessageHue);
                    writer.WriteNumber("chat_message_hue", ChatMessageHue);
                    writer.WriteNumber("innocent_hue", InnocentHue);
                    writer.WriteNumber("party_aura_hue", PartyAuraHue);
                    writer.WriteNumber("friend_hue", FriendHue);
                    writer.WriteNumber("criminal_hue", CriminalHue);
                    writer.WriteNumber("can_attack_hue", CanAttackHue);
                    writer.WriteNumber("enemy_hue", EnemyHue);
                    writer.WriteNumber("murderer_hue", MurdererHue);
                    writer.WriteNumber("benefic_hue", BeneficHue);
                    writer.WriteNumber("harmful_hue", HarmfulHue);
                    writer.WriteNumber("neutral_hue", NeutralHue);
                    writer.WriteBoolean("enable_spell_hue", EnabledSpellHue);
                    writer.WriteBoolean("enable_spell_format", EnabledSpellFormat);
                    writer.WriteString("spell_dispalay_format", SpellDisplayFormat);
                    writer.WriteNumber("poison_hue", PoisonHue);
                    writer.WriteNumber("paralyzed_hue", ParalyzedHue);
                    writer.WriteNumber("invulnerable_hue", InvulnerableHue);
                    writer.WriteBoolean("enabled_criminal_action_query", EnabledCriminalActionQuery);
                    writer.WriteBoolean("enabled_beneficial_criminal_action_query", EnabledBeneficialCriminalActionQuery);
                    writer.WriteBoolean("enable_stat_report", EnableStatReport);
                    writer.WriteBoolean("enable_skill_report", EnableSkillReport);
                    writer.WriteBoolean("use_old_status_gump", UseOldStatusGump);
                    writer.WriteNumber("backpack_style", BackpackStyle);
                    writer.WriteBoolean("highlight_game_objects", HighlightGameObjects);
                    writer.WriteBoolean("highlight_mobiles_by_flags", HighlightMobilesByFlags);
                    writer.WriteBoolean("show_mobiles_h_p", ShowMobilesHP);
                    writer.WriteNumber("mobile_h_p_type", MobileHPType);
                    writer.WriteNumber("mobile_h_p_show_when", MobileHPShowWhen);
                    writer.WriteBoolean("draw_roofs", DrawRoofs);
                    writer.WriteBoolean("tree_to_stumps", TreeToStumps);
                    writer.WriteBoolean("enable_cave_border", EnableCaveBorder);
                    writer.WriteBoolean("hide_vegetation", HideVegetation);
                    writer.WriteNumber("fields_type", FieldsType);
                    writer.WriteBoolean("no_color_objects_out_of_range", NoColorObjectsOutOfRange);
                    writer.WriteBoolean("use_circle_of_transparency", UseCircleOfTransparency);
                    writer.WriteNumber("circle_of_transparency_radius", CircleOfTransparencyRadius);
                    writer.WriteNumber("circle_of_transparency_type", CircleOfTransparencyType);
                    writer.WriteNumber("vendor_gump_height", VendorGumpHeight);
                    writer.WriteNumber("default_scale", DefaultScale);
                    writer.WriteBoolean("enable_mousewheel_scale_zoom", EnableMousewheelScaleZoom);
                    writer.WriteBoolean("save_scale_after_close", SaveScaleAfterClose);
                    writer.WriteBoolean("restore_scale_after_unpress_ctrl", RestoreScaleAfterUnpressCtrl);
                    writer.WriteBoolean("bandage_self_old", BandageSelfOld);
                    writer.WriteBoolean("enable_death_screen", EnableDeathScreen);
                    writer.WriteBoolean("enable_black_white_effect", EnableBlackWhiteEffect);
                    writer.WriteBoolean("use_tooltip", UseTooltip);
                    writer.WriteNumber("tooltip_text_hue", TooltipTextHue);
                    writer.WriteNumber("tooltip_delay_before_display", TooltipDelayBeforeDisplay);
                    writer.WriteNumber("tooltip_display_zoom", TooltipDisplayZoom);
                    writer.WriteNumber("tooltip_background_opacity", TooltipBackgroundOpacity);
                    writer.WriteNumber("tooltip_font", TooltipFont);
                    writer.WriteBoolean("enable_pathfind", EnablePathfind);
                    writer.WriteBoolean("use_shift_to_pathfind", UseShiftToPathfind);
                    writer.WriteBoolean("always_run", AlwaysRun);
                    writer.WriteBoolean("always_run_unless_hidden", AlwaysRunUnlessHidden);
                    writer.WriteBoolean("smooth_movements", SmoothMovements);
                    writer.WriteBoolean("hold_down_key_tab", HoldDownKeyTab);
                    writer.WriteBoolean("hold_shift_for_context", HoldShiftForContext);
                    writer.WriteBoolean("hold_shift_to_split_stack", HoldShiftToSplitStack);
                    writer.WriteStartObject("window_client_bounds");
                    writer.WriteNumber("X", WindowClientBounds.X);
                    writer.WriteNumber("Y", WindowClientBounds.Y);
                    writer.WriteEndObject();
                    writer.WriteStartObject("container_default_position");
                    writer.WriteNumber("X", ContainerDefaultPosition.X);
                    writer.WriteNumber("Y", ContainerDefaultPosition.Y);
                    writer.WriteEndObject();
                    writer.WriteStartObject("game_window_position");
                    writer.WriteNumber("X", GameWindowPosition.X);
                    writer.WriteNumber("Y", GameWindowPosition.Y);
                    writer.WriteEndObject();
                    writer.WriteBoolean("game_window_lock", GameWindowLock);
                    writer.WriteBoolean("game_window_full_size", GameWindowFullSize);
                    writer.WriteBoolean("window_borderless", WindowBorderless);
                    writer.WriteStartObject("game_window_size");
                    writer.WriteNumber("X", GameWindowSize.X);
                    writer.WriteNumber("Y", GameWindowSize.Y);
                    writer.WriteEndObject();
                    writer.WriteStartObject("topbar_gump_position");
                    writer.WriteNumber("X", TopbarGumpPosition.X);
                    writer.WriteNumber("Y", TopbarGumpPosition.Y);
                    writer.WriteEndObject();
                    writer.WriteBoolean("topbar_gump_is_minimized", TopbarGumpIsMinimized);
                    writer.WriteBoolean("topbar_gump_is_disabled", TopbarGumpIsDisabled);
                    writer.WriteBoolean("use_alternative_lights", UseAlternativeLights);
                    writer.WriteBoolean("use_custom_light_level", UseCustomLightLevel);
                    writer.WriteNumber("light_level", LightLevel);
                    writer.WriteBoolean("use_colored_lights", UseColoredLights);
                    writer.WriteBoolean("use_dark_nights", UseDarkNights);
                    writer.WriteNumber("close_health_bar_type", CloseHealthBarType);
                    writer.WriteBoolean("activate_chat_after_enter", ActivateChatAfterEnter);
                    writer.WriteBoolean("activate_chat_additional_buttons", ActivateChatAdditionalButtons);
                    writer.WriteBoolean("activate_chat_shift_enter_support", ActivateChatShiftEnterSupport);
                    writer.WriteBoolean("use_objects_fading", UseObjectsFading);
                    writer.WriteBoolean("hold_down_key_alt_to_close_anchored", HoldDownKeyAltToCloseAnchored);
                    writer.WriteBoolean("close_all_anchored_gumps_in_group_with_right_click", CloseAllAnchoredGumpsInGroupWithRightClick);
                    writer.WriteBoolean("hold_alt_to_move_gumps", HoldAltToMoveGumps);
                    writer.WriteBoolean("hide_screenshot_stored_in_message", HideScreenshotStoredInMessage);
                    writer.WriteBoolean("cast_spells_by_one_click", CastSpellsByOneClick);
                    writer.WriteBoolean("buff_bar_time", BuffBarTime);
                    writer.WriteBoolean("auto_open_doors", AutoOpenDoors);
                    writer.WriteBoolean("smooth_doors", SmoothDoors);
                    writer.WriteBoolean("auto_open_corpses", AutoOpenCorpses);
                    writer.WriteNumber("auto_open_corpse_range", AutoOpenCorpseRange);
                    writer.WriteNumber("corpse_open_options", CorpseOpenOptions);
                    writer.WriteBoolean("skip_empty_corpse", SkipEmptyCorpse);
                    writer.WriteBoolean("disable_default_hotkeys", DisableDefaultHotkeys);
                    writer.WriteBoolean("disable_arrow_btn", DisableArrowBtn);
                    writer.WriteBoolean("disable_tab_btn", DisableTabBtn);
                    writer.WriteBoolean("disable_ctrl_q_w_btn", DisableCtrlQWBtn);
                    writer.WriteBoolean("disable_auto_move", DisableAutoMove);
                    writer.WriteBoolean("enable_drag_select", EnableDragSelect);
                    writer.WriteNumber("drag_select_modifier_key", DragSelectModifierKey);
                    writer.WriteBoolean("override_container_location", OverrideContainerLocation);
                    writer.WriteNumber("override_container_location_setting", OverrideContainerLocationSetting);
                    writer.WriteStartObject("override_container_location_position");
                    writer.WriteNumber("X", OverrideContainerLocationPosition.X);
                    writer.WriteNumber("Y", OverrideContainerLocationPosition.Y);
                    writer.WriteEndObject();
                    writer.WriteBoolean("drag_select_humanoids_only", DragSelectHumanoidsOnly);
                    writer.WriteNumber("name_overhead_type_allowed", (int)NameOverheadTypeAllowed);
                    writer.WriteBoolean("name_overhead_toggled", NameOverheadToggled);
                    writer.WriteBoolean("show_target_range_indicator", ShowTargetRangeIndicator);
                    writer.WriteBoolean("party_invite_gump", PartyInviteGump);
                    writer.WriteBoolean("custom_bars_toggled", CustomBarsToggled);
                    writer.WriteBoolean("c_b_black_b_g_toggled", CBBlackBGToggled);
                    writer.WriteBoolean("show_info_bar", ShowInfoBar);
                    writer.WriteNumber("info_bar_highlight_type", InfoBarHighlightType);
                    writer.WriteBoolean("counter_bar_enabled", CounterBarEnabled);
                    writer.WriteBoolean("counter_bar_highlight_on_use", CounterBarHighlightOnUse);
                    writer.WriteBoolean("counter_bar_highlight_on_amount", CounterBarHighlightOnAmount);
                    writer.WriteBoolean("counter_bar_display_abbreviated_amount", CounterBarDisplayAbbreviatedAmount);
                    writer.WriteNumber("counter_bar_abbreviated_amount", CounterBarAbbreviatedAmount);
                    writer.WriteNumber("counter_bar_highlight_amount", CounterBarHighlightAmount);
                    writer.WriteNumber("counter_bar_cell_size", CounterBarCellSize);
                    writer.WriteNumber("counter_bar_rows", CounterBarRows);
                    writer.WriteNumber("counter_bar_columns", CounterBarColumns);
                    writer.WriteBoolean("show_skills_changed_message", ShowSkillsChangedMessage);
                    writer.WriteNumber("show_skills_changed_delta_value", ShowSkillsChangedDeltaValue);
                    writer.WriteBoolean("show_stats_changed_message", ShowStatsChangedMessage);
                    writer.WriteNumber("filter_type", FilterType);
                    writer.WriteBoolean("shadows_enabled", ShadowsEnabled);
                    writer.WriteBoolean("shadows_statics", ShadowsStatics);
                    writer.WriteNumber("terrain_shadows_level", TerrainShadowsLevel);
                    writer.WriteNumber("aura_under_feet_type", AuraUnderFeetType);
                    writer.WriteBoolean("aura_on_mouse", AuraOnMouse);
                    writer.WriteBoolean("party_aura", PartyAura);
                    writer.WriteBoolean("use_x_b_r", UseXBR);
                    writer.WriteBoolean("hide_chat_gradient", HideChatGradient);
                    writer.WriteBoolean("standard_skills_gump", StandardSkillsGump);
                    writer.WriteBoolean("show_new_mobile_name_incoming", ShowNewMobileNameIncoming);
                    writer.WriteBoolean("show_new_corpse_name_incoming", ShowNewCorpseNameIncoming);
                    writer.WriteNumber("grab_bag_serial", GrabBagSerial);
                    writer.WriteNumber("grid_loot_type", GridLootType);
                    writer.WriteBoolean("reduce_f_p_s_when_inactive", ReduceFPSWhenInactive);
                    writer.WriteBoolean("override_all_fonts", OverrideAllFonts);
                    writer.WriteBoolean("override_all_fonts_is_unicode", OverrideAllFontsIsUnicode);
                    writer.WriteBoolean("sallos_easy_grab", SallosEasyGrab);
                    writer.WriteBoolean("journal_dark_mode", JournalDarkMode);
                    writer.WriteNumber("containers_scale", ContainersScale);
                    writer.WriteBoolean("scale_items_inside_containers", ScaleItemsInsideContainers);
                    writer.WriteBoolean("double_click_to_loot_inside_containers", DoubleClickToLootInsideContainers);
                    writer.WriteBoolean("use_large_container_gumps", UseLargeContainerGumps);
                    writer.WriteBoolean("relative_drag_and_drop_items", RelativeDragAndDropItems);
                    writer.WriteBoolean("highlight_container_when_selected", HighlightContainerWhenSelected);
                    writer.WriteBoolean("show_house_content", ShowHouseContent);
                    writer.WriteBoolean("save_healthbars", SaveHealthbars);
                    writer.WriteBoolean("text_fading", TextFading);
                    writer.WriteBoolean("use_smooth_boat_movement", UseSmoothBoatMovement);
                    writer.WriteBoolean("ignore_stamina_check", IgnoreStaminaCheck);
                    writer.WriteBoolean("show_journal_client", ShowJournalClient);
                    writer.WriteBoolean("show_journal_objects", ShowJournalObjects);
                    writer.WriteBoolean("show_journal_system", ShowJournalSystem);
                    writer.WriteBoolean("show_journal_guild_ally", ShowJournalGuildAlly);
                    writer.WriteNumber("world_map_width", WorldMapWidth);
                    writer.WriteNumber("world_map_height", WorldMapHeight);
                    writer.WriteNumber("world_map_font", WorldMapFont);
                    writer.WriteBoolean("world_map_flip_map", WorldMapFlipMap);
                    writer.WriteBoolean("world_map_top_most", WorldMapTopMost);
                    writer.WriteBoolean("world_map_free_view", WorldMapFreeView);
                    writer.WriteBoolean("world_map_show_party", WorldMapShowParty);
                    writer.WriteNumber("world_map_zoom_index", WorldMapZoomIndex);
                    writer.WriteBoolean("world_map_show_coordinates", WorldMapShowCoordinates);
                    writer.WriteBoolean("world_map_show_mobiles", WorldMapShowMobiles);
                    writer.WriteBoolean("world_map_show_player_name", WorldMapShowPlayerName);
                    writer.WriteBoolean("world_map_show_player_bar", WorldMapShowPlayerBar);
                    writer.WriteBoolean("world_map_show_group_name", WorldMapShowGroupName);
                    writer.WriteBoolean("world_map_show_group_bar", WorldMapShowGroupBar);
                    writer.WriteBoolean("world_map_show_markers", WorldMapShowMarkers);
                    writer.WriteBoolean("world_map_show_markers_names", WorldMapShowMarkersNames);
                    writer.WriteBoolean("world_map_show_multis", WorldMapShowMultis);
                    writer.WriteString("world_map_hidden_marker_files", WorldMapHiddenMarkerFiles);
                    writer.WriteEndObject();
                }
            }


            // Save opened gumps
            SaveGumps(path);

            Log.Trace("Saving done!");
        }

        public List<Gump> ReadGumps(string path)
        {
            List<Gump> gumps = new List<Gump>();

            // load skillsgroup
            SkillsGroupManager.Load();

            // load gumps
            string gumpsXmlPath = Path.Combine(path, "gumps.xml");

            if (File.Exists(gumpsXmlPath))
            {
                XmlDocument doc = new XmlDocument();

                try
                {
                    doc.Load(gumpsXmlPath);
                }
                catch (Exception ex)
                {
                    Log.Error(ex.ToString());

                    return gumps;
                }

                XmlElement root = doc["gumps"];

                if (root != null)
                {
                    foreach (XmlElement xml in root.ChildNodes /*.GetElementsByTagName("gump")*/)
                    {
                        if (xml.Name != "gump")
                        {
                            continue;
                        }

                        try
                        {
                            GumpType type = (GumpType)int.Parse(xml.GetAttribute(nameof(type)));
                            int x = int.Parse(xml.GetAttribute(nameof(x)));
                            int y = int.Parse(xml.GetAttribute(nameof(y)));
                            uint serial = uint.Parse(xml.GetAttribute(nameof(serial)));

                            Gump gump = null;

                            switch (type)
                            {
                                case GumpType.Buff:
                                    gump = new BuffGump();

                                    break;

                                case GumpType.Container:
                                    gump = new ContainerGump();

                                    break;

                                case GumpType.CounterBar:
                                    gump = new CounterBarGump();

                                    break;

                                case GumpType.HealthBar:
                                    if (CustomBarsToggled)
                                    {
                                        gump = new HealthBarGumpCustom();
                                    }
                                    else
                                    {
                                        gump = new HealthBarGump();
                                    }

                                    break;

                                case GumpType.InfoBar:
                                    gump = new InfoBarGump();

                                    break;

                                case GumpType.Journal:
                                    gump = new JournalGump();

                                    break;

                                case GumpType.MacroButton:
                                    gump = new MacroButtonGump();

                                    break;

                                case GumpType.MiniMap:
                                    gump = new MiniMapGump();

                                    break;

                                case GumpType.PaperDoll:
                                    gump = new PaperDollGump();

                                    break;

                                case GumpType.SkillMenu:
                                    if (StandardSkillsGump)
                                    {
                                        gump = new StandardSkillsGump();
                                    }
                                    else
                                    {
                                        gump = new SkillGumpAdvanced();
                                    }

                                    break;

                                case GumpType.SpellBook:
                                    gump = new SpellbookGump();

                                    break;

                                case GumpType.StatusGump:
                                    gump = StatusGumpBase.AddStatusGump(0, 0);

                                    break;

                                //case GumpType.TipNotice:
                                //    gump = new TipNoticeGump();
                                //    break;
                                case GumpType.AbilityButton:
                                    gump = new UseAbilityButtonGump();

                                    break;

                                case GumpType.SpellButton:
                                    gump = new UseSpellButtonGump();

                                    break;

                                case GumpType.SkillButton:
                                    gump = new SkillButtonGump();

                                    break;

                                case GumpType.RacialButton:
                                    gump = new RacialAbilityButton();

                                    break;

                                case GumpType.WorldMap:
                                    gump = new WorldMapGump();

                                    break;

                                case GumpType.Debug:
                                    gump = new DebugGump(100, 100);

                                    break;

                                case GumpType.NetStats:
                                    gump = new NetworkStatsGump(100, 100);

                                    break;
                            }

                            if (gump == null)
                            {
                                continue;
                            }

                            gump.LocalSerial = serial;
                            gump.Restore(xml);
                            gump.X = x;
                            gump.Y = y;

                            if (gump.LocalSerial != 0)
                            {
                                UIManager.SavePosition(gump.LocalSerial, new Point(x, y));
                            }

                            if (!gump.IsDisposed)
                            {
                                gumps.Add(gump);
                            }
                        }
                        catch (Exception ex)
                        {
                            Log.Error(ex.ToString());
                        }
                    }

                    foreach (XmlElement group in root.GetElementsByTagName("anchored_group_gump"))
                    {
                        int matrix_width = int.Parse(group.GetAttribute("matrix_w"));
                        int matrix_height = int.Parse(group.GetAttribute("matrix_h"));

                        AnchorManager.AnchorGroup ancoGroup = new AnchorManager.AnchorGroup();
                        ancoGroup.ResizeMatrix(matrix_width, matrix_height, 0, 0);

                        foreach (XmlElement xml in group.GetElementsByTagName("gump"))
                        {
                            try
                            {
                                GumpType type = (GumpType)int.Parse(xml.GetAttribute("type"));
                                int x = int.Parse(xml.GetAttribute("x"));
                                int y = int.Parse(xml.GetAttribute("y"));
                                uint serial = uint.Parse(xml.GetAttribute("serial"));

                                int matrix_x = int.Parse(xml.GetAttribute("matrix_x"));
                                int matrix_y = int.Parse(xml.GetAttribute("matrix_y"));

                                AnchorableGump gump = null;

                                switch (type)
                                {
                                    case GumpType.SpellButton:
                                        gump = new UseSpellButtonGump();

                                        break;

                                    case GumpType.SkillButton:
                                        gump = new SkillButtonGump();

                                        break;

                                    case GumpType.HealthBar:
                                        if (CustomBarsToggled)
                                        {
                                            gump = new HealthBarGumpCustom();
                                        }
                                        else
                                        {
                                            gump = new HealthBarGump();
                                        }

                                        break;

                                    case GumpType.AbilityButton:
                                        gump = new UseAbilityButtonGump();

                                        break;

                                    case GumpType.MacroButton:
                                        gump = new MacroButtonGump();

                                        break;
                                }

                                if (gump != null)
                                {
                                    gump.LocalSerial = serial;
                                    gump.Restore(xml);
                                    gump.X = x;
                                    gump.Y = y;

                                    if (!gump.IsDisposed)
                                    {
                                        if (UIManager.AnchorManager[gump] == null && ancoGroup.IsEmptyDirection(matrix_x, matrix_y))
                                        {
                                            gumps.Add(gump);
                                            UIManager.AnchorManager[gump] = ancoGroup;
                                            ancoGroup.AddControlToMatrix(matrix_x, matrix_y, gump);
                                        }
                                        else
                                        {
                                            gump.Dispose();
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Log.Error(ex.ToString());
                            }
                        }
                    }
                }
            }

            return gumps;
        }


        private void SaveGumps(string path)
        {
            string gumpsXmlPath = Path.Combine(path, "gumps.xml");

            using (XmlTextWriter xml = new XmlTextWriter(gumpsXmlPath, Encoding.UTF8)
            {
                Formatting = Formatting.Indented,
                IndentChar = '\t',
                Indentation = 1
            })
            {
                xml.WriteStartDocument(true);
                xml.WriteStartElement("gumps");

                UIManager.AnchorManager.Save(xml);

                LinkedList<Gump> gumps = new LinkedList<Gump>();

                foreach (Gump gump in UIManager.Gumps)
                {
                    if (!gump.IsDisposed && gump.CanBeSaved && !(gump is AnchorableGump anchored && UIManager.AnchorManager[anchored] != null))
                    {
                        gumps.AddLast(gump);
                    }
                }


                LinkedListNode<Gump> first = gumps.First;

                while (first != null)
                {
                    Gump gump = first.Value;

                    if (gump.LocalSerial != 0)
                    {
                        Item item = World.Items.Get(gump.LocalSerial);

                        if (item != null && !item.IsDestroyed && item.Opened)
                        {
                            while (SerialHelper.IsItem(item.Container))
                            {
                                item = World.Items.Get(item.Container);
                            }

                            SaveItemsGumpRecursive(item, xml, gumps);

                            if (first.List != null)
                            {
                                gumps.Remove(first);
                            }

                            first = gumps.First;

                            continue;
                        }
                    }

                    xml.WriteStartElement("gump");
                    gump.Save(xml);
                    xml.WriteEndElement();

                    if (first.List != null)
                    {
                        gumps.Remove(first);
                    }

                    first = gumps.First;
                }

                xml.WriteEndElement();
                xml.WriteEndDocument();
            }


            SkillsGroupManager.Save();
        }

        private static void SaveItemsGumpRecursive(Item parent, XmlTextWriter xml, LinkedList<Gump> list)
        {
            if (parent != null && !parent.IsDestroyed && parent.Opened)
            {
                SaveItemsGump(parent, xml, list);

                Item first = (Item) parent.Items;

                while (first != null)
                {
                    Item next = (Item) first.Next;

                    SaveItemsGumpRecursive(first, xml, list);

                    first = next;
                }
            }
        }

        private static void SaveItemsGump(Item item, XmlTextWriter xml, LinkedList<Gump> list)
        {
            if (item != null && !item.IsDestroyed && item.Opened)
            {
                LinkedListNode<Gump> first = list.First;

                while (first != null)
                {
                    LinkedListNode<Gump> next = first.Next;

                    if (first.Value.LocalSerial == item.Serial && !first.Value.IsDisposed)
                    {
                        xml.WriteStartElement("gump");
                        first.Value.Save(xml);
                        xml.WriteEndElement();

                        list.Remove(first);

                        break;
                    }

                    first = next;
                }
            }
        }


    }
}