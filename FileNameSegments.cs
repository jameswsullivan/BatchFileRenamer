using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchFileRenamer
{
    public class FileNameSegments
    {
        public string _content { get; set; }
        public bool _isPlaceholder { get; set; }

        public FileNameSegments(string content, bool isPlaceholder)
        {
            _content = content;
            _isPlaceholder = isPlaceholder;
        }
    }
}
