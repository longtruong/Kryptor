﻿using System;
using Sodium;

/*  
    Kryptor: Free and open source file encryption software.
    Copyright(C) 2020 Samuel Lucas

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program. If not, see https://www.gnu.org/licenses/. 
*/

namespace Kryptor
{
    public static class Generate
    {
        public static byte[] AssociatedData()
        {
            Enum cipher = (Cipher)Globals.EncryptionAlgorithm;
            string cipherName = Enum.GetName(cipher.GetType(), cipher);
            return HashingAlgorithms.Blake2(cipherName);
        }

        public static byte[] Salt()
        {
            return SodiumCore.GetRandomBytes(Constants.SaltLength);
        }

        public static byte[] Nonce()
        {
            if (Globals.EncryptionAlgorithm == (int)Cipher.XChaCha20 || Globals.EncryptionAlgorithm == (int)Cipher.XSalsa20)
            {
                return SodiumCore.GetRandomBytes(Constants.XChaChaNonceLength);
            }
            else
            {
                return SodiumCore.GetRandomBytes(Constants.AesNonceLength);
            }
        }
    }
}
