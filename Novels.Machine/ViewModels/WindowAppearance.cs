using Newtonsoft.Json;

namespace Novels.Machine.ViewModels
{
    class WindowAppearance
    {
        public int Width { get; set; }

        public int Height { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public static WindowAppearance Parse(string serialized)
        {
            return string.IsNullOrEmpty(serialized) ? null : JsonConvert.DeserializeObject<WindowAppearance>(serialized);
        }
    }
}
