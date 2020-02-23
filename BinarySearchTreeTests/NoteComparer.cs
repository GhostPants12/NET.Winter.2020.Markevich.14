using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Notebook.Part1;

namespace BinarySearchTreeTests
{
    class NoteComparer : IComparer<Note>
    {
        public int Compare([AllowNull] Note x, [AllowNull] Note y) => x.NoteText == y.NoteText ? 0 : x.NoteText.Length > y.NoteText.Length ? 1 : -1;
    }
}
