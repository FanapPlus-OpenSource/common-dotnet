﻿using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace Appson.Common.EntityFramework.ChangeHistory
{
    public class DbChangeHistoryGenerator
    {
        private List<DbChangeHistoryEntry> _entries;

        public void CleanUp()
        {
            _entries = null;
        }

        public bool IsClean => _entries == null || _entries.Count < 1;

        public List<DbChangeHistoryEntry> Entries => _entries;

        public void ProcessEntry(DbEntityEntry entry)
        {
            var historyEntry = DbChangeHistoryEntry.FromDbEntityEntry(entry);
            if (historyEntry != null)
            {
                if (_entries == null)
                    _entries = new List<DbChangeHistoryEntry>();

                _entries.Add(historyEntry);
            }
        }

        public void PostProcessAfterSaveChanges()
        {
            if (IsClean)
                return;

            _entries.ForEach(e => e.PostProcessAfterSaveChanges());
            _entries = _entries.Where(e => e.HasAnyChanges).ToList();
        }
    }
}