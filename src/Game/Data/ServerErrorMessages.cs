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
using ClassicUO.IO.Resources;
using ClassicUO.Localization;

namespace ClassicUO.Game.Data
{
    internal static class ServerErrorMessages
    {
        private static readonly Tuple<int, string>[] _loginErrors =
        {
            Tuple.Create(3000007, LocalizationManager.Get(LocalizationProperties.IncorrectPassword)),
            Tuple.Create(3000009, LocalizationManager.Get(LocalizationProperties.CharacterDoesNotExist)),
            Tuple.Create(3000006, LocalizationManager.Get(LocalizationProperties.CharacterAlreadyExists)),
            Tuple.Create(3000016, LocalizationManager.Get(LocalizationProperties.ClientCouldNotAttachToServer)),
            Tuple.Create(3000017, LocalizationManager.Get(LocalizationProperties.ClientCouldNotAttachToServer)),
            Tuple.Create(3000012, LocalizationManager.Get(LocalizationProperties.AnotherCharacterOnline)),
            Tuple.Create(3000013, LocalizationManager.Get(LocalizationProperties.ErrorInSynchronization)),
            Tuple.Create(3000005, LocalizationManager.Get(LocalizationProperties.IdleTooLong)),
            Tuple.Create(-1, LocalizationManager.Get(LocalizationProperties.CouldNotAttachServer)),
            Tuple.Create(-1, LocalizationManager.Get(LocalizationProperties.CharacterTransferInProgress))
        };

        private static readonly Tuple<int, string>[] _errorCode =
        {
            Tuple.Create(3000018, LocalizationManager.Get(LocalizationProperties.CharacterPasswordInvalid)),
            Tuple.Create(3000019, LocalizationManager.Get(LocalizationProperties.ThatCharacterDoesNotExist)),
            Tuple.Create(3000020, LocalizationManager.Get(LocalizationProperties.ThatCharacterIsBeingPlayed)),
            Tuple.Create(3000021, LocalizationManager.Get(LocalizationProperties.CharacterIsNotOldEnough)),
            Tuple.Create(3000022, LocalizationManager.Get(LocalizationProperties.CharacterIsQueuedForBackup)),
            Tuple.Create(3000023, LocalizationManager.Get(LocalizationProperties.CouldntCarryOutYourRequest))
        };

        private static readonly Tuple<int, string>[] _pickUpErrors =
        {
            Tuple.Create(3000267, LocalizationManager.Get(LocalizationProperties.YouCanNotPickThatUp)),
            Tuple.Create(3000268, LocalizationManager.Get(LocalizationProperties.ThatIsTooFarAway)),
            Tuple.Create(3000269, LocalizationManager.Get(LocalizationProperties.ThatIsOutOfSight)),
            Tuple.Create(3000270, LocalizationManager.Get(LocalizationProperties.ThatItemDoesNotBelongToYou)),
            Tuple.Create(3000271, LocalizationManager.Get(LocalizationProperties.YouAreAlreadyHoldingAnItem))
        };

        private static readonly Tuple<int, string>[] _generalErrors =
        {
            Tuple.Create(3000007, LocalizationManager.Get(LocalizationProperties.IncorrectNamePassword)),
            Tuple.Create(3000034, LocalizationManager.Get(LocalizationProperties.SomeoneIsAlreadyUsingThisAccount)),
            Tuple.Create(3000035, LocalizationManager.Get(LocalizationProperties.YourAccountHasBeenBlocked)),
            Tuple.Create(3000036, LocalizationManager.Get(LocalizationProperties.YourAccountCredentialsAreInvalid)),
            Tuple.Create(-1, LocalizationManager.Get(LocalizationProperties.CommunicationProblem)),
            Tuple.Create(-1, LocalizationManager.Get(LocalizationProperties.TheIGRConcurrencyLimitHasBeenMet)),
            Tuple.Create(-1, LocalizationManager.Get(LocalizationProperties.TheIGRTimeLimitHasBeenMet)),
            Tuple.Create(-1, LocalizationManager.Get(LocalizationProperties.GeneralIGRAuthenticationFailure)),
            Tuple.Create(3000037, LocalizationManager.Get(LocalizationProperties.CouldntConnectToUO))
        };

        public static string GetError(byte packetID, byte code)
        {
            ClilocLoader cliloc = ClilocLoader.Instance;

            switch (packetID)
            {
                case 0x53:
                    if (code >= 10)
                    {
                        code = 9;
                    }

                    Tuple<int, string> t = _loginErrors[code];

                    return cliloc.GetString(t.Item1, t.Item2);

                case 0x85:
                    if (code >= 6)
                    {
                        code = 5;
                    }

                    t = _errorCode[code];

                    return cliloc.GetString(t.Item1, t.Item2);

                case 0x27:
                    if (code >= 5)
                    {
                        code = 4;
                    }

                    t = _pickUpErrors[code];

                    return cliloc.GetString(t.Item1, t.Item2);

                case 0x82:
                    if (code >= 9)
                    {
                        code = 8;
                    }

                    t = _generalErrors[code];

                    return cliloc.GetString(t.Item1, t.Item2);
            }

            return string.Empty;
        }
    }
}