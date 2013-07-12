﻿//
// Settings.cs
//
// Copyright (c) 2012 Kenji Wada, http://ch3cooh.jp/
// 
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files 
// (the "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

#if NETFX_CORE
using Windows.Storage;
#elif WINDOWS_PHONE
using System.IO.IsolatedStorage;
#endif

namespace Softbuild.Data
{
    /// <summary>
    /// アプリケーションの設定項目を管理するクラス
    /// </summary>
    public static class Settings
    {
        /// <summary>
        /// キーと値のペアのディクショナリにエントリを追加します。
        /// </summary>
        /// <typeparam name="T">設定値の型</typeparam>
        /// <param name="key">設定値に関連付けたキー</param>
        /// <param name="value">設定値</param>
        public static void Set<T>(string key, T value)
        {
#if NETFX_CORE
            ApplicationData.Current.LocalSettings.Values[key] = value;
#elif WINDOWS_PHONE
            IsolatedStorageSettings.ApplicationSettings[key] = value;
            IsolatedStorageSettings.ApplicationSettings.Save();
#endif
        }

        /// <summary>
        /// 指定されたキーが存在しているかを取得する。
        /// </summary>
        /// <param name="key">設定値に関連付けたキー</param>
        /// <returns>存在しているかどうか</returns>
        public static bool Contains(string key)
        {
            bool isContains = false;
#if NETFX_CORE
            isContains = ApplicationData.Current.LocalSettings.Values.Keys.Contains(key);
#elif WINDOWS_PHONE
            isContains = IsolatedStorageSettings.ApplicationSettings.Contains(key);
#endif
            return isContains;
        }

        /// <summary>
        /// 指定されたキーに関連付けられている値を取得する。
        /// </summary>
        /// <typeparam name="T">設定値の型</typeparam>
        /// <param name="key">設定値に関連付けたキー</param>
        /// <returns>取得した値</returns>
        public static T Get<T>(string key)
        {
            T value = default(T);
#if NETFX_CORE
            value = (T)ApplicationData.Current.LocalSettings.Values[key];
#elif WINDOWS_PHONE
            try
            {
                value = (T)IsolatedStorageSettings.ApplicationSettings[key];
            }
            catch (System.Collections.Generic.KeyNotFoundException)
            {
                value = default(T);
            }
#endif
            return value;
        }

        /// <summary>
        /// 指定されたキーに関連付けられている値を取得する。
        /// </summary>
        /// <typeparam name="T">設定値の型</typeparam>
        /// <param name="key">設定値に関連付けたキー</param>
        /// <param name="defaultValue">設定値に関連付けたキー</param>
        /// <returns>取得した値、またはデフォルト値</returns>
        public static T Get<T>(string key, T defaultValue)
        {
            bool isContains = Settings.Contains(key);
            if (!isContains)
            {
                return defaultValue;
            }
            return Get<T>(key);
        }

        /// <summary>
        /// 指定されたキーを持つエントリを削除します。
        /// </summary>
        /// <param name="key">設定値に関連付けたキー</param>
        public static void Remove(string key)
        {
#if NETFX_CORE
            ApplicationData.Current.LocalSettings.Values.Remove(key);
#elif WINDOWS_PHONE
            IsolatedStorageSettings.ApplicationSettings.Remove(key);
#endif
        }
    }
}
