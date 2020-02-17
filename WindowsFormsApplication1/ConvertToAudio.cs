using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace AVToolkit
{
    internal class ConvertToAudio : Operation
    {
        public ConvertToAudio(string inputFilePath) : base(inputFilePath)
        {
        }

        public BitrateMode EncodingMode { get; set; }

        public override void AssignParameterString()
        {
            switch (OutputFile.Codec.Ffmpeg_library)
            {
                case "libmp3lame":
                {
                    switch (EncodingMode)
                    {
                        case BitrateMode.CBR:
                        {
                            ParameterString =
                                "-hide_banner -i " + "\"" + InputFile.Path + "\"" + " -codec:a libmp3lame -b:a "
                                + OutputFile.Bitrate + "k -vn " + "\"" + OutputFile.Path + "\"";
                            break;
                        }
                        case BitrateMode.VBR:
                        {
                            ParameterString =
                                "-hide_banner -i " + "\"" + InputFile.Path + "\"" + " -codec:a libmp3lame -q:a "
                                + OutputFile.Bitrate + " " + "\"" + OutputFile.Path + "\"";
                            break;
                        }
                        case BitrateMode.ABR:
                        {
                            ParameterString =
                                "-hide_banner -i " + "\"" + InputFile.Path + "\"" + " -codec:a libmp3lame -abr 1 -b:a "
                                + OutputFile.Bitrate + "k -vn " + "\"" + OutputFile.Path + "\"";
                            break;
                        }
                        default:
                        {
                            ParameterString = "";
                            break;
                        }
                    }
                    break;
                }
                case "libfdk_aac":
                {
                    switch (EncodingMode)
                    {
                        case BitrateMode.CBR:
                        {
                            ParameterString =
                                "-hide_banner -i " + "\"" + InputFile.Path + "\"" + " -codec:a libfdk_aac -b:a "
                                + OutputFile.Bitrate
                                + "k -vn " + "\"" + OutputFile.Path + "\"";
                            break;
                        }
                        case BitrateMode.VBR:
                        {
                            ParameterString =
                                "-hide_banner -i " + "\"" + InputFile.Path + "\"" + " -codec:a libfdk_aac -vbr "
                                + (OutputFile.Bitrate + 1) // because quality values start at 1 for this codec
                                + " " + "\"" + OutputFile.Path + "\"";
                            break;
                        }
                        case BitrateMode.ABR:
                        {
                            ParameterString =
                                "-hide_banner -i " + "\"" + InputFile.Path + "\"" + " -codec:a libfdk_aac -abr 1 -b:a "
                                + OutputFile.Bitrate
                                + "k -vn " + "\"" + OutputFile.Path + "\"";
                            break;
                        }
                        default:
                        {
                            ParameterString = "";
                            break;
                        }
                    }
                    break;
                }
                case "aac":
                case "aac  -strict experimental":
                {
                    switch (EncodingMode)
                    {
                        case BitrateMode.CBR:
                        {
                            ParameterString = "-hide_banner -i " + "\"" + InputFile.Path + "\"" + " -codec:a aac -b:a "
                                              + OutputFile.Bitrate
                                              + "k -vn -strict -2 " + "\"" + OutputFile.Path + "\"";
                            break;
                        }
                        case BitrateMode.VBR:
                        {
                            ParameterString = "-hide_banner -i " + "\"" + InputFile.Path + "\"" + " -codec:a aac -q:a "
                                              + OutputFile.Bitrate
                                              + "-strict -2 " + "\"" + OutputFile.Path + "\"";
                            break;
                        }
                        case BitrateMode.ABR:
                        {
                            ParameterString =
                                "-hide_banner -i " + "\"" + InputFile.Path + "\"" + " -codec:a aac -abr 1 -b:a "
                                + OutputFile.Bitrate
                                + "k -vn -strict -2 " + "\"" + OutputFile.Path + "\"";
                            break;
                        }
                        default:
                        {
                            ParameterString = "";
                            break;
                        }
                    }
                    break;
                }

                default:
                    throw new InvalidOperationException("this file type or codec is not supported.");
            }
        }

        protected override void ParseOutput(Process proc)
        {
            var fileDur = (long) InputFile.Duration;
            //// from https://forums.creativecow.net/thread/291/286
            var outputFileSize = 128000 / 8 * fileDur; // in bytes

            var cancel = false;
            var reader = proc.StandardError;

            string line;

            while (!cancel && (line = reader.ReadLine()) != null)
            {
                Lines.Add(line);
                if (line.Length > 3)
                {
#if (DEBUG)
                    Console.WriteLine(line);
#endif
                    if (line.Substring(0, 4).TrimStart() == "size")
                    {
                        var m = Regex.Match(line, @"\d+");
                        if (m.Success)
                        {
#if (DEBUG)
                            Console.WriteLine(m.Value);
#endif
                            var bytesSoFar = double.Parse(m.Value);

                            var percentage = bytesSoFar / outputFileSize * 100000;

                            var eventArgs = new ProgEventArgs(percentage);

                            OnFfmpegProgressChanged(eventArgs);

                            if (eventArgs.Cancel)
                                cancel = true;
                        }
                    }
                }
            }
        }
    }
}