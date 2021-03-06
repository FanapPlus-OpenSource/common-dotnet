﻿using System.Collections.Generic;

namespace Appson.Common.GeneralComponents.Configuration
{
    public static class ApplicationSettingKeys
    {
        private static readonly List<string> Keys = new List<string>();

        public static void RegisterKey(string key)
        {
            if (!Keys.Contains(key))
                Keys.Add(key);
        }

        public static string[] RegisteredKeys => Keys.ToArray();
    }
}