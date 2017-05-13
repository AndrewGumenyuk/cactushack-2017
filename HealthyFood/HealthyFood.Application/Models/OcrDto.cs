using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthyFood.Application.Models
{
    public class OcrDto
    {
        public List<ParsedResult> ParsedResults { get; set; }
        public int OCRExitCode { get; set; }
        public bool IsErroredOnProcessing { get; set; }
        public object ErrorMessage { get; set; }
        public object ErrorDetails { get; set; }
        public string ProcessingTimeInMilliseconds { get; set; }
    }
    public class TextOverlay
    {
        public List<object> Lines { get; set; }
        public bool HasOverlay { get; set; }
        public string Message { get; set; }
    }
    public class ParsedResult
    {
        public TextOverlay TextOverlay { get; set; }
        public int FileParseExitCode { get; set; }
        public string ParsedText { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorDetails { get; set; }
    }
}