namespace AVToolkit
{
    public static class Tools
    {
        public static bool IsLibraryEnabled(string library)
        {
            var ffmpeg = new Ffmpeg();
            return ffmpeg.IsEnabled(library);
        }
    }
}