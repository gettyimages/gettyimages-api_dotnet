// MIT License
//
// Copyright (c) 2020 Jorge Serrano Pérez
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
//
// https://github.com/J0rgeSerran0/JsonNamingPolicy

// ReSharper disable once CheckNamespace
namespace System.Text.Json
{
    public class JsonSnakeCaseNamingPolicy : JsonNamingPolicy
    {
        private const string Separator = "_";

        public override string ConvertName(string name)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            {
                return string.Empty;
            }

            var spanName = name.Trim().AsSpan();
            var stringBuilder = new StringBuilder();
            var addCharacter = true;
            var isNextLower = false;
            var isNextUpper = false;
            var isNextSpace = false;

            for (int position = 0; position < spanName.Length; position++)
            {
                if (position != 0)
                {
                    var isCurrentSpace = spanName[position] == 32;
                    var isPreviousSpace = spanName[position - 1] == 32;
                    var isPreviousSeparator = spanName[position - 1] == 95;

                    if (position + 1 != spanName.Length)
                    {
                        isNextLower = spanName[position + 1] > 96 && spanName[position + 1] < 123;
                        isNextUpper = spanName[position + 1] > 64 && spanName[position + 1] < 91;
                        isNextSpace = spanName[position + 1] == 32;
                    }

                    if (isCurrentSpace &&
                        (isPreviousSpace || 
                        isPreviousSeparator || 
                        isNextUpper || 
                        isNextSpace))
                        addCharacter = false;
                    else
                    {
                        var isCurrentUpper = spanName[position] > 64 && spanName[position] < 91;
                        var isPreviousLower = spanName[position - 1] > 96 && spanName[position - 1] < 123;
                        var isPreviousNumber = spanName[position - 1] > 47 && spanName[position - 1] < 58;

                        if (isCurrentUpper &&
                            (isPreviousLower ||
                             isPreviousNumber ||
                             isNextLower ||
                             isNextSpace ||
                             isNextLower && !isPreviousSpace))
                        {
                            stringBuilder.Append(Separator);
                        }
                        else
                        {
                            if (isCurrentSpace && 
                                !isPreviousSpace && 
                                !isNextSpace)
                            {
                                stringBuilder.Append(Separator);
                                addCharacter = false;
                            }
                        }
                    }
                }

                if (addCharacter)
                    stringBuilder.Append(spanName[position]);
                else
                    addCharacter = true;
            }

            return stringBuilder.ToString().ToLower();
        }
    }
}
