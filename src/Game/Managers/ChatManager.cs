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

using System.Collections.Generic;
using ClassicUO.Localization;

namespace ClassicUO.Game.Managers
{
    internal static class ChatManager
    {
        public static readonly Dictionary<string, ChatChannel> Channels = new Dictionary<string, ChatChannel>();
        public static ChatStatus ChatIsEnabled;
        public static string CurrentChannelName = string.Empty;

        private static readonly string[] _messages =
        {
            LocalizationManager.Get(LocalizationProperties.YouAreAlreadyIgnoringMaximum),
            LocalizationManager.Get(LocalizationProperties.YouAreAlreadyIgnoring1),
            LocalizationManager.Get(LocalizationProperties.YouAreNowIgnoring1),
            LocalizationManager.Get(LocalizationProperties.YouAreNoLongerIgnoring1),
            LocalizationManager.Get(LocalizationProperties.YouAreNotIgnoring1),
            LocalizationManager.Get(LocalizationProperties.YouAreNoLongerIgnoringAnyone),
            LocalizationManager.Get(LocalizationProperties.ThatIsNotAValidConferenceName),
            LocalizationManager.Get(LocalizationProperties.ThereIsAlreadyAConference),
            LocalizationManager.Get(LocalizationProperties.YouMustHaveOperatorStatus),
            LocalizationManager.Get(LocalizationProperties.Conference1RenamedTo2),
            LocalizationManager.Get(LocalizationProperties.YouMustBeInAConference),
            LocalizationManager.Get(LocalizationProperties.ThereIsNoPlayerNamed1),
            LocalizationManager.Get(LocalizationProperties.ThereIsNoConferenceNamed1),
            LocalizationManager.Get(LocalizationProperties.ThatIsNotTheCorrectPassword),
            LocalizationManager.Get(LocalizationProperties.HasChosenToIgnoreYou),
            LocalizationManager.Get(LocalizationProperties.NotGivenYouSpeakingPrivileges),
            LocalizationManager.Get(LocalizationProperties.YouCanNowReceivePM),
            LocalizationManager.Get(LocalizationProperties.YouWillNoLongerReceivePM),
            LocalizationManager.Get(LocalizationProperties.YouAreShowingYourCharName),
            LocalizationManager.Get(LocalizationProperties.YouAreNotShowingYourCharName),
            LocalizationManager.Get(LocalizationProperties.IsRemainingAnonymous),
            LocalizationManager.Get(LocalizationProperties.HasChosenToNotReceivePM),
            LocalizationManager.Get(LocalizationProperties.IsKnownInTheLandsOfBritanniaAs2),
            LocalizationManager.Get(LocalizationProperties.HasBeenKickedOutOfTheConference),
            LocalizationManager.Get(LocalizationProperties.AConferenceModeratorKickedYou),
            LocalizationManager.Get(LocalizationProperties.YouAreAlreadyInTheConference1),
            LocalizationManager.Get(LocalizationProperties.IsNoLongerAConferenceModerator),
            LocalizationManager.Get(LocalizationProperties.IsNowAConferenceModerator),
            LocalizationManager.Get(LocalizationProperties.HasRemovedYouFromModerators),
            LocalizationManager.Get(LocalizationProperties.HasMadeYouAConferenceModerator),
            LocalizationManager.Get(LocalizationProperties.NoLongerHasSpeakingPrivileges),
            LocalizationManager.Get(LocalizationProperties.NowHasSpeakingPrivileges),
            LocalizationManager.Get(LocalizationProperties.RemovedYourSpeakingPrivileges),
            LocalizationManager.Get(LocalizationProperties.GrantedYouSpeakingPrivileges),
            LocalizationManager.Get(LocalizationProperties.EveryoneWillHaveSpeakingPrivs),
            LocalizationManager.Get(LocalizationProperties.ModeratorsWillHaveSpeakingPrivs),
            LocalizationManager.Get(LocalizationProperties.PasswordToTheConferenceChanged),
            LocalizationManager.Get(LocalizationProperties.TheConferenceNamed1IsFull),
            LocalizationManager.Get(LocalizationProperties.YouAreBanning1FromThisConference),
            LocalizationManager.Get(LocalizationProperties.BannedYouFromTheConference),
            LocalizationManager.Get(LocalizationProperties.YouHaveBeenBanned),
        };


        public static string GetMessage(int index)
        {
            return index < _messages.Length ? _messages[index] : string.Empty;
        }

        public static void AddChannel(string text, bool hasPassword)
        {
            if (!Channels.TryGetValue(text, out ChatChannel channel))
            {
                channel = new ChatChannel(text, hasPassword);
                Channels[text] = channel;
            }
        }

        public static void RemoveChannel(string name)
        {
            if (Channels.ContainsKey(name))
            {
                Channels.Remove(name);
            }
        }

        public static void Clear()
        {
            Channels.Clear();
        }

        //static ChatManager()
        //{
        //    using (StreamReader reader = new StreamReader(File.OpenRead(UOFileManager.GetUOFilePath("Chat.enu"))))
        //    {
        //        while (!reader.EndOfStream)
        //        {
        //            string line = reader.ReadLine();
        //        }
        //    }
        //}
    }
}