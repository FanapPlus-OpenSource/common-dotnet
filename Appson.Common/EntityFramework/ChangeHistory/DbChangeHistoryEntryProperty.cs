﻿namespace Appson.Common.EntityFramework.ChangeHistory
{
    public class DbChangeHistoryEntryProperty
    {
        public string Name { get; set; }
        public object OldValue { get; set; }
        public object NewValue { get; set; }
    }
}